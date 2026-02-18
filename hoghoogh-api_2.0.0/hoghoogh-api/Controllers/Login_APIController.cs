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
    public class Login_APIController : ControllerBase
    {
        private Context context;
        public Login_APIController()
        {
            context = new Context();
        }

        // POST: api/Login
        [HttpPost("login")]
        public IActionResult login([FromBody] Models.User user)
        {
            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {

                try
                {
                    security.Coding coding = new security.Coding();
                    string NewPass = coding.Sha1Sum(user.password);
                    user.password = NewPass;
                    user.user_name = user.user_name.Trim().ToLower();

                    var user_Chek = context.User.Find(x => x.user_name == user.user_name).ToList();
                    if (user_Chek.Count == 0)
                    {
                        //log
                        Models.Log log = new Models.Log();
                        log.user = user.user_name;
                        log.action = "login";
                        log.time = DateTime.Now;
                        log.subject = "Bad_username";
                        log.obj = user.user_name;
                        context.Log.InsertOne(log);
                        //
                        return NotFound("NotFound");
                    }
                    else
                    {
                        foreach (var item in user_Chek)
                        {
                            if (item.password == user.password)
                            {
                                //log
                                Models.Log log = new Models.Log();
                                log.user = item.user_name;
                                log.action = "login";
                                log.time = DateTime.Now;
                                //DateTime date = DateTime.UtcNow;
                                log.subject = "Loged_in";
                                log.obj = item.Id;
                                context.Log.InsertOne(log);
                                //
                                string sha1_Role = coding.Sha1Sum(item.role);
                                item.role = sha1_Role;

                                return Ok(item);
                            }
                            else
                            {
                                //log
                                Models.Log log = new Models.Log();
                                log.user = item.user_name;
                                log.action = "login";
                                log.time = DateTime.Now;
                                //DateTime date = DateTime.UtcNow;
                                log.subject = "Bad_Pass";
                                log.obj = item.Id;
                                context.Log.InsertOne(log);
                                //


                                return NotFound("NotFound");
                            }
                        }

                    }

                    return NotFound("NotFound");
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

    }
}
