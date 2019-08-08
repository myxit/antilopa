using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AntilopaApi.Models
{
    public class Maintenance {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; }
        public DateTime PlannedFrom { get; set; }
        public DateTime PlannedTo { get; set; }
        public virtual Car Car {get; set;}
    }    
}