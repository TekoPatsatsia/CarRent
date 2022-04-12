using Microsoft.AspNetCore.Mvc;
using Repository;
using DataAccess.Models;
using DataAccess;
using Repository.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoTrade.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }
        
        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            var cars= _carRepository.GetAll().ToList();
            return Ok(cars);
            //using (var db = new DataAccessService())
            //{
            //    return new CarRepository(db).GetAll();
            //}

        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get([FromBody]string id)
        {
            var car = _carRepository.Get(id);
            return Ok(car);


            //using (var db = new DataAccessService())
            //{
            //    return new CarRepository(db).Get(id);

            //}
        }


            // POST api/<CarsController>
        [HttpPost]
        public ActionResult<Car> Post(Car value)
        {
            var car=_carRepository.Add(value);
            return Ok(car);
            //using (var db = new DataAccessService())
            //{
            //    return new CarRepository(db).Add(value);
            //}
        }

            // PUT api/<CarsController>/5
            [HttpPut("{id}")]
        public void Put(Car id)
        {
            _carRepository.Update(id);

            //using (var db = new DataAccessService())
            //{
            //    new CarRepository(db).Update(value);
            //}
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(Car id)
        {
            _carRepository.Remove(id);
            //using (var db = new DataAccessService())
            //{
            //    new CarRepository(db).Remove(Car);
            //}
        }
    }
}
