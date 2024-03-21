using HD_Support_API.Components;
using HD_Support_API.Repositorios;
using HD_Support_API.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Adicione servi�os ao cont�iner.
builder.Services.AddControllers();

// Configura��o do DbContext com a string de conex�o
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IEquipamentosRepositorio, EquipamentoRepositorio>();
builder.Services.AddScoped<IEmprestimoRepositorio, EmprestimoRepositorio>();
builder.Services.AddScoped<IFuncionarioRepositorio, FuncionarioRepositorio>();
builder.Services.AddScoped<IHelpDeskRepositorio, HelpDeskRepositorio>();
builder.Services.AddScoped<IConversaRepositorio, ConversaRepositorio>();

//suporte a CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("OpenCorsPolicy", builder =>
        builder.AllowAnyOrigin() // Isso permite requisi��es de qualquer origem
               .AllowAnyMethod()
               .AllowAnyHeader());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors("OpenCorsPolicy");

app.MapControllers();

app.Run();
