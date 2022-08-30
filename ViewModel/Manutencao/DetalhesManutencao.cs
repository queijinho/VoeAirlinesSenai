using VoeAirlinesSenai.Entities.Enums;

namespace VoeAirlinesSenai.ViewModel.Manutencao;
public class DetalhesManutencaoViewModel{
    private string? observacoes;
    private TipoManutencao tipo;

    public DetalhesManutencaoViewModel(DateTime dateTime)
    {
        DateTime = dateTime;
    }

    public DetalhesManutencaoViewModel(DateTime dateTime, string? observacoes, TipoManutencao tipo) : this(dateTime)
    {
        this.observacoes = observacoes;
        this.tipo = tipo;
    }

    public DetalhesManutencaoViewModel(int id, TipoManutencao tipoManutencao, string? observacao, int aeronaveId)
    {
        Id = id;
        TipoManutencao = tipoManutencao;
        Observacao = observacao;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DateTime { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public string? Observacao { get; set; }
    public int AeronaveId { get; set; }
}