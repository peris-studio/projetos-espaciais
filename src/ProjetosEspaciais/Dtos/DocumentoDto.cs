namespace ProjetosEspaciais.Dtos;

public record DocumentoDto(string Titulo,
                           TipoDocumento TipoDocumento,
                           string Versao,
                           ClassificacaoSegurancaDocumento ClassificacaoSegurancaDocumento,
                           StatusDocumento StatusDocumento,
                           Guid EquipeId,
                           Guid Id = default);