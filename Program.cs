var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/test/{name}", (string name) => 
$"Hello World_! with {name}");
app.MapGet("/test/{name}/{lastname}", (string name, string lastname) =>
$"Hello World_! with {name} {lastname}");
app.MapGet("/bitcoin", async () =>
{
    HttpClient client = new HttpClient();
    var response = await client.GetAsync("https://randomuser.me/api/");
    response.EnsureSuccessStatusCode();
    string write = await response.Content.ReadAsStringAsync();
    return write;
});

app.Run();
