using BlazorLogin.Model;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Linq;

namespace BlazorLogin.Service
{
    public class UsuarioService
    {

        private readonly UserManager<Usuario> _userManager;

        public UsuarioService(UserManager<Usuario> userManger)
        {
            _userManager = userManger;
        }

        public async Task<Usuario> Create(Usuario usuario, string senha, CancellationToken cancellationToken = default)
        {
            try
            {
                Usuario? usuarioJaExistente = await _userManager.FindByEmailAsync(_userManager.NormalizeEmail(usuario.Email));
                if (usuarioJaExistente != null)
                {
                   throw new Exception("Já existe um usuário com esse email.");
                }

                var validadorSenha = new PasswordValidator<Usuario>();
                var resultadoValidacaoSenha = await validadorSenha.ValidateAsync(_userManager, null, senha);

                if (!resultadoValidacaoSenha.Succeeded)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (var item in resultadoValidacaoSenha.Errors)
                    {
                        sb.Append(item.Description);
                    }
                    throw new Exception(sb.ToString());
                }
                IdentityResult resultado = await _userManager.CreateAsync(usuario, senha);
                if (resultado.Succeeded)
                {
                    return usuario;

                }
                throw new Exception("Erro genérico");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro genérico");
            }
        }
    }
}
