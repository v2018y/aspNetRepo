using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;


namespace CMDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly CommandContext _context;
        
        public InvoiceController(CommandContext context){
            _context=context;
        }

        //GET:  api/invoice
        [HttpGet]
        public ActionResult<IEnumerable<Invoice>> GetInvoice(){
            var user=Request.Headers["userId"];
            Console.WriteLine("UserId = " +user);
            return _context.Invoice;
        }

        //GET : api/invoice/n
        [HttpGet("{id}")]
        public ActionResult<Invoice> GetInvoiceItem(int id){
            var user=Request.Headers["userId"];
            Console.WriteLine("UserId = " +user);
            var invoiceItem= _context.Invoice.Find(id);
            if(invoiceItem == null){
                return NotFound();
            }
            return invoiceItem;
        }

        //POST : api/invoice
        [HttpPost]
        public ActionResult<Invoice> PostInvoiceItem(Invoice invoice){
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
           return CreatedAtAction("GetInvoiceItem",new Invoice{invId=invoice.invId},invoice);
       }

        //PUT : api/invoice/n
        [HttpPut("{id}")]
        public ActionResult PutInvoiceItem(int id,Invoice invoice){
            if(id !=invoice.invId){
                return BadRequest();
            }
            _context.Entry(invoice).State= EntityState.Modified;
            _context.SaveChanges();
            return CreatedAtAction("GetInvoiceItem",new Invoice{invId=invoice.invId},invoice);
        }
        //DELETE : api/invoice/n
        [HttpDelete("{id}")]
        public ActionResult<Invoice> DeleteInvoiceItem(int id){
            var invoiceItem=_context.Invoice.Find(id);
            if(invoiceItem == null){
                return NotFound();
            }
            _context.Invoice.Remove(invoiceItem);
            _context.SaveChanges();
            return invoiceItem;
        }
    }
}
