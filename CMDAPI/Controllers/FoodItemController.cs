using System;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;
// This line Give the IActions Result
using System.Linq;

namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodItemController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public FoodItemController(CommandContext context){
            _context=context;
        }

        //GET:  api/foodietm
        [HttpGet]
        public IActionResult GetFoodIetm(){
            var user=Request.Headers["userId"];
            Console.WriteLine("User Id "+user);
            return Ok(_context.FoodItem.Where(s => s.userId == Convert.ToInt32(user)));
        }

        //GET : api/foodietm/n
        [HttpGet("{id}")]
        public IActionResult GetFoodIetmById(int id){
            
            var foodItem= _context.FoodItem.Where(s => s.foId == id);
            if(foodItem == null){
                return NotFound();
            }
             Console.WriteLine("By Id Res = "+ foodItem);
            return Ok(foodItem);
        }

        //POST : api/foodietm
        [HttpPost]
        public IActionResult PostFoodIetm(FoodItem foodItem){
           var user=Request.Headers["userId"];
           foodItem.userId=Convert.ToInt32(user);
           _context.FoodItem.Add(foodItem);
           _context.SaveChanges();
           return GetFoodIetmById(foodItem.foId);
       }

        //PUT : api/foodietm/n
        [HttpPut("{id}")]
        public  IActionResult PutFoodIetm(int id,FoodItem foodItem){
            if(id !=foodItem.foId){
                return BadRequest();
            }
             var user=Request.Headers["userId"];
            _context.Entry(foodItem).State= EntityState.Modified;
            foodItem.userId=Convert.ToInt32(user);
            _context.SaveChanges();
            return GetFoodIetmById(foodItem.foId);
        }

        //DELETE : api/foodietm/n
        [HttpDelete("{id}")]
        public ActionResult<FoodItem> DeleteFoodIetm(int id){
           var foodItem=_context.FoodItem.Find(id);
           if(foodItem == null){
               return NotFound();
           }
           _context.FoodItem.Remove(foodItem);
           _context.SaveChanges();
           return foodItem;
        }
    }
}
