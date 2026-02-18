using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Home_APIController : ControllerBase
    {
        //////////////


        private Context context;
        public Home_APIController()
        {
            context = new Context();
        }

        // GET: api/<Home_data_APIController>
        [HttpGet("home_data_all")]
        public IActionResult Get()
        {

            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {
                try
                {
                    List<Models.Home> home_data = new List<Models.Home>();
                    home_data = context.Home.Find(_ => true).ToList();
                    Models.Home home = new Models.Home();
                    if(home_data.Count != 0)
                    {
                        home = home_data[0];
                    }
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Get_List";
                    log.time = DateTime.Now;
                    log.subject = "Home_data";
                    log.obj = "all";
                    context.Log.InsertOne(log);
                    //
                    return Ok(home);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("bad_atho");
            }

        }

        // GET api/<Home_data_APIController>/5
        [HttpGet("home_data/{id}")]

        public IActionResult Get(string id)
        {

            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {

                try
                {
                    var home_data = context.Home.Find(x => x.Id == id).ToList();
                    Models.Home d1 = new Models.Home();
                    d1 = home_data[0];
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Get";
                    log.time = DateTime.Now;
                    log.subject = "Home_data";
                    log.obj = d1.Id;
                    context.Log.InsertOne(log);
                    //
                    return Ok(d1);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("bad_atho");
            }
        }

        // POST api/<Home_data_APIController>
        [HttpPost("create")]
        public IActionResult create([FromBody] Models.Home home_data)
        {
            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {
                try
                {
                    context.Home.DeleteMany(a => true);
                    context.Home.InsertOne(home_data);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Create";
                    log.time = DateTime.Now;
                    log.subject = "Home_data";
                    log.obj = home_data.Id;
                    context.Log.InsertOne(log);
                    //
                    return Ok("OK");

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("bad_atho");
            }
        }
        // PUT api/<Home_data_APIController>/5
        [HttpPut("edite")]
        public IActionResult edite([FromBody] Models.Home home_data)
        {
            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {
                try
                {

                    context.Home.DeleteMany(a => true);
                    context.Home.InsertOne(home_data);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Edite";
                    log.time = DateTime.Now;
                    log.subject = "home_data";
                    log.obj = home_data.Id;
                    context.Log.InsertOne(log);
                    //
                    return Ok("ok");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("bad_atho");
            }
        }

        // DELETE api/<Home_data_APIController>/5
        [HttpDelete("delete/{id}")]

        public IActionResult Delete(string id)
        {
            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {
                try
                {
                    context.Home.DeleteOne(a => a.Id == id);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Delete";
                    log.time = DateTime.Now;
                    //DateTime date = DateTime.UtcNow;
                    log.subject = "Home_data";
                    log.obj = id;
                    context.Log.InsertOne(log);
                    //
                    return Ok("deleted");
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);

                }
            }
            else
            {
                return BadRequest("bad_atho");
            }
        }










        ///////////////////
    }
}
