using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using PokemonAccedo.Api.Data;
using PokemonAccedo.Api.RepositoriesHttp.Repositories;
using PokemonAccedo.Api.RepositoriesHttp.UnitOfWork;
using PokemonAccedo.Models.Account;
using PokemonAccedo.Models.Pokemons;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace PokemonAccedo.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }

        public IConfiguration Configuration { get; }

        public void ConfigfureServices(IServiceCollection Services)
        {
            Services.AddHttpClient("PokemonApi", x =>
            {
                x.BaseAddress = new Uri(Configuration["BaseUrlPokemon"]);
            });
            Services.AddHttpClient("VoidClient");

            Services.AddAutoMapper(typeof(Startup));
            Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["KeyJWT"])),
                    ClockSkew = TimeSpan.Zero
                };
            });
            

            Services.AddScoped<UnitContext>();
            Services.AddScoped<RepositoryGeneric<ListedPokemon>>();
            Services.AddScoped<RepositoryGeneric<FullPokemon>>();
            Services.AddDbContext<AplicationDbContext>(x =>
            {
                x.UseSqlServer(Configuration.GetConnectionString("defaultConnection"));
            });
            Services.AddIdentity<UserIdentity, IdentityRole>().AddEntityFrameworkStores<AplicationDbContext>();
            Services.AddControllers();
            Services.AddEndpointsApiExplorer();
            Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger V1", Version = "V1" });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });
        }


        public void ConfigureApp(IApplicationBuilder app, IHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(x =>
            {
                x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            

            app.UseEndpoints(x =>
            {
                x.MapControllers();
            });
        }
    }
}
