using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Jwt bearer için konfigürasyon ayarlarý yazdým
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; 
    opt.TokenValidationParameters= new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost", //kim yayýnlýyor. Yayýncýsý kim
        ValidAudience = "http://localhost", //dinleyicisi kim
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aspnetcoreapiapi_supersecure_token_2025")), // eðer ki jwt içine gelen kullanýcý aspnetcoreapiapi keyine sahip olursa iþlemi gerçekleþtirir, yoksa gerçekleþtirmez
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true, // tokenýn geçerliliðini kontrol et
        ClockSkew = TimeSpan.Zero // tokenýn geçerlilik süresi dolduktan sonra 5 dakika bekleme süresini kaldýrdým
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
