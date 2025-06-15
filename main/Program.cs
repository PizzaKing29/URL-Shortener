var builder = WebApplication.CreateBuilder(args);


builder.WebHost.UseUrls("http://localhost:5000");

builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();

app.Run();