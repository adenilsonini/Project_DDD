using JSP.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Project_API_SJP.Models
{
    public class ViewUser
    {
        public long CountReg { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
