namespace ProjetosEspaciais.Enums;

public enum FaseAtual
{
    // Fase inicial onde o projeto está sendo planejado e os detalhes são definidos
    Planejamento,            // O projeto está em fase de planejamento, incluindo definição de escopo, orçamento e cronograma

    // Fase de desenvolvimento e execução, onde o projeto começa a ser colocado em prática
    Execucao,                // O projeto está em execução, com atividades de desenvolvimento, testes e implementação em andamento

    // Fase de testes, onde o sistema ou a solução é testada antes da finalização
    Testes,                  // O projeto está em fase de testes, validando funcionalidades, desempenho e segurança

    // Fase final do projeto, onde o trabalho é encerrado e a entrega é feita
    Conclusao,               // O projeto está na fase de conclusão, onde a entrega dos resultados finais está sendo realizada

    // Fase de monitoramento e acompanhamento após a entrega do projeto, assegurando que tudo esteja funcionando como esperado
    Acompanhamento,          // O projeto está na fase de acompanhamento, garantindo que todos os sistemas ou resultados entregues estão operando corretamente

    // Fase onde o projeto foi suspenso por algum motivo e não está mais em andamento
    Suspensao,               // O projeto foi suspenso temporariamente, aguardando resolução de problemas ou replanejamento

    // Fase de revisão pós-execução, onde o projeto passa por uma análise de resultados e performance
    Revisao,                 // O projeto está sendo revisado após sua execução para avaliar desempenho, impacto e lições aprendidas

    // Fase onde o projeto foi pausado e não está em andamento ativo, mas pode ser retomado mais tarde
    Pausado,                 // O projeto foi pausado e pode ser retomado em algum momento no futuro

    // Fase de avaliação e aprendizado, onde o projeto está sendo avaliado para determinar os próximos passos
    Avaliacao,               // O projeto está em fase de avaliação para determinar resultados, lições aprendidas e novas ações

    // Fase onde o projeto foi finalizado e está sendo fechado, com todos os processos e entregas finalizados
    Fechamento               // O projeto foi fechado oficialmente, com todos os processos administrativos e financeiros finalizados
}