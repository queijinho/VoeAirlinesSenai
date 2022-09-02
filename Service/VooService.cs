using System.Text;
using DinkToPdf;
using DinkToPdf.Contracts;
using Microsoft.EntityFrameworkCore;
using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel.Voo;

namespace VoeAirlinesSenai.Services;

    public class VooService
    {
        private readonly VoeAirlinesSenaiContexts _context;
        private readonly IConverter _converter;
        private readonly IHostEnvironment _hostEnvironmet;

        public VooService(VoeAirlinesSenaiContexts context, IConverter converter, IHostEnvironment hostEnvironment)
        {
            _context = context;
            _converter = converter;
            _hostEnvironmet = hostEnvironment;
        }

        public DetalhesVooViewModel AdicionarVoo(AdicionarVooViewModel dados)
        {
            var voo = new Voo(dados.Origem, dados.Destino, dados.DataHoraPartida, dados.DataHoraChegada, dados.AeronaveId, dados.PilotoId);
            _context.Add(voo);
            _context.SaveChanges();
            return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
        }

        public DetalhesVooViewModel? AtualizarVoo(int id, AtualizarVooViewModel dados)
        {
            var voo = _context.Voos.Find(id);
            if (voo != null)
            {
                if (id == voo.Id)
                {
                    voo.Origem = dados.Origem;
                    voo.Destino = dados.Destino;
                    voo.DataHoraPartida = dados.DataHoraPartida;
                    voo.DataHoraChegada = dados.DataHoraChegada;
                    voo.AeronaveId = dados.AeronaveId;
                    voo.PilotoId = dados.PilotoId;
                    _context.Update(voo);
                    _context.SaveChanges();
                    return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
                }
            }
            return null;
        }

        public IEnumerable<ListarVooViewModel> ListarVoos()
        {
            return _context.Voos.Select(x => new ListarVooViewModel(x.Id, x.Origem, x.Destino, x.DataHoraPartida, x.DataHoraChegada, x.AeronaveId, x.PilotoId));
        }

        public ListarVooViewModel? ListarPorId(int id)
        {
            var voo = _context.Voos.Find(id);
            if (voo != null)
            {
                return new ListarVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
            }
            return null;
        }

        public DetalhesVooViewModel? RemoverVoo(int id)
        {
            var voo = _context.Voos.Find(id);
            if (voo != null)
            {
                if (id == voo.Id)
                {
                    _context.Voos.Remove(voo);
                    _context.SaveChanges();
                    return new DetalhesVooViewModel(voo.Id, voo.Origem, voo.Destino, voo.DataHoraPartida, voo.DataHoraChegada, voo.AeronaveId, voo.PilotoId);
                }
            }
            return null;
        }
        public byte[]? GerarFichaDoVoo(int id)
    {
        var voo = _context.Voos.Include(v => v.Aeronave)
                               .Include(v => v.Piloto)
                               .Include(v => v.Cancelamento)
                               .FirstOrDefault(v => v.Id == id);

        var path = _hostEnvironmet.ContentRootPath + "\\img\\banner-voeairlines.png";

        if (voo != null)
        {
            var builder = new StringBuilder();

            builder.Append($"<img src=\"{path}\" width='1000'/>")
                   .Append($"<h1 style='text-align: center'>Ficha do Voo { voo.Id.ToString().PadLeft(10, '0') }</h1>")
                   .Append($"<hr>")
                   .Append($"<p><b>ORIGEM:</b> { voo.Origem } (saída em { voo.DataHoraPartida:dd/MM/yyyy} às { voo.DataHoraPartida:hh:mm})</p>")
                   .Append($"<p><b>DESTINO:</b> { voo.Destino} (chegada em { voo.DataHoraChegada:dd/MM/yyyy} às { voo.DataHoraChegada:hh:mm})</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>AERONAVE:</b> { voo.Aeronave!.Codigo } ({ voo.Aeronave.Fabricante } { voo.Aeronave.Modelo })</p>")
                   .Append($"<hr>")
                   .Append($"<p><b>PILOTO:</b> { voo.Piloto!.Nome } ({ voo.Piloto.Matricula})</p>")
                   .Append($"<hr>");
            if (voo.Cancelamento != null)
            {
                builder.Append($"<p style='color: red'><b>VOO CANCELADO:</b> { voo.Cancelamento.Motivo }</p>");
            }

            var doc = new HtmlToPdfDocument()
            {
                GlobalSettings = {
                    ColorMode = ColorMode.Color,
                    Orientation = Orientation.Portrait,
                    PaperSize = PaperKind.A4
                },
                Objects = {
                    new ObjectSettings() {
                        PagesCount = true,
                        HtmlContent = builder.ToString(),
                        WebSettings = { DefaultEncoding = "utf-8" }
                    }
                }
            };

            return _converter.Convert(doc);
        }

        return null;
    }
    }