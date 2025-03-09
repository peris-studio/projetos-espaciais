namespace ProjetosEspaciais.Models;

using ProjetosEspaciais.Enums;

public class Documento
{
    public Guid Id { get; set; }
    public string? Titulo { get; set; }
    public TipoDocumento TipoDocumento { get; set; }
    public string? Versao { get; set; }
    public ClassificacaoSegurancaDocumento ClassificacaoSegurancaDocumento { get; set; }
    public StatusDocumento StatusDocumento { get; set; }
    public Guid EquipeId { get; set; }
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
    public DateTime? DataDelecao { get; set; }
    public bool Ativo { get; set; }

    public static Documento Inserir(string titulo,
                                    TipoDocumento tipoDocumento,
                                    string versao,
                                    ClassificacaoSegurancaDocumento classificacaoSegurancaDocumento,
                                    StatusDocumento statusDocumento,
                                    Guid equipeId)
    {
        ValidarCamposObrigatorios(titulo, versao);
        ValidarEnums(tipoDocumento, classificacaoSegurancaDocumento, statusDocumento);

        return new Documento
        {
            Id = Guid.NewGuid(),
            Titulo = titulo,
            TipoDocumento = tipoDocumento,
            Versao = versao,
            ClassificacaoSegurancaDocumento = classificacaoSegurancaDocumento,
            StatusDocumento = statusDocumento,
            EquipeId = equipeId,
            DataCriacao = DateTime.UtcNow,
            Ativo = true
        };
    }

    public static Documento Atualizar(Documento documento,
                                      string titulo,
                                      string versao,
                                      ClassificacaoSegurancaDocumento classificacaoSegurancaDocumento,
                                      StatusDocumento statusDocumento,
                                      Guid equipeId)
    {
        ValidarCamposObrigatorios(titulo, nameof(titulo));
        ValidarCamposObrigatorios(versao, nameof(versao));

        ValidarEnums(classificacaoSegurancaDocumento, statusDocumento);

        documento.Titulo = titulo;
        documento.Versao = versao;
        documento.ClassificacaoSegurancaDocumento = classificacaoSegurancaDocumento;
        documento.StatusDocumento = statusDocumento;
        documento.EquipeId = equipeId;
        documento.DataAtualizacao = DateTime.UtcNow;

        return documento;
    }

    public static Documento Deletar(Documento documento)
    {
        if (documento == null)
        {
            throw new ArgumentNullException(nameof(documento), "O documento não pode ser nulo.");
        }

        documento.Ativo = false;
        documento.DataDelecao = DateTime.UtcNow;

        return documento;
    }

    public static Documento Restaurar(Documento documento)
    {
        if (documento.Ativo)
            throw new InvalidOperationException("O documento já está ativo.");

        documento.Ativo = true;
        documento.DataDelecao = null;
        documento.DataAtualizacao = DateTime.UtcNow;

        return documento;
    }

    public static void ValidarCamposObrigatorios(params string[] valores)
    {
        foreach (var valor in valores)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("Os campos obrigatórios não podem ser vazios.");
        }
    }

    public static void ValidarEnums(params Enum[] valores)
    {
        foreach (var valor in valores)
        {
            if (!Enum.IsDefined(valor.GetType(), valor))
                throw new ArgumentException($"O valor '{valor}' não é válido para o tipo {valor.GetType().Name}.");
        }
    }

    public override string ToString()
    {
        return $@"
                Id: {Id}
                Título: {Titulo}
                Tipo de Documento: {TipoDocumento}
                Versão: {Versao}
                Classificação: {ClassificacaoSegurancaDocumento}
                Status: {StatusDocumento}
                Equipe Responsável: {EquipeId}
                Data de Criação: {DataCriacao}
                Data de Atualização: {DataAtualizacao?.ToString() ?? "N/A"}
                Data de Deleção: {DataDelecao?.ToString() ?? "N/A"}
                Ativo: {(Ativo ? "Sim" : "Não")}
                ";
    }
}