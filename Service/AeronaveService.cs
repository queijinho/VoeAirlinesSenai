using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class AeronaveService{

    private readonly VoeAirlinesSenaiContexts _Context;

    public AeronaveService(VoeAirlinesSenaiContexts Context)
    {
        _Context = Context;
    }
    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
       var aeronave = new Aeronave (dados.Fabricante,dados.Modelo,dados.Codigo);

       _Context.Add(aeronave);
       _Context.SaveChanges();

       return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);

    }

    public IEnumerable<ListarAeronaveViewModel> ListarAeronaves(){
        return _Context.Aeronaves.Select(a=>new ListarAeronaveViewModel(a.Id, a.Modelo, a.Codigo));
    }
    public DetalhesAeronaveViewModel? ListarAeronavePeloId(int id){
        var aeronave = _Context.Aeronaves.Find(id);
        if(aeronave != null){
            return new DetalhesAeronaveViewModel(aeronave.Id, aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }else{
            return null;
        }
    }
     public void ExcluirAeronave(int id){
        var aeronave = _Context.Aeronaves.Find(id);
        if(aeronave != null){
            _Context.Remove(aeronave);
            _Context.SaveChanges();
        }
     }
     public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados){
        var aeronave = _Context.Aeronaves.Find(dados.Id);
        if(aeronave != null){
            aeronave.Fabricante = dados.Fabricante;
            aeronave.Modelo = dados.Modelo;
            aeronave.Codigo = dados.Codigo;
            _Context.Update(aeronave);
            _Context.SaveChanges();
            return new DetalhesAeronaveViewModel(aeronave.Id,aeronave.Fabricante, aeronave.Modelo, aeronave.Codigo);
        }else{
            return null;
        }
    }
}