namespace ProjetosEspaciais.Enums;

public enum ClassificacaoSegurancaDocumento
{
    Publico,          // Documento acessível ao público em geral.
    Restrito,         // Apenas equipes autorizadas podem acessar.
    Confidencial,     // Requer permissão especial dentro do projeto.
    Secreto,          // Informação altamente sensível, acesso limitado.
    UltraSecreto      // Acesso extremamente restrito, apenas para altos níveis de segurança.
}