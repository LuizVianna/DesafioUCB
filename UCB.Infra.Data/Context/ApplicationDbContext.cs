using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UCB.Domain.Entities;

namespace UCB.Infra.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Student>().ToTable(nameof(Student)).HasKey(x => x.Id);
            builder.Entity<User>().ToTable(nameof(User)).HasKey(x => x.Id);


            builder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "admin"
                });

            builder.Entity<Student>().HasData(
                new Student
                {
                    Id = 1,
                    Nome = "Luciana Souza",
                    DataNascimento = Convert.ToDateTime("2010-04-28"),
                    Endereco = "Rua x, nº 120 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                    Idade = 14,
                    NomeMae = "Maria de Lourdes de Souza",
                    NomePai = "Jorge Alves de Souza",
                    NotaMedia = 9.5,
                    Serie = 9
                },
                new Student
                {
                    Id = 2,
                    Nome = "Débora Soares",
                    DataNascimento = Convert.ToDateTime("2017-10-01"),
                    Endereco = "Rua y, nº 230 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                    Idade = 6,
                    NomeMae = "Rita Soares",
                    NomePai = "Paulo Nogueira",
                    NotaMedia = 8.5,
                    Serie = 1
                },
                new Student
                {
                    Id = 3,
                    Nome = "Melissa Peixoto",
                    DataNascimento = Convert.ToDateTime("2016-11-23"),
                    Endereco = "Rua w, nº 530 - Campo Grande - Rio de Janeiro - RJ - 23000-000",
                    Idade = 7,
                    NomeMae = "Rose Peixoto",
                    NomePai = "Rogério Felix",
                    NotaMedia = 8.5,
                    Serie = 2
                });
        }
    }
}
