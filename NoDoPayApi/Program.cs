// using Microsoft.OpenApi.Models;
// using CoreLayer.Interfaces;
// using InfrastructureLayer;
// using InfrastructureLayer.Repositories;
// using NoDoPayApi;
// using CoreLayer.Entities;

// var builder = WebApplication.CreateBuilder(args);

// /*builder.WebHost.ConfigureKestrel(options =>
// {
//     options.ListenAnyIP(5000); // HTTP only on port 5000
//     // Remove or comment out HTTPS configuration if present
// });*/

// // Enable CORS (Cross-Origin Resource Sharing)
// var myAllowSpecificOrigins = "_myAllowSpecificOrigins";


// builder.Services.AddCors(options =>
// {
//     options.AddPolicy
//     (
//         myAllowSpecificOrigins,
//             policy =>
//             {
//                 policy.AllowAnyOrigin()
//                       .AllowAnyHeader()
//                       .AllowAnyMethod();
//             }
//      );
// });


// // Add session support
// builder.Services.AddDistributedMemoryCache();
// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromMinutes(30); // 30-minute session timeout
//     options.Cookie.HttpOnly = true;
//     options.Cookie.IsEssential = true;
// });

// // Register services and repositories
// builder.Services.AddInfrastructureDI(builder.Configuration);
// builder.Services.AddMainDI(builder.Configuration);
// builder.Services.AddScoped<IFaqRepository, FaqRepository>();
// builder.Services.AddScoped<IPoActivityLogRepository, PoActivityLogRepository>();
// builder.Services.AddScoped<IPoStatisticsMonthlyRepository, PoStatisticsMonthlyRepository>();
// builder.Services.AddScoped<IProductRepository, ProductRepository>();
// builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
// builder.Services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
// builder.Services.AddScoped<IRepaymentRepository, RepaymentRepository>();
// builder.Services.AddScoped<ISettingRepository, SettingRepository>();
// builder.Services.AddScoped<ISubUserRepository, SubUserRepository>();
// builder.Services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
// builder.Services.AddScoped<ISupportTicketLogRepository, SupportTicketLogRepository>();
// builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IVendorRepository, VendorRepository>();

// // Add controllers
// builder.Services.AddControllers();

// // Register Swagger (API Documentation)
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen(c =>
// {
//     c.SwaggerDoc("v1", new OpenApiInfo
//     {
//         Title = "NoDo Pay API",
//         Version = "v1",
//         Description = "API documentation for NoDO Pay",
//     });
// });

// // Build the app
// var app = builder.Build();

// // Enable Swagger only in development
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI(c =>
//     {
//         c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoDo Pay API v1");
//     });
// }

// // Enable CORS
// app.UseCors(myAllowSpecificOrigins);

// // Enable session management
// app.UseSession();
// app.UseStaticFiles(); // Enables serving static files

// app.UseHttpsRedirection();
// app.UseAuthorization();
// app.MapControllers();

// // Run the application
// app.Run();

using Microsoft.OpenApi.Models;
using CoreLayer.Interfaces;
using InfrastructureLayer;
using InfrastructureLayer.Repositories;
using InfrastructureLayer.Data;
using NoDoPayApi;
using CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure Kestrel for Railway deployment
builder.WebHost.ConfigureKestrel(options =>
{
    var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    options.ListenAnyIP(int.Parse(port)); // Listen on Railway's assigned port
});

// Enable CORS (Cross-Origin Resource Sharing)
var myAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy
    (
        myAllowSpecificOrigins,
            policy =>
            {
                policy.AllowAnyOrigin()
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            }
     );
});

// Add session support
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // 30-minute session timeout
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register services and repositories
builder.Services.AddInfrastructureDI(builder.Configuration);
builder.Services.AddMainDI(builder.Configuration);
builder.Services.AddScoped<IFaqRepository, FaqRepository>();
builder.Services.AddScoped<IPoActivityLogRepository, PoActivityLogRepository>();
builder.Services.AddScoped<IPoStatisticsMonthlyRepository, PoStatisticsMonthlyRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IPurchaseOrderRepository, PurchaseOrderRepository>();
builder.Services.AddScoped<IPurchaseOrderItemRepository, PurchaseOrderItemRepository>();
builder.Services.AddScoped<IRepaymentRepository, RepaymentRepository>();
builder.Services.AddScoped<ISettingRepository, SettingRepository>();
builder.Services.AddScoped<ISubUserRepository, SubUserRepository>();
builder.Services.AddScoped<ISupportTicketRepository, SupportTicketRepository>();
builder.Services.AddScoped<ISupportTicketLogRepository, SupportTicketLogRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IVendorRepository, VendorRepository>();

// Add controllers
builder.Services.AddControllers();

// Register Swagger (API Documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "NoDo Pay API",
        Version = "v1",
        Description = "API documentation for NoDO Pay",
    });
});

// Build the app
var app = builder.Build();

// Enable Swagger in both development and production for Railway
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "NoDo Pay API v1");
    c.RoutePrefix = "swagger"; // Access at /swagger
});

// Enable CORS
app.UseCors(myAllowSpecificOrigins);

// Enable session management
app.UseSession();
app.UseStaticFiles(); // Enables serving static files

// Remove HTTPS redirection - Railway handles HTTPS at the edge
// app.UseHttpsRedirection(); // Commented out for Railway

app.UseAuthorization();
app.MapControllers();

// Health check endpoint for Railway
app.MapGet("/health", () => "OK");

// Database health check
app.MapGet("/db-health", async (AppDbContext dbContext) =>
{
    try
    {
        await dbContext.Database.CanConnectAsync();
        return Results.Ok("Database connected successfully");
    }
    catch (Exception ex)
    {
        return Results.Problem($"Database connection failed: {ex.Message}");
    }
});

// Run the application
app.Run();