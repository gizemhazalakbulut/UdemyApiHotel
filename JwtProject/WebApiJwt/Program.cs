using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Jwt bearer i�in konfig�rasyon ayarlar� yazd�m
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.RequireHttpsMetadata = false; 
    opt.TokenValidationParameters= new TokenValidationParameters()
    {
        ValidIssuer = "http://localhost", //kim yay�nl�yor. Yay�nc�s� kim
        ValidAudience = "http://localhost", //dinleyicisi kim
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("aspnetcoreapiapi_supersecure_token_2025")), // e�er ki jwt i�ine gelen kullan�c� aspnetcoreapiapi keyine sahip olursa i�lemi ger�ekle�tirir, yoksa ger�ekle�tirmez
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true, // token�n ge�erlili�ini kontrol et
        ClockSkew = TimeSpan.Zero // token�n ge�erlilik s�resi dolduktan sonra 5 dakika bekleme s�resini kald�rd�m
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
