using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkApi.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ParkApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class StatesController : ControllerBase
  {
    private ParkApiContext _db;

    public StatesController(ParkApiContext db)
    {
      _db = db;
    }

    // GET api/states
    [HttpGet]
    public ActionResult<IEnumerable<State>> Get(string name)
    {
      var query = _db.States.Include(entry => entry.Parks).AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      return query.ToList();
    }

    // GET api/states/5
    [HttpGet("{id}")]
    public ActionResult<State> Get(int id)
    {
      return _db.States.FirstOrDefault(entry => entry.StateId == id);
    }

    // POST api/states
    [HttpPost]
    public void Post([FromBody] State state)
    {
      _db.States.Add(state);
      state.NumberParks = 0;
      _db.SaveChanges();
    }

    // PUT api/states/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] State state)
    {
      state.StateId = id;
      _db.Entry(state).State = EntityState.Modified; 
      _db.SaveChanges();
    }

    // DELETE api/states/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var stateToDelete = _db.States.FirstOrDefault(entry => entry.StateId == id);
      _db.States.Remove(stateToDelete);
      _db.SaveChanges();
    }
  }
}