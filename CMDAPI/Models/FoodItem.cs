using System.ComponentModel.DataAnnotations;

namespace CMDAPI.Models{
    public class FoodItem{
        [Key]
        public int foId {get;set;}
        public string foName {get;set;}
        public double foRate {get;set;}
        public int userId {get;set;}
    }
}