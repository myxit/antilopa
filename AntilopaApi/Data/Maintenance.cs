using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata;
namespace AntilopaApi.Data
{
    public class Maintenance {
        public int Id {get; set;}
        public string Title {get; set;}
        public string Description {get; set;}

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public DateTime? PlannedFrom { get; set; }
        public DateTime? PlannedTo { get; set; }
        public virtual Car Car {get; set;}
    }    
}