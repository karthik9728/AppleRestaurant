using Apple.Web;
using Apple.Web.Services;
using Apple.Web.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region HttpClient Service

//Add Service for Product Service
builder.Services.AddHttpClient<IProductService,ProductService>();

#endregion

#region SD Url

var connectionString = builder.Configuration["ServiceUrl:ProductAPI"];
var connectionStringIdentity = builder.Configuration["ServiceUrl:IdentityAPI"];

SD.ProductAPIBase = connectionString;

#endregion

#region DI Service

builder.Services.AddScoped<IProductService,ProductService>();

#endregion

#region 

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme="Cookies";
    options.DefaultChallengeScheme = "oidc";
}).AddCookie("Cookies",c=>c.ExpireTimeSpan=TimeSpan.FromMinutes(10))
.AddOpenIdConnect("oidc", options =>
{
    options.Authority = connectionStringIdentity;
    options.GetClaimsFromUserInfoEndpoint = true;
    options.ClientId = "apple";
    options.ClientSecret = "secret";
    options.ResponseType = "code";
    options.TokenValidationParameters.NameClaimType = "name";
    options.TokenValidationParameters.RoleClaimType = "role";
    options.Scope.Add("apple");
    options.SaveTokens = true;
});

#endregion

//builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
