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
    public class User_APIController : ControllerBase
    {
        private Context context;
        public User_APIController()
        {
            context = new Context();
        }

        // GET: api/User_API
        [HttpGet("Users")]
        public IActionResult Get()
        {

            //var users = context.Users.Find(_ => true).ToList();
            //return users;
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    var users = context.User.Find(_ => true).ToList();
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Get_List";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = "all";
                    context.Log.InsertOne(log);
                    //
                    return Ok(users);
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
        [HttpGet("User/{id}")]

        public IActionResult Get(string id)
        {

            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {

                try
                {
                    var user = context.User.Find(x => x.Id == id).ToList();
                    Models.User u1 = new Models.User();
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
        public IActionResult create([FromBody] Models.User user)
        {
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    security.Coding coding = new security.Coding();
                    Models.User user_Chek = new Models.User();
                    string S_role = "";
                    string S_user = "";

                    if (user.user_name != null)
                    {
                        user.user_name = user.user_name.Trim().ToLower();
                        List<Models.User> users = context.User.AsQueryable<Models.User>().ToList();
                        user_Chek = users.Find(a => a.user_name == user.user_name);
                    }


                    if (user_Chek == null)
                    {
                        //fill token & sh1 pass
                        if (user.password != null)
                        {
                            string NewPass = coding.Sha1Sum(user.password);
                            user.password = NewPass;
                        }
                        //fill token 
                        /*if (user.role != null)
                        {
                            S_role = coding.Sha1Sum(user.role);
                        }*/
                        S_role = coding.Sha1Sum(user.role);
                        S_user = coding.Sha1Sum(user.user_name);
                        user.token = user.password + S_role+S_user ;

                        context.User.InsertOne(user);
                        //log
                        Models.Log log = new Models.Log();
                        log.user = Request.Headers["User"];
                        log.action = "Create";
                        log.time = DateTime.Now;
                        log.subject = "User";
                        log.obj = user.Id;
                        context.Log.InsertOne(log);
                        //
                        return Ok("OK");
                    }
                    else
                    {
                        return Ok("Dublicate");
                    }
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
        public IActionResult edite([FromBody] Models.User user)
        {
            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    security.Coding coding = new security.Coding();
                    string S_role = "";
                    string S_user = "";

                    if (string.IsNullOrEmpty(user.password))
                    {
                        var use = context.User.Find(x => x.Id == user.Id).ToList();
                        Models.User u1 = new Models.User();
                        u1 = use[0];
                        user.password = u1.password;
                    }
                    else
                    {
                        string NewPass = coding.Sha1Sum(user.password);
                        user.password = NewPass;
                    }


                    //fill token 
                    /*if (user.role != null)
                    {
                        S_role = coding.Sha1Sum(user.role);
                    }*/
                    S_role = coding.Sha1Sum(user.role);
                    S_user = coding.Sha1Sum(user.user_name);
                    user.token = user.password + S_role+ S_user;

                    context.User.DeleteOne(a => a.Id == user.Id);
                    context.User.InsertOne(user);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Edite";
                    log.time = DateTime.Now;
                    log.subject = "User";
                    log.obj = user.user_name;
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
                    context.User.DeleteOne(a => a.Id == id);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Delete";
                    log.time = DateTime.Now;
                    //DateTime date = DateTime.UtcNow;
                    log.subject = "User";
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
