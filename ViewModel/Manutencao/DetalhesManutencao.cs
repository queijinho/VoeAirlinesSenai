using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel.Manutencao;
public class DetalhesManutencaoViewModel{
    public DetalhesManutencaoViewModel(DateTime dataHora, string? observacoes, TipoManutencao tipoManutencao)
    {
        DataHora = dataHora;
        TipoManutencao = tipoManutencao;
    }

    public DetalhesManutencaoViewModel(int id, DateTime dataHora, TipoManutencao tipoManutencao, string? observacao, int aeronaveId)
    {
        Id = id;
        DataHora = dataHora;
        TipoManutencao = tipoManutencao;
        Observacao = observacao;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public string? Observacao { get; set; }
    public int AeronaveId { get; set; }
}