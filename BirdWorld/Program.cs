using AutoMapper;
using BirdWorld.Config;
using BirdWorld.DataAcess;
using BirdWorld.Models;
using BirdWorld.Services.AppServices.AppUserService;
using BirdWorld.Services.AppServices.BirdService;
using BirdWorld.Services.AppServices.CommentService;
using BirdWorld.Services.AppServices.PostService;
using BirdWorld.Services.Profiles;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        DotNetEnv.Env.Load();

        var builder = WebApplication.CreateBuilder(args);

        
        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddDbContext<AppDbContext>();
        builder.Services.AddIdentity<AppUser, IdentityRole>(
            options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;

            })
            .AddEntityFrameworkStores<AppDbContext>();


        builder.Services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = JwtConfig.Issuer,
                ValidateAudience = true,
                ValidAudience = JwtConfig.Audience,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConfig.Secrete_Key))
            };
        });

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new AppUserProfile());
            mc.AddProfile(new PostProfile());
            mc.AddProfile(new CommentProfile());
            mc.AddProfile(new BirdProfile());
            mc.AddProfile(new PostLikeProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        builder.Services.AddSingleton(mapper);
        builder.Services.AddScoped<IPostRepository,PostService>();
        builder.Services.AddScoped<IAppUserRepository, AppUserService>();
        builder.Services.AddScoped<ICommentRepository, CommentService>();
        builder.Services.AddScoped<IBirdRepository, BirdService>();
  


        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
             app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        app.UseSwagger();


        app.UseSwaggerUI(
            c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Employee API V1");
            c.RoutePrefix = string.Empty;
        }
        );
        app.Run();


    }
}