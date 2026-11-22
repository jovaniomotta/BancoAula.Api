using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BancoAula.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContasController : ControllerBase
{
    private readonly IContaService _service;

    public ContasController(IContaService service)
    {
        _service = service;
    }


    [HttpGet]
    public async Task<ActionResult<List<ContasDto>>> Get() => Ok(_service.GetTodasAsync());
    
        
    
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ContasDto>> GetPorId(int id){
        var conta = await _service.GetPorIdAsync(id);
        if(conta == null){
            return NotFound();
        }
        return Ok(conta);
    }
        
        
        [HttpPost]
    public async Task<ActionResult<ContasDto>> Criar(ContasDto nova){
       var conta = await _service.CriarAsync(nova);
        return CreatedAtAction(nameof(GetPorId), new {id = conta.Numero}, conta);
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
        var conta = await _service.RemoverAsync(id);
        if(!conta){
            return NotFound();
        }
        return NoContent();
      
    }
}