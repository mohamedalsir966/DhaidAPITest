using IdentityServer4.AccessTokenValidation;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration).AddConsul();


Action<IdentityServerAuthenticationOptions> customerClient = option =>
{
    option.Authority = "http://host.docker.internal:4001";
    option.RequireHttpsMetadata = false;
    option.SupportedTokens = SupportedTokens.Both;
    option.ApiName = "customer";
    option.ApiSecret = "customersecret";
};

Action<IdentityServerAuthenticationOptions> inspectorClient = option =>
{
    option.Authority = "http://host.docker.internal:4002";
    option.RequireHttpsMetadata = false;
    option.SupportedTokens = SupportedTokens.Both;
    option.ApiName = "inspector";
    option.ApiSecret = "inspectorsecret";
};

builder.Services.AddAuthentication()
    .AddIdentityServerAuthentication("customerIdentityKey", customerClient)
    .AddIdentityServerAuthentication("inspectorIdentityKey", inspectorClient);


var app = builder.Build();
if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
app.UseRouting();
app.UseEndpoints(endpoints => endpoints.MapGet("/", async context => await context.Response.WriteAsync("API Gateway is up and running !")));
app.UseHttpsRedirection();
await app.UseOcelot();

app.Run();

