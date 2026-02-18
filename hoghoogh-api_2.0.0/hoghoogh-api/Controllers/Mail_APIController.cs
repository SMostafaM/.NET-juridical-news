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
    public class Mail_APIController : ControllerBase
    {
        private Context context;
        public Mail_APIController()
        {
            context = new Context();
        }


        // GET: api/User_API
        [HttpGet("Mail_All")]
        public IActionResult Get()
        {


            if (Request.Headers["Authorization"] == "88cd45321ebe35932e0bcea87bc446e164f47e39")
            {
                try
                {
                    var data = context.Mail.Find(_ => true).ToList();
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
        // POST api/<MailController>
        [HttpPost("create")]
        public IActionResult create([FromBody] Models.Mail mail)
        {
            if (Request.Headers["Authorization"] == "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8")
            {
                try
                {
                    context.Mail.InsertOne(mail);
                    //log
                    Models.Log log = new Models.Log();
                    log.user = Request.Headers["User"];
                    log.action = "Create";
                    log.time = DateTime.Now;
                    log.subject = "add-Mail";
                    log.obj = mail.mail;
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
    }
}
