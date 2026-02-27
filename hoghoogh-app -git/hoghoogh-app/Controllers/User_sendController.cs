using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_app.Controllers
{
    public class User_sendController : Controller
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

            List<Models.Data_U_S> list_users = new List<Models.Data_U_S>();
            try
            {
                RestClient client = new RestClient("https://localhost:44312/api/Data_U_S/Data_All");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Users = response.Content;
                list_users = JsonConvert.DeserializeObject<List<Models.Data_U_S>>(L_Users);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(list_users);
        }



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

            Models.Data_U_S user = new Models.Data_U_S();
            try
            {

                RestClient client = new RestClient("https://localhost:44312/api/Data_U_S/Data/" + id);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "88cd45321ebe35932e0bcea87bc446e164f47e39");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string User = response.Content;
                user = JsonConvert.DeserializeObject<Models.Data_U_S>(User);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(user);
        }



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
                string url = String.Concat("https://localhost:44312/api/Data_U_S/delete/" + id);
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
            return Redirect("~/User_send/Index");

        }

    }
}
