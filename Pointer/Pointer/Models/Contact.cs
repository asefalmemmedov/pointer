using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pointer.Models
{
    public class Contact
    {
        public int id { get; set; }

        [Required, StringLength(100)]
        public string FirstName { get; set; }

        [Required, StringLength(100)]
        public string LastName { get; set; }

        [Required, StringLength(100),EmailAddress]
        public string Email { get; set; }

        [ StringLength(300)]
        public string Subject { get; set; }

        [Required, StringLength(500)]
        public string Message { get; set; }


      
    }
}