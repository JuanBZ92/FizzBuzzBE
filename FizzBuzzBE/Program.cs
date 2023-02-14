using FizzBuzz.Extensions;

var builder = WebApplication.CreateBuilder(args);

const string MyCorsPolicyName = "AllowMyOrigin";
string[] Origins = { "domain", "http://localhost:4200", "https://localhost:7039" };

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        MyCorsPolicyName,
        builder =>
        {
            builder.WithOrigins(Origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowedToAllowWildcardSubdomains();
        });
});
// Add services for DI.
builder.Services.AddServices();

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

app.UseCors(MyCorsPolicyName);

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
