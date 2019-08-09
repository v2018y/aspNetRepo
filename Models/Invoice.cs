using System.ComponentModel.DataAnnotations;

namespace CMDAPI.Models{
    public class Invoice{
        [Key]
        public int invId {get; set;}
        public double invSubTotal {get;set;}
        public double invTotal {get;set;}
        public string gst {get;set;}

        public int tabId {get;set;}
        public virtual HTable HTable {get;set;}
        public int fqId {get;set;}
        public virtual FoodQty FoodQty {get;set;}


    }
}