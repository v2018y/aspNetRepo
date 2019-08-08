using System.ComponentModel.DataAnnotations;

namespace CMDAPI.Models{
    public class HTable{
        [Key]
        public int tabId {get;set;}
        public string tabName {get;set;}
        public string tabLocations {get;set;}
    }
}