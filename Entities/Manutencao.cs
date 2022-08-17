namespace VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.Entities.Enums;
public class Manutencao{
    public Manutencao(DateTime dataHora, TipoManutencao tipo, int aeronaveId, string? observacoes = null)
    {
        this.DataHora = dataHora;
        this.Observacoes = observacoes;
        this.Tipo = tipo;
        this.AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string? Observacoes { get; set; }
    public TipoManutencao Tipo { get; set; }
    public int AeronaveId { get; set; }
    public Aeronave Aeronave { get; set; }= null!;
    
}