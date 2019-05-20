using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web;

namespace Pointer.Models 
{
    public class About
    {
        public int id { get; set; }

        [StringLength(100)]
        public string SupTitle { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        //[StringLength(300)]
        //public string BigText { get; set; }
        //[StringLength(300)]
        //public string NormalText { get; set; }
        //[StringLength(300)]
        //public string SmallText { get; set; }


        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

    }
}