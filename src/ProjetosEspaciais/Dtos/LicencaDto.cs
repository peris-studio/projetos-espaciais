namespace ProjetosEspaciais.Dtos;

public record LicencaDto(TipoLicenca TipoLicenca, string Nome, string NumeroLicenca, string OrgaoEmissor, DateOnly DataEmissao, DateOnly DataValidade, string RequisitoConformidade, Guid Id = default);