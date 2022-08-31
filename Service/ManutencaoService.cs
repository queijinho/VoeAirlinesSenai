using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel.Manutencao;

namespace VoeAirlinesSenai.Service;
public class ManutencaoService{

    private readonly VoeAirlinesSenaiContexts _Context;
    public ManutencaoService(VoeAirlinesSenaiContexts contexts){
        _Context =contexts;
    }

        public DetalhesManutencaoViewModel AdicionarManutencao(AdicionarManutencaoViewModel dados){
            var manutencao = new Manutencao(dados.TipoManutencao, dados.dataHora, dados.Observacao);
            
            _Context.Add(manutencao);
            _Context.SaveChanges();

            return new DetalhesManutencaoViewModel(manutencao.DataHora, manutencao.Observacoes, manutencao.TipoManutencao);
        }

    public DetalhesManutencaoViewModel? AtualizarManutencao(int id, AtualizarManutencaoViewModel dados)
        {
            var manutencao = _Context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                manutencao.DataHora = dados.dateTime;
                manutencao.TipoManutencao = dados.TipoManutencao;
                manutencao.Observacoes = dados.Observacao;
                manutencao.AeronaveId = dados.AeronaveId;  
                _Context.Update(manutencao);
                _Context.SaveChanges();
                return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.TipoManutencao, manutencao.Observacoes, manutencao.AeronaveId);

            }
            return null;

        }

    internal object AdicionarManutencaoViewModelnutencao(AdicionarManutencaoViewModel dados)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<ListarManutencaoViewModel> ListarManutencoes()
        {
            return _Context.Manutencoes.Select(x => new ListarManutencaoViewModel(x.Id, x.DataHora, x.TipoManutencao, x.Observacoes, x.AeronaveId)) ;
        }

        public ListarManutencaoViewModel? ListarManutencaoPorId(int id)
        {
            var manutencao = _Context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                return new ListarManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.TipoManutencao, manutencao.Observacoes, manutencao.AeronaveId);
            }
            return null;
        }

        public IEnumerable<ListarManutencaoViewModel> ListarManutencoesPorAeronave(int aeronaveId)
        {
            return _Context.Manutencoes.Where(x => x.AeronaveId == aeronaveId).Select(x => new ListarManutencaoViewModel(x.Id, x.DataHora, x.TipoManutencao, x.Observacoes, x.AeronaveId));
        }

        public DetalhesManutencaoViewModel? RemoverManutencao(int id)
        {
            var manutencao = _Context.Manutencoes.Find(id);
            if (manutencao != null)
            {
                if (id == manutencao.Id)
                {
                    _Context.Manutencoes.Remove(manutencao);
                    _Context.SaveChanges();
                    return new DetalhesManutencaoViewModel(manutencao.Id, manutencao.DataHora, manutencao.TipoManutencao, manutencao.Observacoes, manutencao.AeronaveId);
                }
            }
            return null;
        }
    }