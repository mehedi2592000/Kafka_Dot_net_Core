using Latest_v2_Crud_Kafka.Kafka;
using Latest_v2_Crud_Kafka.Kafka.service;
using Latest_v2_Crud_Kafka.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<KafkaSettingModel>(builder.Configuration.GetSection("Kafka"));

// Register services
builder.Services.AddSingleton(typeof(ProducerService<>));
builder.Services.AddSingleton(typeof(ConsumerService<>));
builder.Services.AddScoped(typeof(CrudService<>));

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
