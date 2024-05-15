using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidationApp.Web.FluentValidators;
using FluentValidationApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});

//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CustomerValidator>());

//builder.Services.AddControllersWithViews()
//    .AddFluentValidationAutoValidation()
//    .AddFluentValidationClientsideAdapters();

//builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
//----------------------------------------------------------
//builder.Services.AddControllersWithViews()
//    .AddFluentValidation(configuration =>
//    {
//        configuration.RegisterValidatorsFromAssemblyContaining<CustomerValidator>();
//    });


#region Fluent Validation çalýþan 1
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();
//builder.Services.AddValidatorsFromAssemblyContaining<CustomerValidator>();
#endregion
#region Fluent Validation Çalýþan 2
//builder.Services.AddSingleton<IValidator<Customer>, CustomerValidator>();
//builder.Services.AddFluentValidationAutoValidation(options => options.DisableDataAnnotationsValidation = true);
//builder.Services.AddControllersWithViews();
//builder.Services.AddFluentValidationClientsideAdapters();
#endregion

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


#region Fluent validation çalýþan3
//builder.Services.AddValidatorsFromAssembly(typeof(CustomerValidator).Assembly);
//builder.Services.AddFluentValidationAutoValidation();
//builder.Services.AddFluentValidationClientsideAdapters();
#endregion


builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
