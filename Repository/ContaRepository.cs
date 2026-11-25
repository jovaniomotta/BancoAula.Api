using Microsoft.EntityFrameworkCore;

public class ContaRepository : IContaRepository
{
    private readonly BancoContext _context;

    public ContaRepository(BancoContext context)
    {
        _context = context;
    }

    public async Task<List<Conta>> GetTodasAsync()
    {
        return await _context.Contas.ToListAsync<Conta>();
    }

    public async Task<Conta?> GetPorIdAsync(int id)
    {
        return await _context.Contas.FindAsync(id);
    }

    public async Task<Conta> CriarAsync(Conta nova)
    {
        _context.Contas.Add(nova);
        await _context.SaveChangesAsync();
        return nova;
    }

    public async Task<bool> RemoveAsync(int id)
    {
        var conta = await _context.Contas.FindAsync(id);
        if (conta == null)
            return false;

        _context.Contas.Remove(conta);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<Conta> AtualizarAsync(Conta conta)
    {
        _context.Contas.Update(conta);
        await _context.SaveChangesAsync();
        return conta;
    }
}