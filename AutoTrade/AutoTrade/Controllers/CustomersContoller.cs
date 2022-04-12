using Microsoft.AspNetCore.Mvc;
using Repository;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using DataAccess.Models;
using Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersContoller : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomersContoller(ICustomerRepository customerRepository)
        {
            _CustomerRepository = customerRepository; 
        }
        // GET: api/<CustomersContoller>
        [HttpGet] 
        public ActionResult<IEnumerable<Customer>> Get()
        {
           var customers= _CustomerRepository.GetAll();
            return Ok(customers);


            //using(var db = new DataAccessService())
            //{
            // return new CustomerRepository(db).GetAll();
            //}
        }

        // GET api/<CustomersContoller>/5
        [HttpGet("{id}")]
        public Customer Get([FromBody]string id)
        {
            return _CustomerRepository.Get(id);

            //using (var db = new DataAccessService())
            //{
            //    return new CustomerRepository(db).Get(id);
            //}
        }

        // POST api/<CustomersContoller>
        [HttpPost]
        public Customer Post(Customer value)
        {
            return  _CustomerRepository.Add(value);

            //using (var db = new DataAccessService())
            //{
            //    return new CustomerRepository(db).Add(value);
            //}
        }

        // PUT api/<CustomersContoller>/5
        [HttpPut("{value}")]
        public void Put([FromBody] Customer value)
        {
            _CustomerRepository.Update(value);

            //using (var db = new DataAccessService())
            //{
            //    new CustomerRepository(db).Update(value);
            //}
        }

        // DELETE api/<CustomersContoller>/5
        [HttpDelete("{value}")]
        public void Delete(Customer value)
        {
            _CustomerRepository.Remove(value);

            //using (var db = new DataAccessService())
            //{
            //    new CustomerRepository(db).Remove(value);
            //}
        }
    }
}
