using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IT_project.Models
{
    public class BookRec
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public int Image_id { get; set; }
        public int User_id { get; set; }
        //[ForeignKey("User_id")]
       // public virtual User User { get; set; }

    }
}
