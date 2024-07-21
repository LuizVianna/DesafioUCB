using UCB.Domain.Validations;

namespace UBC.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public User() { }

        public User(int id, string userName, string password)
        {
            Id = id;
            UserName = userName;
            Password = password;
        }

        public User(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public void Alterar(int id, string userName, string password)
        {
            ValidaComId(id, userName, password);
        }

        private void ValidaComId(int id, string userName, string password)
        {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(userName, password);
        }

        private void ValidateDomain(string userName, string password)
        {
            DomainExceptionValidation.When(userName == null, "O Username é um campo obrigatório.");
            DomainExceptionValidation.When(password == null, "O Password é um campo obrigatório.");

            UserName = userName;
            Password = password;
        }
    }
}
