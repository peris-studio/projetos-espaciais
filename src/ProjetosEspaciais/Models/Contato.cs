namespace ProjetosEspaciais.Models
{
    public class Contato
    {
        public Guid Id { get; set; }
        public TipoContato TipoContato { get; set; }
        public required string EnderecoContato { get; set; }
        public bool Principal { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataDelecao { get; set; }
        public bool Ativo { get; set; }

        public static Contato Inserir(TipoContato tipoContato, string enderecoContato, bool principal, Guid id = default)
        {
            if (string.IsNullOrEmpty(enderecoContato))
            {
                throw new ArgumentException("O endereço de contato não pode ser nulo ou vazio", nameof(enderecoContato));
            }

            return new Contato
            {
                Id = id == Guid.Empty ? Guid.NewGuid() : id,
                TipoContato = tipoContato,
                EnderecoContato = enderecoContato,
                Principal = principal,
                DataCriacao = DateTime.UtcNow, // Usar UTC
                Ativo = true
            };
        }

        public static Contato Atualizar(Contato contato, TipoContato tipoContato, string enderecoContato)
        {
            if (contato == null)
            {
                throw new ArgumentNullException(nameof(contato), "O contato não pode ser nulo");
            }

            if (string.IsNullOrEmpty(enderecoContato))
            {
                throw new ArgumentException("O endereço de contato não pode ser nulo ou vazio", nameof(enderecoContato));
            }

            contato.TipoContato = tipoContato;
            contato.EnderecoContato = enderecoContato;
            contato.DataAtualizacao = DateTime.UtcNow;

            return contato;
        }

        public static Contato Remover(Contato contato)
        {
            if (contato == null)
            {
                throw new ArgumentNullException(nameof(contato), "O contato não pode ser nulo");
            }

            contato.DataDelecao = DateTime.UtcNow;
            contato.Ativo = false;

            return contato;
        }

        // Converter resposta de contato principal para bool
        public static bool StringParaBool(string principal)
        {
            return principal.ToLower() == "sim";
        }

        public override string ToString()
        {
            string principal = Principal ? "Sim" : "Não";
            string status = Ativo ? "Ativo" : "Inativo";

            return $@"
                    Tipo de Contato: {TipoContato}
                    Endereço de Contato: {EnderecoContato}
                    Contato Principal: {principal}
                    Status: {status}
                    Data de Criação: {DataCriacao}
                    Data de Atualização: {DataAtualizacao}
                    Data de Deleção: {DataDelecao}
                    ";
        }
    }
}