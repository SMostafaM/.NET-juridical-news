using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_app.Controllers
{
    public class UserController : Controller
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

        // GET: UserController
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

            List<Models.User> list_users = new List<Models.User>();
            try
            {
                RestClient client = new RestClient("https://localhost:44312/api/User_API/Users");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Users = response.Content;
                list_users = JsonConvert.DeserializeObject<List<Models.User>>(L_Users);
                Models.Home L_Home = new Models.Home();
               
                //ViewBag.home = L_Home;
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(list_users);
        }



        // GET: UserController/Details/5
        public ActionResult Details(string id)
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

            Models.User user = new Models.User();
            try
            {

                RestClient client = new RestClient("https://localhost:44312/api/User_API/User/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string User = response.Content;
                user = JsonConvert.DeserializeObject<Models.User>(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(user);
        }

        // GET: UserController/Create
        public ActionResult Create()
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
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.User user)
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



            try
            {
                var client = new RestClient("https://localhost:44312/api/User_API/create");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                string json_user = JsonConvert.SerializeObject(user);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                request.AddParameter("application/json,text/plain", json_user, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (content == "\"Dublicate\"")
                    {
                        //ModelState.AddModelError("user_name", "لطفا نام کاربری دیگری انتخاب کنید");
                        ViewBag.edited = "0";
                    }
                    if (content == "\"OK\"")
                    {
                        //ModelState.AddModelError("user_name", "ایجاد کاربر با موفقیت انجام شد");
                        ViewBag.edited = "1";

                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View();
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
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

            Models.User user = new Models.User();
            try
            {

                RestClient client = new RestClient("https://localhost:44312/api/User_API/User/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string User = response.Content;
                user = JsonConvert.DeserializeObject<Models.User>(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(user);
        }

        // POST: UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(/*int id, IFormCollection collection*/Models.User user)
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

            try
            {

                RestClient client = new RestClient("https://localhost:44312/api/User_API/edite");
                client.Timeout = -1;
                var request = new RestRequest(Method.PUT);
                string json_user = JsonConvert.SerializeObject(user);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                request.AddParameter("application/json,text/plain", json_user, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                string content = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    ViewBag.edited = "1";

                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View();
        }

        // GET: UserController/Delete/5
        public ActionResult Delete(string id)
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


            try
            {
                string url = String.Concat("https://localhost:44312/api/User_API/delete/" + id);
                RestClient client = new RestClient(url);
                client.Timeout = -1;
                var request = new RestRequest(Method.DELETE);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_U = response.Content;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Redirect("~/User/Index");

        }



    }
}
