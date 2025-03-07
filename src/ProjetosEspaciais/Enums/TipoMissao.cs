namespace ProjetosEspaciais.Enums;
public enum TipoMissao
{
    // Missões de exploração e observação
    ExploracaoPlanetaria,       // Missões para explorar planetas e outros corpos celestes
    ObservacaoAstronomica,     // Missões para observação de estrelas, galáxias, e fenômenos astronômicos
    ObservacaoTerrestre,       // Missões para monitoramento e observação da Terra (ex: satélites de imagens)
    MissaoDeRover,             // Missões com rovers para exploração de superfícies de planetas ou luas

    // Missões de comunicação
    Comunicacao,               // Missões com satélites ou plataformas para estabelecer comunicação entre pontos distantes
    RedeSatelitare,            // Missões que envolvem constelações de satélites para comunicação global

    // Missões científicas e de pesquisa
    PesquisaEspacial,          // Missões focadas em pesquisas científicas no espaço (ex: análise de partículas cósmicas, radiação)
    ExperimentosMicrogravidade,// Missões que realizam experimentos em ambientes de microgravidade
    PesquisaAstrobiologia,     // Missões para investigar a possibilidade de vida extraterrestre ou condições em planetas e luas

    // Missões de infraestrutura
    TransporteOrbital,         // Missões para transporte de materiais ou equipamentos para órbitas específicas
    ImplantacaoSatellites,     // Missões para implantar satélites em órbitas específicas para diferentes finalidades
    EstacaoEspacial,           // Missões relacionadas à construção, manutenção e operação de estações espaciais

    // Missões de segurança e defesa
    DefesaEspacial,            // Missões relacionadas à proteção contra ameaças espaciais, como detritos ou radiação cósmica
    MonitoramentoOrbital,      // Missões para monitoramento de atividades espaciais ou objetos em órbita (ex: rastreamento de satélites ou detritos espaciais)

    // Missões de preparação para futuro
    PreparacaoColonizacao,     // Missões para explorar e preparar o ambiente para futuras colônias em outros planetas
    MissaoInterplanetaria,     // Missões para enviar naves a outros planetas e explorar nosso sistema solar
    MissaoInterestelar,        // Missões para explorar além do nosso sistema solar, visando a exploração de outras estrelas

    // Missões de resgate e recuperação
    ResgateEspacial,           // Missões de resgate, recuperação de satélites ou outras plataformas espaciais
    RecuperacaoDeCargas,       // Missões focadas em recuperar satélites, cargas ou módulos de uma missão anterior
}