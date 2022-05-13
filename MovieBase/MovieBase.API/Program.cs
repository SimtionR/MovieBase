using Azure.Storage.Blobs;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using MovieBase.API;
using MovieBase.Application.Queries;
using MovieBase.Core.Abstractions;
using MovieBase.Core.Models;
using MovieBase.Infrastructure;
using MovieBase.Infrastructure.Repositoriers;
using MovieBase.Infrastructure.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<MovieBaseDbContext>((DbContextOptionsBuilder options) =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//refactor auth
var appSettingsConfiguration = builder.Configuration.GetSection("ApplicationSettings");
builder.Services.Configure<ApplicationSettings>(appSettingsConfiguration);

var appSettings = appSettingsConfiguration.Get<ApplicationSettings>();
var key = Encoding.ASCII.GetBytes(appSettings.Secret);


var azureConnectionString = builder.Configuration.GetValue<string>("AzureBlobStorageConnectionString");
builder.Services.AddSingleton(x => new BlobServiceClient(azureConnectionString));



builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false

    };
});
   
// --- auth

builder.Services.AddIdentity<User, IdentityRole>(opt =>
{
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequiredLength = 6;
})
    .AddEntityFrameworkStores<MovieBaseDbContext>();
builder.Services.AddMediatR(typeof(GetAllMoviesQuery));
builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddTransient<IActorRepository, ActorRepository>();
builder.Services.AddTransient<IMovieRepository,MovieRepository>();
builder.Services.AddTransient<IGenreRepository, GenreRepository>();
builder.Services.AddTransient<IPersonalDetailsRepository, PersonalDetailsRepository>();
builder.Services.AddTransient<IMovieDetailsRepository, MovieDetailsRepository>();
builder.Services.AddTransient<IIdentityRepository, IdentityRepository>();
builder.Services.AddTransient<IProfileRepository, ProfileRepository>();
builder.Services.AddTransient<IUserReviewRepository, UserReviewRepository>();
builder.Services.AddScoped<IBlobStorageService, BlobStorageService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
  ;
}


app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyHeader()
.AllowAnyMethod());

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

});







app.MapControllers();

app.Run();
