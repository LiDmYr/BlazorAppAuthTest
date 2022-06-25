using BlazorAppAuthTest.Areas.Identity;
using BlazorAppAuthTest.CustomAuntAuth;
using BlazorAppAuthTest.DAL;
using BlazorAppAuthTest.DAL.Repository;
using BlazorAppAuthTest.Data;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

////AddIdentity
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//   .AddDefaultTokenProviders();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddUserStore<LiteDbUserStore>()
    .AddRoles<IdentityRole>()
    .AddRoleStore<LiteDbRoleStore>();
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddUserStore<LiteDbUserStore>()
//    .AddRoleStore<LiteDbRoleStore>();

//builder.Services.AddTransient<IUserStore<IdentityUser>, LiteDbUserStore>();
builder.Services.AddTransient<IUserRoleStore<IdentityUser>, LiteDbUserStore>();
//builder.Services.AddTransient<IRoleStore<IdentityRole>, LiteDbRoleStore>();

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

//TODO move to extension
{
    builder.Services.AddSingleton<IUserRepository, LiteDbUserRepository>();
    builder.Services.AddSingleton<ILiteDbRepository, LiteDbRepository>();
    builder.Services.AddSingleton<IRoleRepository, LiteDbRoleRepository>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
