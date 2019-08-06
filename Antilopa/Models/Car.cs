namespace AntilopaApi.Models
{
    public class Car {
        public int Id {get; set;}
        public string Nickname {get; set;}
        public string Model {get; set;}
        public string RegistrationNr {get; set;}
        public string PicUrl {get; set;}
        public virtual Owner Owner {get; set;}
    }    
}