using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace hoghoogh_app.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult login()
        {

            return View();
        }
        [HttpPost]
        public IActionResult login(Models.User user)
        {
            if (string.IsNullOrEmpty(user.user_name) || string.IsNullOrEmpty(user.password))
            {
                ViewBag.check = "0";
            }
            else
            {
                security.Coding coding = new security.Coding();
                try
                {
                    
                    var client = new RestClient("https://localhost:44312/api/Login_API/login");
                    client.Timeout = -1;
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/json");
                    string json_user = JsonConvert.SerializeObject(user);
                    request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                    request.AddParameter("application/json", json_user, ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    string content = response.Content;
                    if (content == "\"NotFound\"")
                    {
                        ViewBag.check = "1";

                    }
                    if (content == "")
                    {
                        ViewBag.check = "2";

                    }
                    else
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            Models.User u = JsonConvert.DeserializeObject<Models.User>(content);

                            var cook = new Microsoft.AspNetCore.Http.CookieOptions() { Path = "/", HttpOnly = false, IsEssential = true, Expires = DateTime.Now.AddHours(1) };
                            Response.Cookies.Append("token", u.token, cook);

                            
                            //string onesha1 = coding.Sha1Sum("1");
                            string zerosha1 = coding.Sha1Sum("0");
                            /*switch (u.role)
                            {
                                case "0":
                                    return Redirect("~/Home/metro_menu");
                                    break;
                                case "1":
                                    return Redirect("~/Home/metro_menu");
                                    break;
                            }*/
                            /*if (u.role == onesha1)
                            {
                                return Redirect("~/Home/metro_menu");
                            }*/
                            if (u.role == zerosha1)
                            {
                                return Redirect("~/dashboard/index");
                            }
                            //CookieOptions options = new CookieOptions();
                            //options.Expires = DateTime.Now.AddDays(1);
                            //response.Cookies.Append("token", u.Password);
                        }

                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);

                }
            }
            return View();
        }
    }
}

