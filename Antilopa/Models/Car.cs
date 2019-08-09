using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntilopaApi.Models
{
    public class Car {
        public int Id {get; set;}
        public string Nickname {get; set;}
        public string Model {get; set;}
        public string RegistrationNr {get; set;}
        public string PicUrl {get; set;}
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public virtual Owner Owner {get; set;}
        public ICollection<Maintenance> Maintenance { get; set; }
    }    
}