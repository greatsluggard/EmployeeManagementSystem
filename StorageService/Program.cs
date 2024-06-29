using MassTransit;
using StorageService;
using StorageService.Application.DependencyInjection;
using StorageService.DAL.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<EmployeeConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("rabbitmq", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.ReceiveEndpoint("employee-queue", e =>
        {
            e.ConfigureConsumer<EmployeeConsumer>(context);
        });

        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddDataAccessLayer(builder.Configuration);

builder.Services.AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();