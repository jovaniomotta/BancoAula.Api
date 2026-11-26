using Microsoft.AspNetCore.Mvc;

public class ErroMiddleware
{
    private readonly RequestDelegate _next;
 

    public ErroMiddleware(RequestDelegate next)
    {
        _next = next;
    }
      

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await TratarAsync(context, ex);
        }
    }

    private static async Task TratarAsync(HttpContext context, Exception ex)
    {
       var (status, titulo) = Classificar(ex);
       var problema = new ProblemDetails
        {
            Status = status,
            Title = titulo,
            Detail = status == 500 ? "Ocorreu um erro interno no servidor." : ex.Message
        };

        context.Response.StatusCode = status;
        await context.Response.WriteAsJsonAsync(problema);
    }

    private static (int status, string titulo) Classificar(Exception ex)
    {
       
        if (ex is KeyNotFoundException)
            return (404, "Recurso não encontrado");
        if (ex is SaldoInsuficienteException)
            return (400, "Saldo insuficiente");
        return (500, "Erro interno do servidor");
    }
}