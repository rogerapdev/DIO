var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<DIO.LocalizaLabsCovid.Data.MongoDB>();

builder.Services.AddControllers();

var app = builder.Build();


app.MapGet("/", () => "Hello World!");

app.MapControllers();
app.Run();
