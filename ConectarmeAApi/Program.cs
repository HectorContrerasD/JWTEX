
//intentar conectarnos a una api que estará corriendo
HttpClient client = new HttpClient()
{
    BaseAddress = new Uri("https://localhost:7119/")
};
Console.WriteLine("usuario:");
string username = Console.ReadLine()??""; //pide el username y la contraseña
Console.WriteLine("pass:");
string password = Console.ReadLine() ?? "";
var response = client.PostAsync($"api/login?username={username}&password={password}",  null).Result; //es por querystring porque no hay un dto, deberia ser por un dto
var token = response.Content.ReadAsStringAsync().Result;
Console.WriteLine(token);
HttpRequestMessage rm = new();
rm.RequestUri = new Uri(client.BaseAddress +"api/saludos");
rm.Method = HttpMethod.Get;
rm.Headers.Add("Authorizacion", $"Bearer:{token}");
var resp = client.SendAsync(rm).Result;
if (resp.StatusCode == System.Net.HttpStatusCode.Forbidden)
{
    Console.WriteLine("acceso denegado");
}
else
{

var saludo = resp.Content.ReadAsStringAsync().Result;
    Console.WriteLine(saludo);
}
Console.ReadLine();