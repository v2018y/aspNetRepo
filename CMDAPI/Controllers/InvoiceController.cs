using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CMDAPI.Models;
using Microsoft.EntityFrameworkCore;
// This line Give the IActions Result
using System.Linq;


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
        public IActionResult GetInvoice(){
            var user=Request.Headers["userId"];
            return Ok(_context.Invoice.Where(s => s.userId == Convert.ToInt32(user)));
        }

        //GET : api/invoice/n
        [HttpGet("{id}")]
        public IActionResult GetInvoiceItem(int id){
            var invoiceItem= _context.Invoice.Where(s=> s.invId == id);
            if(invoiceItem == null){
                return NotFound();
            }
            return Ok(invoiceItem);
        }

        //POST : api/invoice
        [HttpPost]
        public IActionResult PostInvoiceItem(Invoice invoice){
            var user=Request.Headers["userId"];
            invoice.userId=Convert.ToInt32(user);
            _context.Invoice.Add(invoice);
            _context.SaveChanges();
            return GetInvoiceItem(invoice.invId);
       }

        //PUT : api/invoice/n
        [HttpPut("{id}")]
        public IActionResult PutInvoiceItem(int id,Invoice invoice){
            if(id !=invoice.invId){
                return BadRequest();
            }
            _context.Entry(invoice).State= EntityState.Modified;
            _context.SaveChanges();
            return GetInvoiceItem(invoice.invId);
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
