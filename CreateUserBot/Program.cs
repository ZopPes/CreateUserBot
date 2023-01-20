// See https://aka.ms/new-console-template for more information
using WTelegram;

Console.WriteLine("api_id и api_hash можно получить на сайте: https://my.telegram.org/auth?to=apps");
Console.WriteLine("api_id:");
string? api_id = Console.ReadLine();
Console.WriteLine("api_hash:");
string? api_hash = Console.ReadLine();
Console.WriteLine("phone:");
string? phone = Console.ReadLine();
var client = new Client(Config(phone,api_id,api_hash), new FileStream($"{phone}.session", FileMode.Create, FileAccess.ReadWrite));

await client.LoginUserIfNeeded(reloginOnFailedResume: false);

string TerminalURL(string caption, string url) => $"\u001B]8;;{url}\a{caption}\u001B]8;;\a";

Func<string, string?> Config(string phone,string api_id,string api_hash) => what =>
{
    switch (what)
    {
        case "api_id": return api_id;
        case "api_hash": return api_hash;
        case "phone_number": return phone;
        case "verification_code":
            {
                Console.WriteLine("code:");
                string? code = Console.ReadLine();
                return code;
            }
        default: return null;
    }
};
