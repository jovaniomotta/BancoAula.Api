public class ContaService : IContaService
{
    private readonly IContaRepository _repository;

    public ContaService(IContaRepository repository)
    {
        _repository = repository;
    }

    public async Task<ContaResponseDto> SacarAsync(int id, decimal valor)
    {
        var conta = await _repository.GetPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Conta com ID {id} não encontrada.");

        if (conta.Saldo < valor)
        {
            throw new SaldoInsuficienteException("Saldo insuficiente para realizar o saque.");
        }

        conta.Saldo -= valor;
        await _repository.AtualizarAsync(conta);

       return Mapper(conta);

    }

    //buscar 1 conta
    public async Task<ContaResponseDto?> GetPorIdAsync(int id)
    {
        var conta = await _repository.GetPorIdAsync(id)
            ?? throw new KeyNotFoundException($"Conta com ID {id} não encontrada.");
        

        return Mapper(conta);

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

    private static ContaResponseDto Mapper(Conta conta)
    {
        return new ContaResponseDto
        {
           Id = conta.Id,
           Numero = conta.Numero,
              Tipo = conta.Tipo,
              Saldo = conta.Saldo
        };
    }
}