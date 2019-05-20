using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class Team
    {
        public int Id { get; set; }


        [Required,StringLength(100)]
        public string   Name { get; set; }

        [Required, StringLength(100)]
        public string   LastName { get; set; }

        [Required, StringLength(300)]
        public string   Profection { get; set; }

        [StringLength(300)]
        public string   Image { get; set; }

        [NotMapped]
        public HttpPostedFileBase Photo { get; set; }

        [ StringLength(100)]
        [Url]
        public string Facebook { get; set; }

        [StringLength(100)]
        [Url]
        public string Linkedn { get; set; }

        [StringLength(100)]
        [Url]
        public string Twitter { get; set; }

        [StringLength(100)]
        [Url]
        public string  Instagram { get; set; }
    }
}