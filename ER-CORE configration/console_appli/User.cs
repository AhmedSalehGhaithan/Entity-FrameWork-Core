using System.ComponentModel.DataAnnotations.Schema;

namespace EF_CORE_External_Configuration
{
    [Table("Users")]
    public class User
    {
        //to change the name of colum using data annotations
        [Column("UserId")]
        public int Id { get; set; }
        public string userName { get; set; }

    }
}
