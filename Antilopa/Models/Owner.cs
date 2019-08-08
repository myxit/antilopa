using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntilopaApi.Models
{
    public class Owner {
        public int Id {get;set;}
        public string Name {get; set;}
        public string Address {get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }

        public ICollection<Car> Cars {get; set;}
    }
}