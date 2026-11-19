using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly BancoContext _db;

    public ContasController(BancoContext db) => _db = db;


    // private static readonly List<Conta> _contas = new(){
    //     new Conta{Id = 1, ClienteId = 1, Numero= 10, Tipo = "Corrente",
    //     Saldo = 1500m},
    //     new Conta{Id = 2, ClienteId = 2, Numero = 20, Tipo = "Poupanca",
    //     Saldo = 1500000m} // estava criando na nossa memória.


public record ValorDto(decimal Valor);

    private static int _proximoId = 3; // contador para gerar o próximo Id de conta.

    [HttpGet]
    public async Task<ActionResult<List<Conta>>> GetTodas()
    {
        return Ok(await _db.Contas.ToListAsync()); 
        
        // retorna todas as contas do banco de dados.
        // if (string.IsNullOrEmpty(tipo)){
        //     return Ok(_contas);
        // }
        // var _filtradas = _contas.Where(c => c.Tipo == tipo).ToList();
        // return Ok(_filtradas); não usa mais estes métodos, pois agora estamos usando o banco de dados.
    }

    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Conta>> GetPorId(int id){
        var conta = await _db.Contas.FindAsync(id);
        if(conta == null){
            return NotFound();
        }
        return Ok(conta);
    }
        
        
        [HttpPost]
    public async Task<ActionResult<Conta>> Criar(Conta nova){
        _db.Contas.Add(nova);
        await _db.SaveChangesAsync();
        
        return CreatedAtAction(nameof(GetPorId), new {id = nova.Id}, nova);
    }

// [HttpPost("{id:int}/depositar")]
//     public ActionResult<Conta> Depositar(int id, ValorDto valor)
//     {
//         var conta = _contas.FirstOrDefault(c => c.Id == id);
//         if(conta == null){
//             return NotFound();
//         }
//         if(valor.Valor <=0)
//             return BadRequest("O valor do depósito deve ser maior que zero.");
//         conta.Saldo += valor.Valor;
//         return Ok(conta);
//     }


    //     [HttpPut("{id:int}")]
    // public IActionResult Atualizar(int id, Conta dados){
    //     var conta = _contas.FirstOrDefault(c => c.Id == id);
    //     if(conta == null){
    //         return NotFound();
    //     }
    //     conta.Tipo = dados.Tipo;
    //     conta.Saldo = dados.Saldo;
    //     conta.Ativa = dados.Ativa;
    //     return NoContent();
    // }

        [HttpDelete("{id:int}")]
    public async Task<IActionResult> Remover(int id){
        var conta = await _db.Contas.FindAsync(id);
        if(conta == null){
            return NotFound();
        }
        _db.Contas.Remove(conta);
        await _db.SaveChangesAsync();
        return NoContent();   
    }
}