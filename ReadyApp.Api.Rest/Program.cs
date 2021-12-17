using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using shoppingApp.Data.Data;
using shoppingApp.Data.IConfigeration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers( setUpAction => 
{
    setUpAction.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
.AddNewtonsoftJson(setUpAction =>
{
    setUpAction.SerializerSettings.ContractResolver =
    new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddDbContext<AppDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("ReadyAppDb"))
    .EnableSensitiveDataLogging()
    .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddApiVersioning(opt => {
    opt.ReportApiVersions = true;
    // Automatically provide default version
    opt.AssumeDefaultVersionWhenUnspecified = true;
    opt.DefaultApiVersion = ApiVersion.Default;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.SwaggerDoc("LibraryOpenAPISpecification", 
    new Microsoft.OpenApi.Models.OpenApiInfo()
    {
        Title = "Library API",
        Version = "1"
    });
    var xmlCommentFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlCommentFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentFile);
    setupAction.IncludeXmlComments(xmlCommentFullPath);
});
//swagger/LibraryOpenAPISpecification/swagger.json
var app = builder.Build();

app.UseRouting();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(setupAction =>
    {
        setupAction.SwaggerEndpoint("/swagger/LibraryOpenAPISpecification/swagger.json",
        "Library API");
        setupAction.RoutePrefix = "";
        
    });
}

app.UseHttpsRedirection();
// app.UseAuthorization();

app.MapControllers();

app.Run();
