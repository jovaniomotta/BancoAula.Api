public interface IContaRepository
{
    Task<List<Conta>> GetTodasAsync();
    Task<Conta?> GetPorIdAsync(int id);
    Task<Conta> CriarAsync(Conta nova);
    Task<Conta> AtualizarAsync(Conta conta);
    Task<bool> RemoveAsync(int id);
}