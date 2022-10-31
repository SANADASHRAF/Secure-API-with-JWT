using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TestApiJwt.Model;

var builder = WebApplication.CreateBuilder(args);

/////////////////////////////////////////////////////////////////////////////////////////
//to map alues of key in appsetting with value of class JWT(in helper) 
builder.Configuration.GetSection("JWT");
//??? ????? ??? ?????? adintity 
builder.Services.AddIdentity<Applicationuser, IdentityRole>().AddEntityFrameworkStores<ApplicationDBcontext>();
//add connection string
builder.Services.AddDbContext<ApplicationDBcontext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
 );

//////////////////////////////////////////////////////////////////////////////////////////////



// Add services to the container.

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
