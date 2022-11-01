﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TestApiJwt.Model;
using TestApiJwt.services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

///////////////////////////////////////////////////////////////////////////////////////////////to use configration
IConfiguration Configuration = app.Configuration;

/////////////////////////////////////////////////////////////////////////////////////////////////////////////
//to map alues of key in appsetting with value of class JWT(in helper) 
builder.Configuration.GetSection("JWT");
//??? ????? ??? ?????? adintity 
builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBcontext>();
//add connection string
builder.Services.AddDbContext<ApplicationDBcontext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );
//to use service in controller
builder.Services.AddScoped<IuthoService, AuthService>();

//defult conf of jwt 
builder.Services.AddAuthentication(options =>
{
    //ع مش كل مرة تعمل فوق كل (end point autorize and give it bearer)  
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(o =>
    {
        o.RequireHttpsMetadata = false;
        o.SaveToken = false;

        //to use validation of key
        o.TokenValidationParameters = new TokenValidationParameters
        {

            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = Configuration["JWT:Issuer"],
            ValidAudience = Configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:Key"])) 
        };
    });

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//////////////////////////////////////////////////////////////////////////////////////
// to use authonticaton of identity
app.UseAuthentication();


app.UseAuthorization();

app.MapControllers();

app.Run();
