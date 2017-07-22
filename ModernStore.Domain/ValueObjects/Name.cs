using FluentValidator;

namespace ModernStore.Domain.ValueObjects
{
    public class Name: Notifiable
    {
        protected Name() { }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new ValidationContract<Name>(this)
                .IsRequired(x => x.FirstName, "Nome é obrigatório")
                .HasMaxLenght(x => x.FirstName, 60, "Nome precisa ter 60 caracteres no máximo")
                .HasMinLenght(x => x.LastName, 3, "Nome precisa ter ao menos 3 caracteres")
                .IsRequired(x => x.LastName, "Sobrenome é obrigatório")
                .HasMaxLenght(x => x.LastName, 60, "Sobrenome precisa ter 60 caracteres no máximo")
                .HasMinLenght(x => x.LastName, 3, "Sobrenome precisa ter ao menos 3 caracteres");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
