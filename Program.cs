using Logic;
using Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMemoryCache();

// Add services to the container.

builder.Services.AddCors(p => p.AddPolicy("corsapp", builder =>
    {
        builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
    })
);
builder.Services.AddControllersWithViews();
builder.Services.AddControllers().AddNewtonsoftJson();
builder.Services.AddScoped<INewsSvc, Services.NewsSvc>();
builder.Services.AddScoped<ITrendSvc, Services.TrendSvc>();
builder.Services.AddScoped<ISummarizationSvc, Services.SummarizationSvc>();
builder.Services.AddScoped<ILogicLayer, LogicLayer>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors("corsapp");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller}");
app.UseEndpoints(ep => { ep.MapControllers(); });

app.MapFallbackToFile("index.html");

app.Run();

