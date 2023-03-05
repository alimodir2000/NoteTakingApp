namespace IdentityServer;

public partial class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var config = builder.Configuration;

        builder.Services.AddIdentityServer()
            .AddDeveloperSigningCredential()
            .AddInMemoryApiScopes(Config.GetAllScopes())
            .AddInMemoryClients(Config.GetAllApiClients());

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.UseIdentityServer();

        app.Run();
    }
}
