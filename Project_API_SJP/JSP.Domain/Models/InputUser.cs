using System;

namespace JSP.Domain.Models
{
    public class InputUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Ativo { get; set; }
    }
}
