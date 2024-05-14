using System.Diagnostics.SymbolStore;

namespace NoticiasApi.Models.Dtos
{
    public class LoginDTO
    {
        public string? Usuario { get; set; }   
        public string? Contrasena { get; set; }
    }
}
