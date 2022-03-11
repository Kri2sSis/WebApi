using System.ComponentModel.DataAnnotations;

namespace WebApi.DataAccess.MSSQL.Entities
{
    public class User
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public Sex Sex { get; set; }

        public int Age { get; set; }
    }
}
