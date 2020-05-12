using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ParkApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web;

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

    // [FromQuery]  Pager page,
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
      //   int count = query.Count();
      //   int currentPage = page.pageNumber;
      //   int pagingSize = page.pageSize;
      //   int totalPages = (int)Math.Ceiling(count/(double)pagingSize);
      //   query = query.Skip(pagingSize * (currentPage -1)).Take(pagingSize);

      //   var paginationMetadata = new  
      //   {   
      //     pageSize = pagingSize,  
      //     currentPage = currentPage,  
      //     totalPages = totalPages
      //   };  

      // // Setting Header  
      // HttpContext.Response.Headers.Add("Paging-Headers", JsonConvert.SerializeObject (paginationMetadata));  

      return query.ToList();
    }

    // GET api/parks/5
    [HttpGet("{id}")]
    public ActionResult<Park> Get(int id)
    {
      return _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
    }

    // GET api/search
    [HttpGet("search")]
    public ActionResult<IEnumerable<Park>> Search(string search)
    {
      var query = _db.Parks.Include(entry => entry.State).AsQueryable();
      if (search != null)
      {
        query = query.Where(entry => entry.Name.Contains(search) ||
          entry.Location.Contains(search) ||
          entry.Description.Contains(search));
      }
      return query.ToList();
    }

    // GET api/random
    [HttpGet("random")]
    public ActionResult<IEnumerable<Park>> GetRandom()
    {
      var random = new Random();
      var query = _db.Parks.Include(entry => entry.State).OrderBy(a => random.Next()).Take(3).ToList();
      return query.ToList();
    }

    // POST api/parks
    [HttpPost]
    public ActionResult<IEnumerable<Park>> Post([FromBody] Park park)
    {
      _db.Parks.Add(park);
      _db.SaveChanges();

      State state = _db.States.Find(park.StateId);
      state.NumberParks++;
      _db.SaveChanges();

      return _db.Parks.Include(entry => entry.State).ToList();
    }

    // PUT api/parks/5
    [HttpPut("{id}")]
    public ActionResult<IEnumerable<Park>> Put(int id, [FromBody] Park park)
    {
      park.ParkId = id;
      var currentChange = _db.Entry(park).CurrentValues.Clone();
      var original = _db.Entry(park).GetDatabaseValues();
      _db.Entry(park).CurrentValues.SetValues(currentChange);
      _db.Entry(park).State = EntityState.Modified;
      _db.SaveChanges();

      State old = _db.States.FirstOrDefault(x => x.StateId == original.GetValue<int>("StateId"));
      old.NumberParks--;

      State current = _db.States.FirstOrDefault(x => x.StateId == currentChange.GetValue<int>("StateId"));
      current.NumberParks++;
      _db.SaveChanges();

      return _db.Parks.Include(entry => entry.State).ToList();
    }

    // DELETE api/parks/5
    [HttpDelete("{id}")]
    public ActionResult<IEnumerable<Park>> Delete(int id)
    {
      var parkToDelete = _db.Parks.FirstOrDefault(entry => entry.ParkId == id);
      State state = _db.States.FirstOrDefault(entry => entry.StateId == parkToDelete.StateId);
      state.NumberParks--;
      _db.Parks.Remove(parkToDelete);
      _db.SaveChanges();
      return _db.Parks.Include(entry => entry.State).ToList();
    }
  }
}