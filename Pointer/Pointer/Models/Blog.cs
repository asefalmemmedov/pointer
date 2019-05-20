using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class Blog
    {
        public int id { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Content { get; set; }

        [StringLength(50)]
        public string FulName { get; set; }

        [StringLength(300)]
        public string Image { get; set; }


        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}