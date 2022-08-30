using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel;
public class AtualizarManutencaoViewModel{
    public AtualizarManutencaoViewModel(DateTime dateTime, TipoManutencao tipoManutencao, string? observacao, int aeronaveId)
    {
        this.dateTime = dateTime;
        TipoManutencao = tipoManutencao;
        Observacao = observacao;
        AeronaveId = aeronaveId;
    }

    public DateTime dateTime { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public string? Observacao { get; set; }
    public int AeronaveId { get; set; }
}