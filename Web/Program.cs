using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Service;
using Service.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Camada de serviço
builder.Services.AddScoped<IAmigoService, AmigoService>();

//DbConenection
builder.Services.AddDbContext<AmigoDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AmigosDB")
));


//Setup Session
builder.Services.AddSession(options =>
options.Cookie.Name = "Amigos_selecionados");



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//sessão
app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
