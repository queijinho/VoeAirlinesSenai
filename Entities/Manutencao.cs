namespace VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.Entities.Enums;
public class Manutencao{
    private string? observacao;

    public Manutencao(TipoManutencao tipoManutencao)
    {
    }

    public Manutencao(TipoManutencao tipoManutencao, DateTime dataHora, string? observacao) : this(tipoManutencao)
    {
        DataHora = dataHora;
        this.observacao = observacao;
    }

    public Manutencao(DateTime dataHora, TipoManutencao tipoManutencao, int aeronaveId, string? observacoes = null)
    {
        this.DataHora = dataHora;
        this.Observacoes = observacoes;
        this.TipoManutencao = TipoManutencao;
        this.AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    public TipoManutencao TipoManutencao { get; set; }
    public int AeronaveId { get; set; }
    public Aeronave Aeronave { get; set; }= null!;
    
}