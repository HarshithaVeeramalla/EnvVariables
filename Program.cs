var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Environment.SetEnvironmentVariable("DATABASE_CONNECTION_STRING", "SampleConn");

var app = builder.Build();
try
{
    var connString = Environment.GetEnvironmentVariable("DATABASE_CONNECTION_STRING");
    if (string.IsNullOrEmpty(connString))
    {
        throw new Exception("A variável de ambiente DATABASE_CONNECTION_STRING não está definida.");
    }
    else
    {
        Console.WriteLine(connString + " Program");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}

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
