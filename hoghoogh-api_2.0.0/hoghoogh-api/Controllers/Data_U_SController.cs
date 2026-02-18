using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hoghoogh_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Data_U_SController : ControllerBase
    {
        private Context context;
        public Data_U_SController()
        {
            context = new Context();
        }

        // GET: api/User_API
        [HttpGet("Data_All")]
        public IActionResult Get()
        {


            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    var data = context.Data_U_S.Find(_ => true).ToList();
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Get_List";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = "all";
                    context.Log.InsertOne(log);
                    //
                    return Ok(data);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("BadRequest");
            }

        }

        // GET: api/User_API/5
        [HttpGet("Data/{id}")]

        public IActionResult Get(string id)
        {

            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {

                try
                {
                    var user = context.Data_U_S.Find(x => x.Id == id).ToList();
                    Models.Data_U_S u1 = new Models.Data_U_S();
                    u1 = user[0];
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Get";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = u1.Id;
                    context.Log.InsertOne(log);
                    //
                    return Ok(u1);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        // POST: api/User_API
        [HttpPost("create")]
        public IActionResult create([FromBody] Models.Data_U_S data)
        {
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {

                    context.Data_U_S.InsertOne(data);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Create";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = data.Id;
                    context.Log.InsertOne(log);

                    return Ok("OK");

                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            else
            {
                return BadRequest("BadRequest");
            }
        }

        [HttpPut("edite")]
        public IActionResult edite([FromBody] Models.Data_U_S data)
        {
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                   
                    context.Data_U_S.DeleteOne(a => a.Id == data.Id);
                    context.Data_U_S.InsertOne(data);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Edite";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = data.email;
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
                return BadRequest("BadRequest");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("delete/{id}")]

        public IActionResult Delete(string id)
        {
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    context.Data_U_S.DeleteOne(a => a.Id == id);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Delete";
                    log.time = DateTime.Now;
                    //DateTime date = DateTime.UtcNow;
                    log.subject = "data_U_S";
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
                return BadRequest("BadRequest");
            }
        }
    }
}
