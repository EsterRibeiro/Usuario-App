using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UsuariosApp.API.Services;

public static class JwtBearerService
{
    #region Atributos

    public static string SecretKey => "4762D8C8-80DE-4353-ABC2-FCC8BB1FDDD8";
    public static int ExpirationInHours => 1;

    #endregion

    public static string GenerateToken(Guid usuarioid)
    {
        //criando os parâmetros para geração do token
        var jwtSecurityToken = new JwtSecurityToken(
            claims: CreateClaims(usuarioid), //dados do usuário que será gravado no token
            signingCredentials: CreateCredentials(), //assinatura do token (chave criptografada)
            expires: CreateExpiration() //tempo de expiração do token
         );
        //gerar token
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(jwtSecurityToken);

    }


    /// <summary>
    /// método para gerar a data e hora de expiração do token
    /// </summary>
    /// <returns></returns>
    private static DateTime? CreateExpiration()
    {
        return DateTime.Now.AddHours(Convert.ToDouble(ExpirationInHours));
    }

    /// <summary>
    /// Método para gerar chave secreta (criptografada) do token
    /// </summary>
    /// <returns></returns>
    private static SigningCredentials? CreateCredentials()
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
        return new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    }

    /// <summary>
    /// Método para gravar a identificação do usuário no TOKEN
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    private static Claim[] CreateClaims(Guid usuarioId)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, usuarioId.ToString())
        };

        return claims;
    }
}
