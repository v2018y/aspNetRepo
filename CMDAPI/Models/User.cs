
namespace CMDAPI.Models
{
    public class User
    {
        public int id{get;set;}
        public string name {get; set;}
        public string username{get;set;}
        public string email {get;set;}
        public string password {get;set;}
        public System.DateTime created_at{get;set;}
    }
}