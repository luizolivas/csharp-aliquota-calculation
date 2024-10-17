using Aliquota.Domain.Repository;
using Aliquota.Domain.Services.ClienteService;
using Aliquota.Domain.Services.ClienteService.Contract;
using Aliquota.Domain.Services.MovimentacaoService;
using Aliquota.Domain.Services.MovimentacaoService.Contracts;
using Aliquota.Domain.Services.ProdutoFinanceiroService;
using Aliquota.Domain.Services.ProdutoFinanceiroService.Contract;
using Aliquota.Domain.Webapp.Context;
using Aliquota.Domain.Webapp.Repository;
using Aliquota.Domain.Webapp.Services;
using Aliquota.Domain.Webapp.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped<IProdutoFinaneiroRepository, ProdutoFinanceiroRepository>();
builder.Services.AddScoped<IProdutoFinanceiroService, ProdutoFinanceiroService>();
builder.Services.AddScoped<IClienteRepositoy, ClienteRepository>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IClienteServiceFront,ClienteServiceFront>();
builder.Services.AddScoped<IMovimentacaoRepository, MovimentacaoRepository>();
builder.Services.AddScoped<IMovimentacaoService, MovimentacaoService>();
builder.Services.AddSingleton<IValidaMovimentacao, ValidaMovimentacao>();

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
