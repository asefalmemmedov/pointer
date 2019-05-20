using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class Services
    {
        public int id { get; set; }

        [Required, StringLength(100)]
        public string Title { get; set; }

        [Required, StringLength(500)]
        public string Content { get; set; }
    }
}