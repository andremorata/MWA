using FluentValidator;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        public Customer (string firstName, string lastName, string email, User user)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = null;
            Email = email;
            User = user;

            //validações
            new ValidationContract<Customer>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome precisa ter 60 caracteres no máximo")
                .HasMinLenght(x => x.LastName, 3, "Nome precisa ter ao menos 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome precisa ter 60 caracteres no máximo")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome precisa ter ao menos 3 caracteres")
                .IsRequired(x => x.Email, "Email é obrigatório")
                .HasMaxLenght(x => x.Email, 60, "Email precisa ter 60 caracteres no máximo")
                .HasMinLenght(x => x.Email, 3, "Email precisa ter ao menos 3 caracteres")
                .IsEmail(x => x.Email, "Email inválido");

        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public string Email { get; private set; }
        public User User { get; private set; }

        public void Update(string firstName, string lastName, DateTime? birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
