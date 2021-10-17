# NoitificationAPI 

Este pacote tem como finalidade de auxiliar o BadRequest baseado na validação executado com fluentValidation gerando a sáida no formato de ProblemDetail.

## Requisito para uso
Para o uso adequado é necessário ter o FluentValidation instalado em seu projeto.

## Emplo de utilização
É necessário efetuar o registro na Startup.cs do projeto conforme exemplo abaixo. 

```
services.AddHttpContextAccessor();
services.AddScoped<IApiNotification, ApiNotification>();
```

Para executar o modo de validação, basta criar uma estância do seu validador que contém o seguinte código de exemplo.
```
public class MinhaClasseValidation : AbstractValidator<MinhaClasse>
    {
        public MinhaClasseValidation()
        {
            RuleFor(b => b.Nome).NotEmpty().WithMessage("Nome não pode estar em branco").WithErrorCode("2526");
            RuleFor(d => d.DataNascimento).NotEmpty().WithMessage("Erro na data de nascimento").LessThan(DateTime.Now).GreaterThan(DateTime.Now.AddYears(-130)).WithErrorCode("3310");
        }
    }
```
- Criando a estância da classe acima.

```
public class MeuServico
{
    private readonly IApiNotification _apiNotification;
     
    public MeuServico(IApiNotification apiNotification)
    {
      _apiNotification = apiNotification;
    }

    public void Handle(MinhaClasse entidade)
    {
        var validation = new MinhaClasseValidation().Validate(entidade);
        if (!validation.IsValid)
        {
            _apiNotification.AddProblemDetail(validation);
        }
        else
        {
            // Implementação
        }
    }

}
```

- Para finalizar, basta injetar na Controller a interface IApiNotification e IHttpContextAccessor
e retornar o BadRequest conforme abaixo:
```
[ApiController]
[Route("[controller]")]
public class MinhaController : ControllerBase
{
        private readonly IApiNotification _apiNotification;
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMeuServico _meuServico;

        public MinhaController(IApiNotification apiNotification, IHttpContextAccessor httpContext, IMeuServico meuServico)
        {
            _apiNotification = apiNotification;
            _httpContext = httpContext;
            _meuServico = meuServico;
        }

        [HttpPost]
        [ProducesResponseType(typeof(MinhaClasse), StatusCodes.Status200OK)]
        public async Task<ActionResult<MinhaClasse>> Banco(MinhaClasse entidade)
        {
            _meuServico.Handle(endidade); 
            if(__apiNotification.HasNotifications())
            {
             return BadRequest(_apiNotification.GetProblemDetail(_httpContext));
            }
            return Created("", banco);

        }

}
```