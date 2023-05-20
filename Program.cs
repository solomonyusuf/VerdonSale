using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VerdonSale.Areas.Identity;
using VerdonSale.Data;
using VerdonSale.Models;
using VerdonSale.Seeders;
using VerdonSale.Service;
using VerdonSale.Services;
using VerdonSale.Settings;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
var connectionString = "Filename=verdon.sqlite3";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDbContext<WalletDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDbContext<SalesDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDbContext<LoggerDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<AppUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddDefaultTokenProviders()
    .AddDefaultUI()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<AppUser>>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});
builder.Services.AddBootstrapComponents();
builder.Services.AddBlazorBootstrap();
builder.Services.AddSession();
builder.Services.AddScoped<UserManager<AppUser>>();
builder.Services.AddScoped<RoleManager<IdentityRole>>();

// register system services
builder.Services.AddTransient<RequestLoggerService>();
builder.Services.AddScoped<StaticFileSeeder>();
builder.Services.AddTransient<UploadService>();
builder.Services.AddTransient<MailService>();
builder.Services.AddTransient<MailSettings>();

var app = builder.Build();

//seed models & static folder to database & server
using (var scope = app.Services.CreateScope())
{
    scope.ServiceProvider.GetRequiredService<StaticFileSeeder>().SeedFolder();
    //var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    UserAndRoleSeeder.SeedData(userManager, roleManager);
    // BankSeeder.SeedBanks(db);

}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "StaticFiles")),
    RequestPath = new PathString("/wwwroot/StaticFiles"),
    ServeUnknownFileTypes = true,
});
app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseSession();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();