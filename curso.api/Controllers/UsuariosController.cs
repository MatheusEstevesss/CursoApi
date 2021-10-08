using curso.api.Configuration;
using curso.api.Domain.Entities;
using curso.api.Domain.Interfaces;
using curso.api.Filters;
using curso.api.Models;
using curso.api.Models.Usuarios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Swashbuckle.AspNetCore.Annotations;

namespace curso.api.Controllers
{
    [Route("api/v1/{Controller}")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        
        private readonly IAuthenticationService _authenticationService;
        public UsuariosController(IUsuarioRepository usuarioRepository, IAuthenticationService authenticationService)
        {
            _usuarioRepository = usuarioRepository;
            _authenticationService = authenticationService;
        }

        [SwaggerResponse(statusCode: 200, description: "Sucesso ao autenticar", type: typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description: "Campos Obrigatórios", type: typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description: "Server Error", type: typeof(ErroGenericoViewModel))]

        [HttpPost]
        [Route("logar")]
        [ValidacaoModelState]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            var usuario = _usuarioRepository.ObterUsuario(loginViewModelInput.Login);

            if (usuario == null)
            {
                return BadRequest("Houve um erro ao tentar acessar");
            }

            /*if (usuario.Senha != loginViewModelInput.Senha.GerarSenhaCriptografada())
            {
                return BadRequest("Houve um erro ao tentar acessar");
            }*/

            var usuarioViewModelOutPut = new UsuarioViewModelOutput()
            {
                Codigo = usuario.Codigo,
                Login = loginViewModelInput.Login,
                Email = usuario.Email
            };

            var token = _authenticationService.GerarToken(usuarioViewModelOutPut);

            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutPut
            });
        }

        [HttpPost]
        [Route("registrar")]
        [ValidacaoModelState]
        public IActionResult Registrar(RegistroViewModel registroViewModel)
        {
            /*var migrations = context.Database.GetPendingMigrations();

            if (migrations.Count() > 0)
            {
                context.Database.Migrate();
            }*/

            var usuario = new Usuario();
            usuario.Login = registroViewModel.Login;
            usuario.Senha = registroViewModel.Email;
            usuario.Email = registroViewModel.Email;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();


            return Created("", registroViewModel);
        }
    }
}