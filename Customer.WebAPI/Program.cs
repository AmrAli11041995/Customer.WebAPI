using AutoMapper;
using Customer.Infrastructure.DBContext;
using Customer.Infrastructure.MappingProfile;
using Customer.WebAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<AppDBContext>();
builder.Services.RegisterAppRepositories();
builder.Services.RegisterAppServices();
builder.Services.AddControllers();
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

#region Mapping
var config = new MapperConfiguration(cfg => {
    cfg.AddProfile(new CustomerProfile());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);
#endregion

var app = builder.Build();

app.ConfigerSwagger();

app.UseAuthorization();

app.MapControllers();
app.UseCors(x => x
             .AllowAnyMethod()
             .AllowAnyHeader()
             .SetIsOriginAllowed(origin => true) // allow any origin
             .AllowCredentials());

app.Run();
