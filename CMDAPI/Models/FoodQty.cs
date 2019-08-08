using System.ComponentModel.DataAnnotations;

namespace CMDAPI.Models{
    public class FoodQty{
        [Key]
        public int fqId {get;set;}
        public string foodName {get;set;}
        public int foodQty {get;set;}
        public double foodTotal {get;set;}

        public int foId {get;set;}
        public virtual FoodItem FoodItem {get;set;}
    }
}