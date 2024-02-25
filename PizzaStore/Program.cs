using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PizzaStore.Data;
using PizzaStore.Models;
using PizzaStore.Services;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PizzaStoreConString");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddAuthorization(options => {
    options.AddPolicy("PickupOrderOwnerOrStaffOrOwner", policyBuilder => policyBuilder.AddRequirements(
        new OrderOwnerOrStaffOrAdminRequirement())
    );
    options.AddPolicy("DeliveryOrderOwnerOrStaffOrOwner", policyBuilder => policyBuilder.AddRequirements(
        new OrderOwnerOrStaffOrAdminRequirement2())
    );
    options.AddPolicy("MinRankCustomer", policyBuilder => policyBuilder.AddRequirements(
        new MinRankRequirement(1))
    );
    options.AddPolicy("MinRankStaff", policyBuilder => policyBuilder.AddRequirements(
        new MinRankRequirement(2))
    );
    options.AddPolicy("MinRankAdmin", policyBuilder => policyBuilder.AddRequirements(
        new MinRankRequirement(3))
    );
});

builder.Services.AddScoped<IAuthorizationHandler, OrderOwnerOrStaffOrAdminHandler>();
builder.Services.AddScoped<IAuthorizationHandler, OrderOwnerOrStaffOrAdminHandler2>();
builder.Services.AddSingleton<IAuthorizationHandler, MinRankHandler>();

builder.Services.AddSession();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(60);
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var customerEmail = "customer@test.be";

    var existingCustomer = await userManager.FindByEmailAsync(customerEmail);

    if (existingCustomer == null)
    {
        var customerUser = new ApplicationUser
        {
            FirstName = "Customer",
            LastName = "User",
            UserName = customerEmail,
            Email = customerEmail,
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(customerUser, "Customer123!");

        if (createResult.Succeeded)
        {
            var claims = new[]
            {
                new Claim("RankId", "1")
            };

            await userManager.AddClaimsAsync(customerUser, claims);
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var customerEmail = "staff@test.be";

    var existingCustomer = await userManager.FindByEmailAsync(customerEmail);

    if (existingCustomer == null)
    {
        var staffUser = new ApplicationUser
        {
            FirstName = "Staff",
            LastName = "User",
            UserName = customerEmail,
            Email = customerEmail,
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(staffUser, "Staff123!");

        if (createResult.Succeeded)
        {
            var claims = new[]
            {
                new Claim("RankId", "2")
            };

            await userManager.AddClaimsAsync(staffUser, claims);
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var customerEmail = "admin@test.be";

    var existingCustomer = await userManager.FindByEmailAsync(customerEmail);

    if (existingCustomer == null)
    {
        var staffUser = new ApplicationUser
        {
            FirstName = "Admin",
            LastName = "User",
            UserName = customerEmail,
            Email = customerEmail,
            EmailConfirmed = true
        };

        var createResult = await userManager.CreateAsync(staffUser, "Admin123!");

        if (createResult.Succeeded)
        {
            var claims = new[]
            {
                new Claim("RankId", "3")
            };

            await userManager.AddClaimsAsync(staffUser, claims);
        }
    }
}

// Configure the HTTP request pipeline.
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
app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
