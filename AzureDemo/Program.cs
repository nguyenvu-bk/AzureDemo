using Microsoft.AspNetCore.SpaServices.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddRazorPages();
builder.Services.AddSpaStaticFiles(config =>
{
    config.RootPath = "dist";
});

builder.Services.AddAuthorization();
builder.Services.AddAuthentication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

if (builder.Configuration.GetValue<bool>("IsDevelopment"))
{
    app.UseSpa(spa =>
    {
        spa.UseProxyToSpaDevelopmentServer(builder.Configuration.GetValue<string>("NGServe:Host"));
    });
}
else
{
    app.UseSpaStaticFiles();

    app.UseSpa(spa =>
    {
        spa.Options.SourcePath = "dist";
    });
}
//app.MapRazorPages();

app.Run();
