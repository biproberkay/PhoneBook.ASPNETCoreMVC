using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("SqliteConn");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString,b=>b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<UserAccount,IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    //options.ClaimsIdentity.
}).AddEntityFrameworkStores<ApplicationDbContext>();
// Add Role claims to the User object
// See: https://github.com/aspnet/Identity/issues/1813#issuecomment-420066501
builder.Services.AddScoped<IUserClaimsPrincipalFactory<UserAccount>, UserClaimsPrincipalFactory<UserAccount, IdentityRole>>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = new ApplicationDbContext(services.GetRequiredService<DbContextOptions<ApplicationDbContext>>());
    context.Database.Migrate();
    SeedData.Seed(services, context);
}
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
