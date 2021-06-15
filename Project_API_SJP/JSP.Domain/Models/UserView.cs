using System;

namespace JSP.Domain.Models
{
    public class UserView
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime datacad { get; private set; }
    }
}
