using System.Collections.Generic;

namespace AntilopaApi.Models
{
    public class Owner {
        public int Id {get;set;}
        public string Name {get; set;}
        public string Address {get; set;}
        public ICollection<Car> Cars {get; set;}
    }
}