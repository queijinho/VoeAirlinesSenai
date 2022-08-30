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


}