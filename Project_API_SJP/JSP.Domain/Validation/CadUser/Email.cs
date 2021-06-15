using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace JSP.Domain.Validation.CadUser
{
    public struct Email
    {
        private readonly string _value;
        public readonly Contract contract;

        private Email(string value)
        {
            _value = value;
            contract = new Contract();
            Validate();
        }

        public override string ToString() =>
            _value;

        public static implicit operator Email(string value) =>
            new Email(value);

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(_value))
                return AddNotification("Informe um e-mail.");

            if (!Regex.IsMatch(_value, (@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$")))
                return AddNotification("O e-mail informado é Invalido.");

            return true;
        }

        private bool AddNotification(string message)
        {
            contract.AddNotification(nameof(Email), message);
            return false;
        }
    }
}
