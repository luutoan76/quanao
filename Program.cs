using MongoDB.Driver;
using quanao.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin;


var builder = WebApplication.CreateBuilder(args);

string firebaseConfigPath = Path.Combine(builder.Environment.ContentRootPath, "Config", "quanaodata-ca88137675fa.json");
FirebaseApp.Create(new AppOptions
{
    Credential = GoogleCredential.FromFile(firebaseConfigPath),
});
// Add services to the container.
builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<CartService>();
builder.Services.AddScoped<FavourtieService>();
builder.Services.AddScoped<ReviewService>();
builder.Services.AddScoped<VoucherService>();
builder.Services.AddScoped<AdminService>();



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    option =>{
        option.SwaggerDoc("v1" , new OpenApiInfo{Title = "Quanao api" , Version = "v1" });
        option.AddSecurityDefinition("Bearer" , new OpenApiSecurityScheme{
            Description = "Enter token",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.ApiKey,
            Scheme = "Bearer"
        });
        option.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
        });
    }
);



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();

app.UseMiddleware<CustomJwtMiddleware>("A1B2C3D4E5F6G7H8I9J0K1L2M3N4O5P6Q7R8S9T0U1V2W3X4Y5Z6A7B8C9D0E1F2G3H4I5J6K7L8M9N0O1P2Q3R4S5T6U7V8W9X0Y1Z2A3B4C5D6E7F8G9H0I1J2K3L4M5N6O7P8Q9R0S1T2U3V4W5X6Y7Z8A9B0C1D2E3F4G5H6I7J8K9L0M1N2O3P4Q5R6S7T8U9V0W1X2Y3Z4A5B6C7D8E9F0G1H2I3J4K5L6M7N8O9P0Q1R2S3T4U5V6W7X8Y9Z0");

app.UseAuthorization();

app.MapControllers();

app.Run();
