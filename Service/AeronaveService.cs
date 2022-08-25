using VoeAirlinesSenai.Contexts;
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.ViewModel;

namespace VoeAirlinesSenai.Services;

public class AeronaveServices{

    private readonly VoeAirlinesSenaiContexts _Context;

    public AeronaveServices(VoeAirlinesSenaiContexts Contexts)
    {
        _Context = Contexts;
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
    public DetalhesAeronaveViewModel? AtualizarAeronave(AtualizarAeronaveViewModel dados){
        return null;
    }
     public void Excluir(int id){
        var aeronave = _Context.Aeronaves.Find(id);
        if(aeronave != null){
            _Context.Remove(aeronave);
            _Context.SaveChanges();
        }
     }
}  