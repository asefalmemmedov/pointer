using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class TeamSlider
    {
        public int Id { get; set; }

        [StringLength(300)]
        public string Image { get; set; }

        [NotMapped]
        public  HttpPostedFileBase Photo { get; set; }
    }
}