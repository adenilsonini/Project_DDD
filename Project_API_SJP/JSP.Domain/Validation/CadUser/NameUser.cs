using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JSP.Domain.Validation.CadUser
{
    public struct NameUser
    {
        private readonly string _value;
        public readonly Contract contract;

        private NameUser(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator NameUser(string value) =>
            new NameUser(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Informe um nome válido.");

            if (_value.Length < 10)
                return AddNotification("O nome deve ter mais de 10 caracteres.");

            if (!Regex.IsMatch(_value, (@"[^a-zA-Z0-9]")))
                return AddNotification("O nome não deve ter nenhum caractere especial.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(NameUser), message);
            return false;
        }
    }
}
