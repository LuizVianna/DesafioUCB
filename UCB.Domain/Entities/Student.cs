using UCB.Domain.Validations;

namespace UBC.Domain.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public int Idade { get; set; }

        public int Serie { get; set; }
        public double NotaMedia { get; set; }
        public string Endereco { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public DateTime DataNascimento { get; set; }

        public Student() { }

        public Student(int id, string nome, int idade, int serie, double notaMedia, string endereco, string nomePai, string nomeMae, DateTime dataNascimento)
        {
            ValidaComId(id, nome, idade, serie, notaMedia, endereco, nomePai, nomeMae, dataNascimento);
        }

        public void Alterar(int id, string nome, int idade, int serie, double notaMedia, string endereco, string nomePai, string nomeMae, DateTime dataNascimento)
        {
            ValidaComId(id, nome, idade, serie, notaMedia, endereco, nomePai, nomeMae, dataNascimento);
        }


        private void ValidaComId(int id, string nome, int idade, int serie, double notaMedia, string endereco, string nomePai, string nomeMae, DateTime dataNascimento)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(nome, idade, serie, notaMedia, endereco, nomePai, nomeMae, dataNascimento);
        }

        private void ValidateDomain(string nome, int idade, int serie, double notaMedia, string endereco, string nomePai, string nomeMae, DateTime dataNascimento)
        {
            DomainExceptionValidation.When(nome == null, "O nome do student é um campo obrigatório.");
            DomainExceptionValidation.When(idade <= 0, "A idade deve ser um positivo e maior que zero.");
            DomainExceptionValidation.When(serie <= 0, "A série deve ser um positivo e maior que zero.");
            DomainExceptionValidation.When(notaMedia < 0, "A nota média não dever ser um negativa.");

            DomainExceptionValidation.When(nome.Length > 200, "O nome não pode ultrapassar 200 caracteres.");
            DomainExceptionValidation.When(endereco.Length > 300, "O endereço não pode ultrapassar 300 caracteres.");
            DomainExceptionValidation.When(nomeMae.Length > 200, "O nome da mãe não pode ultrapassar 200 caracteres.");
            DomainExceptionValidation.When(nomePai.Length > 200, "O nome da pai não pode ultrapassar 200 caracteres.");

            Idade = idade;
            Nome = nome;
            NomeMae = nomeMae;
            NomePai = nomePai;
            Endereco = endereco;
            Serie = serie;
            NotaMedia = notaMedia;
            DataNascimento = dataNascimento;
        }
    }
}
