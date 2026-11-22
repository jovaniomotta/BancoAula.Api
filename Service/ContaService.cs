public class ContaService : IContaService
{
    private readonly IContaRepository _repository;

    public ContaService(IContaRepository repository)
    {
        _repository = repository;
    }
    //buscar 1 conta
    public async Task<ContasDto?> GetPorIdAsync(int id)
    {
        var conta = await _repository.GetPorIdAsync(id);
        if (conta == null)
            return null;

        return new ContasDto (conta.Numero, conta.Tipo, conta.Saldo, conta.Ativa, conta.ClienteId, conta.AgenciaId );
    }

    public async Task<List<ContasDto>> GetTodasAsync()
    {
        var contas = await _repository.GetTodasAsync();
        return contas.Select(c => new ContasDto(c.Numero, c.Tipo, c.Saldo, c.Ativa, c.ClienteId, c.AgenciaId)).ToList();
    }
    //criar conta
    public async Task<ContasDto> CriarAsync(ContasDto nova)
    {
        var conta = new Conta
        {
            Numero = nova.Numero,
            Tipo = nova.Tipo,
            Saldo = nova.Saldo,
            Ativa = nova.Ativa,
            ClienteId = nova.ClienteId,
            AgenciaId = nova.AgenciaId
        };

        var criada = await _repository.CriarAsync(conta);
        return new ContasDto(criada.Numero, criada.Tipo, criada.Saldo, criada.Ativa, criada.ClienteId, criada.AgenciaId);
    }
    //deletar conta
    public async Task<bool> RemoverAsync(int id)
    {
        return await _repository.RemoveAsync(id);
    }
}