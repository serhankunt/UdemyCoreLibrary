using AspNetCoreRateLimit;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();//appsettings.json kullanabilmek için

builder.Services.AddMemoryCache();//Datalarý tutmak için 

//var Configuration = host.Services.GetRequiredService<IConfiguration>();
var Configuration = builder.Configuration;

//IP ADRESÝ
//builder.Services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
//builder.Services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
//builder.Services.AddSingleton<IIpPolicyStore,MemoryCacheIpPolicyStore>();

//CLIENT ID ÜZERÝNDEN
builder.Services.Configure<ClientRateLimitOptions>(Configuration.GetSection("ClientRateLimiting"));
builder.Services.Configure<ClientRateLimitPolicies>(Configuration.GetSection("ClientRateLimitPolicies"));
builder.Services.AddSingleton<IClientPolicyStore, MemoryCacheClientPolicyStore>();

builder.Services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSingleton<IRateLimitConfiguration,RateLimitConfiguration>();//Ana servis burasý

builder.Services.AddSingleton<IProcessingStrategy, AsyncKeyLockProcessingStrategy>(); // Register the processing strategy

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
//IP
//var IpPolicy = app.Services.GetRequiredService<IIpPolicyStore>();
//IpPolicy.SeedAsync().Wait();

//Client
var ClientPolicy = app.Services.GetRequiredService<IClientPolicyStore>();
ClientPolicy.SeedAsync().Wait();	

//app.UseIpRateLimiting();//Ip
app.UseClientRateLimiting();//Client

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
