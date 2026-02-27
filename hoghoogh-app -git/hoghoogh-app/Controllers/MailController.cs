using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_app.Controllers
{
    public class MailController : Controller
    {
        public int Chek_cooke()
        {
            int C = 0;
            if (Request.Cookies["token"] != null)
            {
                string cookieValue = Request.Cookies["token"];
                var cook = new Microsoft.AspNetCore.Http.CookieOptions() { Path = "/", HttpOnly = false, IsEssential = true, Expires = DateTime.Now.AddHours(1) };
                Response.Cookies.Append("token", cookieValue, cook);
                C = 1;
            }

            return C;
        }

        public string chek_Roel()
        {
            security.Coding coding = new security.Coding();
            string R = "";
            string Role = "";
            string cookieValue = Request.Cookies["token"];
            for (int i = 40; i < 80; i++)
            {
                Role = Role + cookieValue[i];
            }
            string zerosha1 = coding.Sha1Sum("0");
            if (zerosha1 == Role)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public ActionResult Index()
        {
            int C = Chek_cooke();
            if (C != 1)
            {
                return Redirect("~/login/login");
            }
            string R = chek_Roel();
            if (R != "1")
            {
                Response.Cookies.Delete("token");
                return Redirect("~/login/login");
            }

            List<Models.Mail> list_users = new List<Models.Mail>();
            try
            {
                RestClient client = new RestClient("https://localhost:44312/api/Mail_API/Mail_All");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Users = response.Content;
                list_users = JsonConvert.DeserializeObject<List<Models.Mail>>(L_Users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(list_users);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string mail)
        { 
            
            try
            {
                Models.Mail m = new Models.Mail();
                m.mail = mail;
                var client = new RestClient("https://localhost:44312/api/Mail_API/create");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                string json_user = JsonConvert.SerializeObject(m);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                request.AddParameter("application/json,text/plain", json_user, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (content == "\"OK\"")
                    {
                        //ModelState.AddModelError("user_name", "ایجاد کاربر با موفقیت انجام شد");
                        ViewBag.edited = "1";

                    }
                }
                return Redirect("~/Home/index");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }
    }
}
