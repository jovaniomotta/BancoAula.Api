public interface IContaService
{
    Task<List<ContasDto>> GetTodasAsync();
    Task<ContasDto?> GetPorIdAsync(int id);
    Task<ContasDto> CriarAsync(ContasDto nova);
    Task<bool> RemoverAsync(int id);
}