using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Auth API", Version = "v1" });
});
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/v1/swagger.json", "Auth API V1"));
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
