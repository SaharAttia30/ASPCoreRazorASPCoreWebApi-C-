var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors();          /////////////////  CORS
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
                            /////////////////  CORS to all Origin

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

//////// app.UseAuthorization();

app.MapControllers();

app.Run();
