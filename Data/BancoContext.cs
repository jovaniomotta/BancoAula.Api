using Microsoft.EntityFrameworkCore;


public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options)
    {
    }
    public DbSet<Cliente> Clientes { get; set; } = null!;
    public DbSet<Agencia> Agencias { get; set; } = null!;
    public DbSet<Conta> Contas { get; set; } = null!;
    public DbSet<Transacao> Transacoes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique();
        mb.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
        mb.Entity<Conta>().Property(c => c.Saldo).HasPrecision(12, 2);
        mb.Entity<Conta>().HasIndex(c => c.Numero).IsUnique();
        mb.Entity<Conta>().HasOne(c => c.Cliente).WithMany(c => c.Contas).HasForeignKey(c => c.ClienteId);

    }
}


