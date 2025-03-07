namespace ProjetosEspaciais.Dtos;

public record DocumentoDto(string Titulo,
                           TipoDocumento TipoDocumento,
                           string Versao,
                           ClassificacaoSegurancaDocumento ClassificacaoSegurancadocumento,
                           StatusDocumento Statusdocumento,
                           Guid Equipe,
                           Guid Id = default);