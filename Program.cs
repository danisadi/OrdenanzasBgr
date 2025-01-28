using ProyectoPrincipal.Datos;
//using DotNetEnv; ////Configuracion para archivo .Env
//using Microsoft.EntityFrameworkCore; ////Paquete de conexion

var builder = WebApplication.CreateBuilder(args);


//INICIO AUMENTO DE CODIGO PARA CONEXION BDD SQL

//DotNetEnv.Env.Load();////nuevo codigo
////Configuracion de la conexion a base de datos desde .env
var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");
if(string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("La cadena de conexión  no esta configurada");
}
////Registrar servicios
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

////FIN AUMENTO DE CODIGO PARA CONEXION BDD SQL

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

app.MapControllers(); //codigo aumentado para conexion sql
app.Run();