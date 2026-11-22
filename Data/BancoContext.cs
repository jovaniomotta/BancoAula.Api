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
    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();
    

    protected override void OnModelCreating(ModelBuilder mb)
    {
        mb.Entity<Cliente>().HasIndex(c => c.Cpf).IsUnique();
        mb.Entity<Cliente>().Property(c => c.Nome).HasMaxLength(100).IsRequired();
        mb.Entity<Conta>().Property(c => c.Saldo).HasPrecision(12, 2);
        mb.Entity<Conta>().HasIndex(c => c.Numero).IsUnique();
        mb.Entity<Conta>().HasOne(c => c.Cliente).WithMany(c => c.Contas).HasForeignKey(c => c.ClienteId);
         mb.Entity<Transacao>().Property(t => t.Valor).HasPrecision(12, 2);
         mb.Entity<Emprestimo>().Property(e => e.Valor).HasPrecision(12, 2);
         mb.Entity<Emprestimo>().Property(e => e.TaxaJuros).HasPrecision(10, 2);
         mb.Entity<Agencia>().HasData(
            new Agencia { Id = 1, Nome = "Centro", Cidade = "Campo Grande" },
            new Agencia { Id = 2, Nome = "Moreninhas", Cidade = "Campo Grande"}
        );
        mb.Entity<Cliente>().HasData(
            new Cliente { Id = 1, Nome = "João da Silva", Cpf = "11111111111", Cidade = "Campo Grande" },
            new Cliente { Id = 2, Nome = "Maria Oliveira", Cpf = "22222222222", Cidade = "Campo Grande" }
        );

    }
}


