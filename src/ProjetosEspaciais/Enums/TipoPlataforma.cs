namespace ProjetosEspaciais.Enums;
public enum TipoPlataforma
{
    // Plataformas de lançamento e de veículos espaciais
    PlataformaLançamento,      // Plataforma usada para lançar foguetes ou espaçonaves (ex: KSC, Baikonur)
    PlataformaOrbital,         // Plataforma que fica em órbita, como a Estação Espacial Internacional (ISS)
    PlataformaTerrestre,       // Plataforma no solo para pesquisa ou operações (ex: centro de controle)
    PlataformaPesquisa,        // Plataforma usada para experimentos e pesquisa científica em órbita ou no solo

    // Plataformas espaciais para exploração e missões interplanetárias
    PlataformaExploracaoLunar, // Plataforma usada em missões de exploração lunar
    PlataformaExploracaoMarciana, // Plataforma usada para missões espaciais em Marte
    PlataformaSondaEspacial,   // Plataformas usadas em sondas espaciais (ex: sondas para Júpiter ou Saturno)

    // Plataformas de observação e satélites
    PlataformaObservacional,   // Plataforma para observação astronômica ou de satélites
    PlataformaSatéliteComunicacao, // Plataformas em satélites de comunicação

    // Plataformas para outros tipos de veículos ou experimentos
    PlataformaVeiculoExploracao, // Plataforma para veículos de exploração no espaço ou em outros corpos celestes
    PlataformaTesteTecnologia   // Plataforma para testes de novas tecnologias espaciais
}
