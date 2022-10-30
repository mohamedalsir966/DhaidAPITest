using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddIdentityServer()
        .AddInMemoryIdentityResources(InMemoryConfig.GetIdentityResources())
        .AddTestUsers(InMemoryConfig.GetUsers())
        .AddInMemoryClients(InMemoryConfig.GetClients())
        .AddDeveloperSigningCredential();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseIdentityServer();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
