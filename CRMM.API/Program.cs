using CRM.API.Endpoints;
using CRM.API.Models.DAL;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

var conn = builder.Configuration.GetConnectionString("Con") ?? "Data Source=DESKTOP-NFDMETJ\\SQLEXPRESS;Initial Catalog=CRMMDB; Integrated Security=True";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CRMContext>(options =>
    options.UseSqlServer(conn)
);


builder.Services.AddScoped<CustomerDAL>();

var app = builder.Build();

app.AddCustomerEndpoints();

if (app.Environment.IsDevelopment())
 



{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
