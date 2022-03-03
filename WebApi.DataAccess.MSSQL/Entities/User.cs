using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DataAccess.MSSQL.Entities;

namespace WebApi.DataAccess.MSSQL.Entities
{
    public class User
    {
        [Key]
        public string UserId { get; set; }

        public string UserFullName { get; set; }

        public string Sex { get; set; }

        public int Age { get; set; }
    }
}
