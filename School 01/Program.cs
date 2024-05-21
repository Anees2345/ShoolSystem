using Microsoft.EntityFrameworkCore;
using School_01.Data;

var builder = WebApplication.CreateBuilder(args);
//Add db
builder.Services.AddDbContext<ApplicationDbContext>(Options => Options
.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add CORS policy
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowSpecificOrigin",
//        builder => builder.WithOrigins("http://localhost:7206")
//                          .AllowAnyMethod()
//                          .AllowAnyHeader());
//});
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
//app.UseCors("AllowSpecificOrigin");
app.UseAuthorization();

app.MapControllers();
app.UseCors(option=>option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()); 
app.Run();
