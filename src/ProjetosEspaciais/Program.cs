var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ProjetosEspaciais API", Version = "v1" });
});

// Configurando o DbContext com a string de conexão
builder.Services.AddDbContext<ApplicationDbContext>();

// Adicionando Health Checks
builder.Services.AddHealthChecks();

// Criando a aplicação
var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ProjetosEspaciais API v1");
    c.RoutePrefix = string.Empty; // Acessar documentação na raiz ("/")
});

app.UseHttpsRedirection();
app.UseRouting(); // Adicione esta linha para garantir que o roteamento está configurado

// Endpoint de Health Check
app.MapHealthChecks("/healthcheck");

// Registre os módulos de endpoints aqui
app.MapContatoEndpoints();
app.MapLicencaEndpoints();
app.MapLocalidadeEndpoints();
app.MapMembroEndpoints();
app.MapPlataformaEndpoints();
app.MapVeiculoEndpoints();
app.MapEquipeEndpoints();
app.MapDocumentoEndpoints();
app.MapTesteEndpoints();
app.MapMissaoEndpoints();
app.MapProjetoEndpoints();

// Iniciando a aplicação
app.Run();