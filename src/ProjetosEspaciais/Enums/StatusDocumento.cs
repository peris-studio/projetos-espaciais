namespace ProjetosEspaciais.Enums;

public enum StatusDocumento
{
    Rascunho,        // Documento ainda em elaboração.
    EmRevisao,       // Em processo de revisão por outras equipes.
    Aprovado,        // Revisado e aprovado para uso.
    Obsoleto,        // Documento desatualizado, mas mantido para histórico.
    Arquivado,       // Não está mais em uso ativo, mas armazenado para referência.
    Revogado         // Documento retirado de circulação por ser incorreto ou inseguro.
}