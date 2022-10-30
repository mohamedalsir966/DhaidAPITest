using CustomerPortal.Service.RequestService;
using IdentityServer4.AccessTokenValidation;
using Infrastructure.Extension;
using Microsoft.IdentityModel.Tokens;
using Service;
using System.Text.Json.Serialization;
using static Org.BouncyCastle.Math.EC.ECCurve;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers().AddJsonOptions(options =>
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext(builder.Configuration);
        builder.Services.AddScopedServices();
        #region her we add Mediator piplin and mapin profile DependencyInjection
        #endregion

        builder.Services.AddServiceLayer();
        //builder.Services.AddAuthentication("Bearer")
        //               .AddIdentityServerAuthentication(options =>
        //               {
        //                   options.Authority = "http://host.docker.internal:4004";
        //                   options.RequireHttpsMetadata = false;
        //                   options.ApiName = "customer";

        //               });


        builder.Services.AddOptions<InspectorServiceOptions>()
            .Configure(ro =>
            {
                ro.BaseUri = builder.Configuration.GetValue<string>("ServiceUris:InspectorService");
            });
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        //medilwarepipline
        app.ConfigureCustomExceptionMiddleware();


       // app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}