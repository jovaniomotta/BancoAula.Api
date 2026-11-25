public interface IContaService
{
    Task<List<ContasDto>> GetTodasAsync();
    Task<ContaResponseDto?> GetPorIdAsync(int id);
    Task<ContasDto> CriarAsync(ContasDto nova);
    Task<bool> RemoverAsync(int id);
    Task<ContaResponseDto> SacarAsync(int id, decimal valor);
}