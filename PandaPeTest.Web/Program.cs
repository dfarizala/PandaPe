var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient("CreateApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:Create"]); });
builder.Services.AddHttpClient("GetApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:Get"]); });
builder.Services.AddHttpClient("EditApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:Edit"]); });
builder.Services.AddHttpClient("UpdateCandidateApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:UpdateCandidate"]); });
builder.Services.AddHttpClient("DeleteCandidateApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:DeleteCandidate"]); });
builder.Services.AddHttpClient("DeleteExperienceApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:DeleteExperience"]); });
builder.Services.AddHttpClient("DeleteExperienceByIdApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:DeleteExperienceById"]); });
builder.Services.AddHttpClient("GetExperienceApi", config => { config.BaseAddress = new Uri(builder.Configuration["ServicesURL:GetExperience"]); });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
