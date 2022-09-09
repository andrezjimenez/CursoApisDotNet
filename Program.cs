using sss;
using sss.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSqlServer<TaskContext>("Data Source=DESKTOP-FLDC4G6\\SQLEXPRESS;Initial Catalog=TareasDB;user id=sa;password=saDM2015");

builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<ITaskService , TaskService>();

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
