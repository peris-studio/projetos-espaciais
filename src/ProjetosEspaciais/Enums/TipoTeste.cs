namespace ProjetosEspaciais.Enums;
public enum TipoTeste
{
    // Testes de performance e comportamento do sistema
    TesteFuncional,          // Testes para garantir que os sistemas funcionem como esperado
    TesteDeEstresse,         // Testes para avaliar o desempenho sob condições extremas
    TesteDeResiliência,      // Testes para avaliar a capacidade de recuperação após falhas
    TesteDeLongaDuracao,     // Testes realizados para verificar o comportamento do sistema ao longo do tempo

    // Testes de segurança e confiabilidade
    TesteDeSeguranca,        // Testes para avaliar a segurança do sistema ou da plataforma
    TesteDeIntegridade,      // Testes para garantir que os dados e sistemas estejam íntegros e protegidos
    TesteDeConformidade,     // Testes para garantir que os sistemas atendam às normas e regulamentações

    // Testes para validação de operação no ambiente espacial
    TesteDeVoo,              // Testes realizados durante o voo ou missão espacial
    TesteDeVacuo,            // Testes realizados em condições de vácuo para simular o ambiente espacial
    TesteDeRadiação,         // Testes para simular a radiação espacial e o impacto nos sistemas
    TesteDeTemperatura,      // Testes para validar o desempenho em temperaturas extremas

    // Testes relacionados à interface e usabilidade
    TesteDeInterface,        // Testes de usabilidade e interação com o sistema ou interface
    TesteDeComunicacao,      // Testes para garantir a eficácia das comunicações espaciais (rádio, sinais, etc.)

    // Testes de validação de equipamentos e sistemas específicos
    TesteDeSensores,         // Testes para validar a precisão e funcionamento dos sensores
    TesteDePropulsao,        // Testes para validar o sistema de propulsão do veículo espacial
    TesteDeEnergizacao,      // Testes para validar o sistema de geração e distribuição de energia

    // Testes de simulação e verificação de cenário
    TesteDeSimulacao,        // Testes de simulação para avaliar o comportamento do sistema em diferentes cenários
    TesteDeVerificacao      // Testes para garantir que os requisitos e especificações do projeto sejam atendidos
}