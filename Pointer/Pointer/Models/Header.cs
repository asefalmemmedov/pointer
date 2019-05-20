using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace Pointer.Models
{
    public class Headers
    {
        public int id { get; set; }

        [StringLength(150)]
        [AllowHtml]
        public string Title { get; set; }

        [AllowHtml]
        [StringLength(500)]
        public string Description { get; set; }


        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }
    }
}