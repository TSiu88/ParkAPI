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
  public class ParksController : ControllerBase
  {
    private ParkApiContext _db;

    public ParksController(ParkApiContext db)
    {
      _db = db;
    }

    // GET api/parks
    [HttpGet]
    public ActionResult<IEnumerable<Park>> Get(string name, string type, string description, string location, string state)
    {
      var query = _db.Parks.Include(entry => entry.State).AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name.Contains(name));
      }
      if (type != null)
      {
        query = query.Where(entry => entry.Type == type);
      }
      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
      }
      if (state != null)
      {
        query = query.Where(entry => entry.State.Name == state);
      }
      if (description != null)
      {
        query = query.Where(entry => entry.Description.Contains(description));
      }
      return query.ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    // POST api/parks
    [HttpPost]
    public void Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();

      State state = _db.States.Find(park.StateId);
      state.NumberParks++;
      _db.SaveChanges();
    }

    // PUT api/parks/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      
      //_db.Parks.Attach(park);
      var currentChange = _db.Entry(park).CurrentValues.Clone();
      //_db.Entry(park).Reload();
      
      var original = _db.Entry(park).OriginalValues.Clone();
      //GetValue<State>("State");
      //original.NumberParks--;

      //var query = _db.Parks.Include(entry => entry.State).AsQueryable();
      
      //State initial = query.FirstOrDefault(x=>x.ParkId == id).State;
      //initial.NumberParks--;

      _db.Entry(park).CurrentValues.SetValues(currentChange);
      _db.Entry(park).State = EntityState.Modified; 
      // int initialStateId = _db.Entry(park).Property(u=>u.StateId).OriginalValue;
      // Console.WriteLine("initial ", initialStateId);
      // int currentStateId = _db.Entry(park).Property(u=>u.StateId).CurrentValue;
      // Console.WriteLine("current ", currentStateId);
      _db.SaveChanges();

      // int initialStateId = _db.Parks.FirstOrDefault(entry => entry.ParkId == id).StateId;
      // State initialState = _db.States.Find(initialStateId);
      // int increaseNumber = _db.States.Where(entry=> entry.StateId == initialStateId)
      // .Include(entry=> entry.Parks).SelectMany(entry=> entry.Parks).Count();
      // initialState.NumberParks = increaseNumber;
      // State state = _db.States.Find(park.StateId);
      // int decreaseNumber = _db.States.Where(entry=> entry.StateId == park.StateId)
      // .SelectMany(entry=> entry.Parks).Count();
      // state.NumberParks = decreaseNumber;

      State old = _db.States.FirstOrDefault(x=>x.StateId == original.GetValue<int>("StateId"));
      old.NumberParks--;

      State current = _db.States.FirstOrDefault(x=>x.StateId == currentChange.GetValue<int>("StateId"));
      current.NumberParks++;
      _db.SaveChanges();
    }

    // DELETE api/parks/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      State state = _db.States.FirstOrDefault(entry=> entry.StateId == parkToDelete.StateId);
      state.NumberParks--;
      _db.Parks.Remove(parkToDelete);
      _db.SaveChanges();
    }
  }
}