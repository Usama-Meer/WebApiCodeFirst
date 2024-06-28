using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebApiCodeFirst.Models;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace WebApiCodeFirst.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CustomerController : ControllerBase
{
    private readonly SampleDBContext _context;
    public CustomerController(SampleDBContext context)
    {
        _context = context;
    }

    //GET: api/Customer
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> GetCustomers()
    {
        return _context.Customers.ToList();
    }

    //GET: api/Customer/1
    [HttpGet("{id}")]
    public ActionResult<Customer> GetCustomers(int id)

    {
        var customer = _context.Customers.Find(id);
        if (customer == null)
        {
            return NotFound();
        }
        return Ok(customer);
    }

    //POST: api/Customer

    [HttpPost]
    public ActionResult<Customer> CreateCustomer(Customer customer)
    {
        if (customer==null)
        {
            return BadRequest("");
        }
        _context.Customers.Add(customer);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetCustomers),new {id=customer.CustomerId},customer);
    }
}