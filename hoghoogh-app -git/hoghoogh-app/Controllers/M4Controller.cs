using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_app.Controllers
{
    public class M4Controller : Controller
    {
        ///////////



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


        // GET: HomeController
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
            return View();
        }

        // GET: HomeController/Details/5
       /* public ActionResult Details()
        {
            List<Models.Home> L_Home = new List<Models.Home>();
            try
            {
                RestClient client = new RestClient("https://localhost:44312/api/Home_API/home_data_all");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Subset = response.Content;
                L_Home = JsonConvert.DeserializeObject<List<Models.Home>>(L_Subset);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(L_Home[0].M4);
        }

        // GET: HomeController/Create
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

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Models.L_T_T_F h_d)
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
                *//*hd.M1_L_4.RemoveAll(item => item.mesdagh_image_file == null && item.mesdagh_text == null);
                hd.masadigh_EN_main.RemoveAll(item => item.mesdagh_image_file == null && item.mesdagh_text == null);
                hd.text_left_bottom.RemoveAll(item => item.txt == null);
                hd.text_right_bottom.RemoveAll(item => item.txt == null);
                hd.shakhes_EN_main.RemoveAll(item => item.txt == null);*//*





                foreach (var item in h_d.L_t_t_f)
                {
                    if (item.file != null)
                    {
                        //Getting FileName
                        var fileName = Path.GetFileName(item.file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.

                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Media/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;

                        string only_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media");
                        filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media") + $@"\{newFileName}";


                        //linux
                        string name_f = filepath; string new_name_f = ""; foreach (var c in filepath) { if (c.ToString() == "\\") { new_name_f = new_name_f + "/"; } else { new_name_f = new_name_f + c; } }
                        filepath = new_name_f;

                        if (!Directory.Exists(only_path))
                            Directory.CreateDirectory(only_path);
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            item.file.CopyTo(fs);
                            fs.Flush();
                        }
                        item.file = null;
                        item.file_address = Path.Combine($@"\" + "Media", newFileName);
                    }
                }


                RestClient client = new RestClient("https://localhost:44312/api/Home_API/home_data_all");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Subset = response.Content;
                List<Models.Home> L_Home = JsonConvert.DeserializeObject<List<Models.Home>>(L_Subset);

                L_Home[0].M4 = h_d;




                client = new RestClient("https://localhost:44316/api/Home_API/create");
                client.Timeout = -1;
                request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                string json_subset = JsonConvert.SerializeObject(L_Home[0]);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                request.AddParameter("application/json,text/plain", json_subset, ParameterType.RequestBody);
                response = client.Execute(request);
                string content = response.Content;
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    if (content == "\"OK\"")
                    {

                        ViewBag.edited = "1";

                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Redirect("#");
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit()
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

            List<Models.Home> L_Home = new List<Models.Home>();
            try
            {
                RestClient client = new RestClient("https://localhost:44316/api/Home_API/home_data_all");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Subset = response.Content;
                L_Home = JsonConvert.DeserializeObject<List<Models.Home>>(L_Subset);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View(L_Home[0].M4);
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.L_T_T_F n_M4)
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
            List<Models.Home> L_Home = new List<Models.Home>();
            try
            {
                RestClient client = new RestClient("https://localhost:44316/api/Home_API/home_data_all");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                string cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                IRestResponse response = client.Execute(request);
                string L_Subset = response.Content;
                L_Home = JsonConvert.DeserializeObject<List<Models.Home>>(L_Subset);
                Models.Home o_home = L_Home[0];

                int n = 0;
                foreach (var item in n_M4.L_t_t_f)
                {

                    if (item.file == null)
                    {
                        *//*if (n < o_home.masadigh_EN_main.Count)
                        {*//*
                        item.file_address = o_home.M4.L_t_t_f[n].file_address;
                        *//*}*//*
                    }
                    else
                    {

                        //Getting FileName
                        var fileName = Path.GetFileName(item.file.FileName);

                        //Assigning Unique Filename (Guid)
                        var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                        //Getting file Extension
                        var fileExtension = Path.GetExtension(fileName);

                        // concatenating  FileName + FileExtension
                        var newFileName = String.Concat(myUniqueFileName, fileExtension);

                        // Combines two strings into a path.

                        var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Images/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;

                        string only_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images");
                        filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images") + $@"\{newFileName}";


                        //linux
                        string name_f = filepath; string new_name_f = ""; foreach (var c in filepath) { if (c.ToString() == "\\") { new_name_f = new_name_f + "/"; } else { new_name_f = new_name_f + c; } }
                        filepath = new_name_f;

                        if (!Directory.Exists(only_path))
                            Directory.CreateDirectory(only_path);
                        using (FileStream fs = System.IO.File.Create(filepath))
                        {
                            item.file.CopyTo(fs);
                            fs.Flush();
                        }
                        System.IO.File.Delete(o_home.M4.L_t_t_f[n].file_address);
                        item.file = null;
                        item.file_address = Path.Combine($@"\" + "Media", newFileName);
                    }

                    n++;
                }

                o_home.M4 = n_M4;

                client = new RestClient("https://localhost:44316/api/Home_API/edite");
                client.Timeout = -1;
                request = new RestRequest(Method.PUT);
                string json_user = JsonConvert.SerializeObject(o_home);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", "6ee5531a624dbf80b4454b9f9db0eb7f62a314c8");
                //user in header
                cookieValue = Request.Cookies["token"];
                request.AddHeader("User", cookieValue);
                //
                request.AddParameter("application/json,text/plain", json_user, ParameterType.RequestBody);
                response = client.Execute(request);
                string content = response.Content;



            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return Redirect("#");
        }

*/






        ////////////////
    }
}
