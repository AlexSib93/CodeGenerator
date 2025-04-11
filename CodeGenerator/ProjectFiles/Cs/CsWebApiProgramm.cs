using CodeGenerator.Interfaces;
using CodeGenerator.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.ProjectFiles.Cs
{
    public class CsWebApiProgramm : IGenerator
    {
        public string Name { get; set; }
        public ProjectMetadata Project { get; set; }
        public CsWebApiProgramm(ProjectMetadata proj)
        {
            Project = proj;
        }

        public string Header => $@"using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Swashbuckle.AspNetCore.Filters;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using TerminalApi;
using BuisinessLogicLayer.Services;
using DataAccessLayer.Data;";
        public string Body => $@"

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

    string MyAllowSpecificOrigins = ""_myAllowSpecificOrigins"";

builder.Services.AddCors(options =>
{{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {{
            builder.WithOrigins(""https://localhost:3000"", ""*"")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        }});
}});
builder.Services.AddControllers();
builder.Services.AddDbContext<DataBaseContext>(options =>
{{
    options.UseSqlServer(builder.Configuration.GetConnectionString(""DefaultConnection""));
}});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{{
    options.AddSecurityDefinition(""oauth2"", new OpenApiSecurityScheme
    {{
        Description = ""Standart Authorization header using Bearer scheme (\""bearer {{token}}\"")"",
        In = ParameterLocation.Header,
        Name = ""Authorization"",
        Type = SecuritySchemeType.ApiKey
    }});

    options.OperationFilter<SecurityRequirementsOperationFilter>();
}});
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt =>
    {{
        opt.TokenValidationParameters = new TokenValidationParameters
        {{
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration.GetSection(""Appsettings:Token"").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        }};
    }});
{InjectDependencyText()}

builder.Services.AddHttpContextAccessor();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{{
    app.UseSwagger();
    app.UseSwaggerUI();
}}

MapsterConfig.AddMaps();

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

";

        private string InjectDependencyText()
        {
            string res = $@"
builder.Services
    .AddScoped<IUserService, UserService>()
    .AddScoped<IUnitOfWork, {Project.UnitOfWork}>(){GetServicesInjection()};";

            return res;
        }

        private string GetServicesInjection()
        {
            IEnumerable<string> depArray = Project.Models.Select(m => $@"{Environment.NewLine}    .AddScoped<I{m.Name}Service, {m.Name}Service>()");
            return string.Join("", depArray);
        }

        public string Gen()
        {
            return $"{Header}\n\n{Body}";
        }
    }

}

