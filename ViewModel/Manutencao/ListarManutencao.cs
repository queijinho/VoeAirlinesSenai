using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel;
public class ListarManutencaoViewModel{
    public ListarManutencaoViewModel(int id, DateTime dateTime, TipoManutencao tipoManutencao, string? observacao, int aeronaveId)
    {
        Id = id;
        this.dateTime = dateTime;
        TipoManutencao = tipoManutencao;
        Observacao = observacao;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime dateTime { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public string? Observacao { get; set; }
    public int AeronaveId { get; set; }
}