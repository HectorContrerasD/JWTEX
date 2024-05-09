using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
namespace Prueba.Helper

{
    public class JwtTokenGenerator
    {
        public string GetTokem(string nombre)
        {
            List<Claim> claims = new List<Claim>();
            if (nombre == "Juan") //dani, esto es a la mala, vamos a ver tambien como funciona con una base de datos
            {
                claims.Add(new Claim(ClaimTypes.Role, "User"));
            }
            else
            {
                claims.Add(new Claim(ClaimTypes.Role, "Admin"));
            }
            //un token debe durar maximo 20 mins, cada vez que expire un token tiene que generar otro para volver a tener acceso a los metodos
            //uno de las formas de manejar esto es un metodo que regenere un token o tener 2 tokens, uno con una duracion mucho mayor
            claims.Add(new Claim(ClaimTypes.Name, nombre));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iss, "saludos"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "prueba"));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Exp, DateTime.Now.AddMinutes(5).ToString()));
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var token = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Issuer= "saludos",
                Audience = "prueba" ,
                IssuedAt = DateTime.Now,
                NotBefore = DateTime.Now.AddMinutes(-1),
                Expires = DateTime.Now.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes("ESTAESMILLAVEDECIFRADODELTOKEN2024")), SecurityAlgorithms.HmacSha256)
            }; 
            return handler.CreateEncodedJwt(token);
        }
    }
}
