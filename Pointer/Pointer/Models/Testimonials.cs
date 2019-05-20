using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class Testimonials
    {
        public int id { get; set; }

        [Required, StringLength(500)]
        public string Content { get; set; }

        [Required, StringLength(100)]
        public string FullName { get; set; }
      
        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}