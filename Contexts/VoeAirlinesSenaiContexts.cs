using Microsoft.EntityFrameworkCore; //o que eu vou usar do entity
using VoeAirlinesSenai.Entities;
using VoeAirlinesSenai.EntityConfiguration;

namespace VoeAirlinesSenai.Contexts;
public class VoeAirlinesSenaiContexts:DbContext{
    private readonly IConfiguration _configuration;
    public VoeAirlinesSenaiContexts(IConfiguration configuration){
        _configuration = configuration;
    }

    public DbSet<Aeronave> Aeronaves =>Set<Aeronave>();
    public DbSet<Manutencao> Manutencoes =>Set<Manutencao>();
    public DbSet<Piloto> Pilotos =>Set<Piloto>();
    public DbSet<Voo> Voos =>Set<Voo>();
    public DbSet<Cancelamento> Cancelamentos =>Set<Cancelamento>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("VoeAirlinesSenai"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfiguration(new AeronaveConfiguration());
        modelBuilder.ApplyConfiguration(new PilotoConfiguration());
        modelBuilder.ApplyConfiguration(new VooConfiguration());
        modelBuilder.ApplyConfiguration(new CancelamentoConfiguration());
    }
}