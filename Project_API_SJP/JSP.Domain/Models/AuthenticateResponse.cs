using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JSP.Domain.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
