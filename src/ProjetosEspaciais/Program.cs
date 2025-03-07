var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "ProjetosEspaciais API", Version = "v1" });
});

// Configurando o DbContext com a string de conexão
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<ContatoService>();
builder.Services.AddScoped<DocumentoService>();
builder.Services.AddScoped<EquipeService>();
builder.Services.AddScoped<ExperienciaService>();
builder.Services.AddScoped<HistoricoAlteracaoService>();
builder.Services.AddScoped<LicencaService>();
builder.Services.AddScoped<LocalidadeService>();
builder.Services.AddScoped<MembroService>();
builder.Services.AddScoped<MissaoService>();
builder.Services.AddScoped<PlataformaService>();
builder.Services.AddScoped<ProjetoService>();
builder.Services.AddScoped<TesteService>();
builder.Services.AddScoped<VeiculoService>();

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
app.MapExperienciaEndpoints();
app.MapLicencaoEndpoints();
app.MapLocalidadeEndpoints();
app.MapMembroEndpoints();
app.MapPlataformaEndpoints();
app.MapVeiculoEndpoints();
app.MapEquipeEndpoints();
app.MapDocumentoEndpoints();
app.MapHistoricoAlteracaoEndpoints();
app.MapTesteEndpoints();
app.MapMissaoEndpoints();
app.MapProjetoEndpoints();

// Iniciando a aplicação
app.Run();