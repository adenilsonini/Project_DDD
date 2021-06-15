using JSP.Domain.Validation.CadUser;
using System;
using System.Collections.Generic;
using System.Text;
using Flunt.Validations;
using System.Text.RegularExpressions;

namespace JSP.Domain.Entities
{
   public class User : BaseEntity
    {
        public User(int id, string userName, string email, string password) : base(id, true)
        {
            AddNotifications(
               Validate_Nome(userName),
               Validate_Email(email),
               Validate_Password(password));

            if (Valid)
            {
                UserName = userName;
                Email = email;
                Password = password;
            }
        }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        private Contract Validate_Nome(string nome)
        {
            Contract Validate = new Contract();

            if (string.IsNullOrWhiteSpace(nome))
                Validate.AddNotification(nameof(Validate_Nome), "Informe um nome válido.");
              
            if (nome.Length < 10)
                Validate.AddNotification(nameof(Validate_Nome), "O nome deve ter mais de 10 caracteres.");

            if (!Regex.IsMatch(nome, (@"[^a-zA-Z0-9]")))
                Validate.AddNotification(nameof(Validate_Nome), "O nome não deve ter nenhum caractere especial.");

            return Validate;
        }

        private Contract Validate_Email(string email)
        {
            Contract Validate = new Contract();

            if (string.IsNullOrWhiteSpace(email))
                Validate.AddNotification(nameof(Validate_Email), "Informe um e-mail.");

            if (!Regex.IsMatch(email, (@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$")))
                Validate.AddNotification(nameof(Validate_Email), "O e-mail informado é Invalido.");

            return Validate;
        }

        private Contract Validate_Password(string password)
        {
            Contract Validate = new Contract();

            if (string.IsNullOrWhiteSpace(password))
                Validate.AddNotification(nameof(Validate_Password), "É necessário informar a senha.");

            if (password.Length < 6)
                Validate.AddNotification(nameof(Validate_Password), "A senha deve ter mais de 6 caracteres.");

            return Validate;
        }

    }
}

