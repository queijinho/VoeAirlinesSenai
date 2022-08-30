using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel.Manutencao;
public class AdicionarManutencaoViewModel{
    public AdicionarManutencaoViewModel(int aeronaveId)
    {
        AeronaveId = aeronaveId;
    }

    public AdicionarManutencaoViewModel(DateTime dateTime, TipoManutencao tipoManutencao, string? observacao)
    {
        this.dataHora = dateTime;
        TipoManutencao = tipoManutencao;
        Observacao = observacao;
    }

    public DateTime dataHora { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public string? Observacao { get; set; }
    public int AeronaveId { get; set; }
}