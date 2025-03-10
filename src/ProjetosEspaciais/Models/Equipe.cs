namespace ProjetosEspaciais.Models
{
    public class Equipe
    {
        public Guid Id { get; set; }
        public string Codinome { get; set; }
        public string Funcao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public DateTime? DataDelecao { get; set; }
        public bool Ativo { get; set; }
        public Guid ContatoId { get; set; }
        public Contato Contato { get; set; }
        public ICollection<Membro> Membros { get; set; } = new List<Membro>();
        public Guid LiderId { get; set; }
        public Membro Lider { get; set; }

        public static Equipe Inserir(string codinome, string funcao, Guid contatoId, Guid? liderId = null, Guid id = default)
        {
            if (string.IsNullOrEmpty(codinome))
            {
                throw new ArgumentException("O codinome não pode ser nulo ou vazio", nameof(codinome));
            }

            if (string.IsNullOrEmpty(funcao))
            {
                throw new ArgumentException("A função não pode ser nula ou vazia", nameof(funcao));
            }

            var equipe = new Equipe
            {
                Id = id == Guid.Empty ? Guid.NewGuid() : id,
                Codinome = codinome,
                Funcao = funcao,
                ContatoId = contatoId,
                DataCriacao = DateTime.UtcNow,
                Ativo = true
            };

            return equipe;
        }

        public static Equipe Atualizar(Equipe equipe, string codinome, string funcao, Guid contatoId, Guid liderId)
        {
            if (equipe == null)
            {
                throw new ArgumentNullException(nameof(equipe), "A equipe não pode ser nula");
            }

            if (string.IsNullOrEmpty(codinome))
            {
                throw new ArgumentException("O codinome não pode ser nulo ou vazio", nameof(codinome));
            }

            if (string.IsNullOrEmpty(funcao))
            {
                throw new ArgumentException("A função não pode ser nula ou vazia", nameof(funcao));
            }

            equipe.Codinome = codinome;
            equipe.Funcao = funcao;
            equipe.ContatoId = contatoId;
            equipe.LiderId = liderId;
            equipe.DataAtualizacao = DateTime.UtcNow;

            return equipe;
        }

        public static Equipe Remover(Equipe equipe)
        {
            if (equipe == null)
            {
                throw new ArgumentNullException(nameof(equipe), "A equipe não pode ser nula");
            }

            equipe.DataDelecao = DateTime.UtcNow;
            equipe.Ativo = false;

            return equipe;
        }

        public override string ToString()
        {
            return $@"
                    Id: {Id}
                    Codinome: {Codinome}
                    Função: {Funcao}
                    Contato: {Contato?.ToString() ?? "N/A"}
                    Data de Criação: {DataCriacao}
                    Data de Atualização: {DataAtualizacao}
                    Data de Deleção: {DataDelecao}
                    Ativo: {(Ativo ? "Sim" : "Não")}
                    Líder: {(Lider != null ? Lider.NomeCompleto : "Sem líder")}
                    Total de Membros: {Membros.Count}
                    ";
        }
    }
}