using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Purrrfect_Cats.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); HAD TO COMMENT THIS OUT BECAUSE IT WAS SET TO THE DEFAULT PROVIDED INITIALLY. IT WAS COMNNECTING TO SQL SERVER STRING PROVIDED AS DEFAULT. Had to provide an alternative connection string below that connects to MySql Server Version declared below too

var connectionString = "server=localhost;user=catfinder2023;password=catfinder2023;database=catfinder";
var serverVersion = new MySqlServerVersion(new Version(8, 0, 32));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSQLServer(connectionString)); CHANGED TO 'UseMySql' from SQL server and added "serverVersion" in order to connect with the serverVersion variable provided initialized and declared above.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


//NOTES:
//OTHER AREAS THAT WERE CONFIGURED:
//-ADDED nugget packages to connect to MySql,
//-DELETED the migration that was provided and built a new one based on the schema in MySql Workbench.
