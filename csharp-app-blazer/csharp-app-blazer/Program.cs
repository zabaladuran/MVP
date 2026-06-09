using csharp_app_blazer.Components;
using csharp_app_blazer.Data;
using csharp_app_blazer.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<DbConnectionFactory>();
builder.Services.AddScoped<IRegistroService, RegistroService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IDashboardService, DashboardService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IAuthAdminService, AuthAdminService>();
builder.Services.AddScoped<IAdminDashboardService, AdminDashboardService>();

builder.Services.AddSingleton<TokenStore>();
builder.Services.AddScoped<AuthStateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

if (!app.Environment.IsEnvironment("Container"))
{
    app.UseHttpsRedirection();
}

// Configure static files with caching headers for PWA
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        var path = ctx.File.Name;
        
        // Cache service-worker permanently but with version check
        if (path.EndsWith("service-worker.js", StringComparison.OrdinalIgnoreCase))
        {
            ctx.Context.Response.Headers.CacheControl = "public, max-age=0, must-revalidate";
        }
        // Cache manifest.json with no cache - always revalidate
        else if (path.EndsWith("manifest.json", StringComparison.OrdinalIgnoreCase))
        {
            ctx.Context.Response.Headers.CacheControl = "public, max-age=0, must-revalidate";
        }
        // Cache app.js with medium expiry
        else if (path.EndsWith("app.js", StringComparison.OrdinalIgnoreCase))
        {
            ctx.Context.Response.Headers.CacheControl = "public, max-age=86400";
        }
        // Cache static assets (CSS, JS, images) long-term
        else if (path.EndsWith(".css", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".js", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".svg", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".woff", StringComparison.OrdinalIgnoreCase) ||
                 path.EndsWith(".woff2", StringComparison.OrdinalIgnoreCase))
        {
            ctx.Context.Response.Headers.CacheControl = "public, max-age=31536000, immutable";
        }
    }
});

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
