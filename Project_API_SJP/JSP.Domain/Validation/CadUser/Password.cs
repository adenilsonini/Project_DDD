using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JSP.Domain.Validation.CadUser
{
    public struct Password
    {
        private readonly string _value;
        public readonly Contract contract;

        private Password(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();

           // if(contract.Valid)
               // _value = Convert.ToBase64String(new UTF8Encoding().GetBytes(_value));
        }

        public override string ToString() =>
            _value;

        public static implicit operator Password(string input) =>
            new Password(input.Trim());

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("É necessário informar a senha.");

            if(_value.Length < 6)
                return AddNotification("A senha deve ter mais de 6 caracteres.");

            if (Regex.IsMatch(_value, (@"[^a-zA-Z0-9]")))
                return AddNotification("A senha não deve ter nenhum caractere especial.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Password), message);
            return false;
        }
    }
}
