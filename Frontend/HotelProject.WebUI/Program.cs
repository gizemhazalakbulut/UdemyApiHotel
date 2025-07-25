using FluentValidation;
using FluentValidation.AspNetCore;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.GuestDto;
using HotelProject.WebUI.ValidationRules.GuestValidationRules;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();

builder.Services.AddHttpClient();




// DataAnnotations (Required vb.) otomatik hata mesajlarını kapat
builder.Services.AddControllersWithViews(options =>
{
    options.ModelMetadataDetailsProviders.Clear();
});

// FluentValidation entegrasyonu
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CreateGuestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateGuestValidator>();

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
