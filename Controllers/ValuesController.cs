using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCOREFORM.Models;
using Newtonsoft.Json;

namespace ASPNETCOREFORM.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public List<Test> Get()
        {
            var data = new List<Test>();
            using (var db = new InventoryContext())
            {
                data = db.Inventories.ToList();
            }
            return data;

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public List<Test> Get(int id)
        {
            var data = new List<Test>();
            using (var db = new InventoryContext())
            {
                data = db.Inventories.Where(x => x.TestId == id).ToList();
            }
            return data;



        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Test value)
        {
            //Console.WriteLine(value.ItemName);
            using (var db = new InventoryContext())
            {
                db.Inventories.Add(value);
                db.SaveChanges();
            }
            return "DONE!";
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
            /*
             You are going to format you request.
             /api/values/recordID
             Next, your data is going to be the object generated by the form.
             */
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
             using (var db = new InventoryContext())
            {
                var inventoryItem = db.Inventories.Where(x => x.TestId == id);

                if (inventoryItem.Count() > 0)
                {

                    var inventoryItemRecord = inventoryItem.SingleOrDefault();
                    db.Remove(inventoryItemRecord);
                    db.SaveChanges();

                    return "DONE!";

                }
                else
                {
                    return "No Record Found";
                }
            }
        }
    }
}
