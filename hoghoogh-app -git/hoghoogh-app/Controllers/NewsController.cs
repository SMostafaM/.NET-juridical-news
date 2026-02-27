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
    public class NewsController : Controller
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


        //deatail-create-edite
        // GET: HomeController/Details/5
/*        public ActionResult Details()
        {
            Models.Home L_Home = new Models.Home();
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
                L_Home = JsonConvert.DeserializeObject<Models.Home>(L_Subset);
                ViewBag.mini_news = L_Home.H_new;


                ////
                ///
                ///create complete null model from Home

                Models.Home send_home = new Models.Home();
                Models.M1_4_lttf send_M1 = new Models.M1_4_lttf();
                Models.L_T_T_F send_lttf = new Models.L_T_T_F();
                List<Models.T_T_F> send_l_lttf = new List<Models.T_T_F>();

                Models.T_T_F s_ttf = new Models.T_T_F();


                send_M1.L_t_t_f_1 = send_lttf;
                send_M1.L_t_t_f_2 = send_lttf;
                send_M1.L_t_t_f_3 = send_lttf;
                send_M1.L_t_t_f_4 = send_lttf;
                send_M1.L_t_t_f_1.L_t_t_f = send_l_lttf;
                send_M1.L_t_t_f_2.L_t_t_f = send_l_lttf;
                send_M1.L_t_t_f_3.L_t_t_f = send_l_lttf;
                send_M1.L_t_t_f_4.L_t_t_f = send_l_lttf;

                send_M1.L_t_t_f_1.L_t_t_f.Add(s_ttf);
                send_M1.L_t_t_f_2.L_t_t_f.Add(s_ttf);
                send_M1.L_t_t_f_3.L_t_t_f.Add(s_ttf);
                send_M1.L_t_t_f_4.L_t_t_f.Add(s_ttf);

                send_lttf.L_t_t_f.Add(s_ttf);

                send_home.M2 = send_lttf;
                //send_home.M2.L_t_t_f.Add(s_ttf);

                send_home.M3 = send_lttf;
                //send_home.M3.L_t_t_f.Add(s_ttf);

                send_home.M4 = send_lttf;
                //send_home.M4.L_t_t_f.Add(s_ttf);

                send_home.slider = send_lttf;
                //send_home.slider.L_t_t_f.Add(s_ttf);

                send_home.news = send_lttf;
                //send_home.news.L_t_t_f.Add(s_ttf);

                send_home.left_img = send_lttf;
                //send_home.left_img.L_t_t_f.Add(s_ttf);

                send_home.M1_L_4 = send_M1;
                /////


                if (L_Home.M1_L_4.L_t_t_f_1.L_t_t_f != null)
                {
                    L_Home.M1_L_4.L_t_t_f_1.L_t_t_f.AddRange(send_l_lttf);
                }
                else
                {
                    L_Home.M1_L_4.L_t_t_f_1.L_t_t_f = send_l_lttf;
                }

                if (L_Home.M1_L_4.L_t_t_f_2.L_t_t_f != null)
                {
                    L_Home.M1_L_4.L_t_t_f_2.L_t_t_f.AddRange(send_l_lttf);
                }
                else
                {
                    L_Home.M1_L_4.L_t_t_f_2.L_t_t_f = send_l_lttf;
                }

                if (L_Home.M1_L_4.L_t_t_f_3.L_t_t_f != null)
                {
                    L_Home.M1_L_4.L_t_t_f_3.L_t_t_f.AddRange(send_l_lttf);
                }
                else
                {
                    L_Home.M1_L_4.L_t_t_f_3.L_t_t_f = send_l_lttf;
                }

                if (L_Home.M1_L_4.L_t_t_f_4.L_t_t_f != null)
                {
                    L_Home.M1_L_4.L_t_t_f_4.L_t_t_f.AddRange(send_l_lttf);
                }
                else
                {
                    L_Home.M1_L_4.L_t_t_f_4.L_t_t_f = send_l_lttf;
                }
                /////

                if (L_Home.M2 == null)
                {
                    L_Home.M2 = send_lttf;
                }
                else
                {
                    L_Home.M2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.M3 == null)
                {
                    L_Home.M3 = send_lttf;
                }
                else
                {
                    L_Home.M3.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.M4 == null)
                {
                    L_Home.M4 = send_lttf;
                }
                else
                {
                    L_Home.M4.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.M5 == null)
                {
                    L_Home.M5 = send_lttf;
                }
                else
                {
                    L_Home.M5.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.slider == null)
                {
                    L_Home.slider = send_lttf;
                }
                else
                {
                    L_Home.slider.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.left_img == null)
                {
                    L_Home.left_img = send_lttf;
                    L_Home.left_img.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                else
                {
                    L_Home.left_img.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.left_img.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.video == null)
                {
                    L_Home.video = send_lttf;
                }
                else
                {
                    L_Home.video.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.news == null)
                {
                    L_Home.news = send_lttf;
                    L_Home.news.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                else
                {
                    L_Home.news.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.news.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.left_1 == null)
                {
                    L_Home.left_1 = send_lttf;
                    L_Home.left_1.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                else
                {
                    L_Home.left_1.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.left_1.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                if (L_Home.left_2 == null)
                {
                    L_Home.left_2 = send_lttf;
                    L_Home.left_2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                else
                {
                    L_Home.left_2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.left_2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }

                if (L_Home.left_3 == null)
                {
                    L_Home.left_3 = send_lttf;
                    L_Home.left_3.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                else
                {
                    L_Home.left_3.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.left_3.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                }
                if (L_Home.H_new.txt == null || L_Home.H_new == null)
                {
                    List<string> s = new List<string>();
                    Models.new_news_mini ss = new Models.new_news_mini();
                    L_Home.H_new = ss;
                    L_Home.H_new.txt = s;
                }
                //////////////////////



                return View(L_Home);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
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
        public ActionResult Create(Models.L_T_T_F h_d , Models.new_news_mini h_new , string state)
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
                h_d.L_t_t_f.RemoveAll(item => item.file == null && item.title == null && item.txt == null);
                h_new.txt.RemoveAll(item => item == null);
                


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

                       *//* var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Media/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;*//*

                        string only_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media");
                        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media") + $@"\{newFileName}";


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
                        item.file_address = Path.Combine($@"/" + "Media", newFileName);
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
                Models.Home L_Home = JsonConvert.DeserializeObject<Models.Home>(L_Subset);

                if (state == "1")
                {
                    try
                    {
                        if (L_Home.news != null)
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.news.L_t_t_f);
                            L_Home.news.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        if (L_Home.H_new != null && L_Home.H_new.txt != null)
                        {
                            //h_new.txt.AddRange(L_Home.H_new.txt);
                            L_Home.H_new.txt.AddRange(h_new.txt);
                        }
                    }
                    catch
                    {
                        L_Home.news = h_d;
                        L_Home.H_new = h_new;
                    }
                }
                else
                {
                    L_Home.news = h_d;
                    L_Home.H_new = h_new;
                }
                




                client = new RestClient("https://localhost:44312/api/Home_API/create");
                client.Timeout = -1;
                request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                string json_subset = JsonConvert.SerializeObject(L_Home);
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

            Models.Home L_Home = new Models.Home();
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
                L_Home = JsonConvert.DeserializeObject<Models.Home>(L_Subset);

                ViewBag.h_n = L_Home.H_new;

                ///
                if (L_Home.H_new.txt == null || L_Home.H_new == null)
                {
                    List<string> s = new List<string>();
                    Models.new_news_mini ss = new Models.new_news_mini();
                    L_Home.H_new = ss;
                    L_Home.H_new.txt = s;
                }
                ///
                return View(L_Home.news);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Models.L_T_T_F n_news , Models.new_news_mini h_new)
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
            Models.Home o_home = new Models.Home();
            try
            {

                if (n_news.L_t_t_f != null) { n_news.L_t_t_f.RemoveAll(item => item.file == null && item.title == null && item.txt == null); }
                else
                {
                    List<Models.T_T_F> lt = new List<Models.T_T_F>();
                    n_news.L_t_t_f = lt;
                }
                if (h_new.txt !=null) { h_new.txt.RemoveAll(item => item == null); }
                

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
                o_home = JsonConvert.DeserializeObject<Models.Home>(L_Subset);
                //Models.Home o_home = o_home;

                int n = 0;
                foreach (var item in n_news.L_t_t_f)
                {

                    if (item.file == null)
                    {
                        *//*if (n < o_home.masadigh_EN_main.Count)
                        {*//*
                        item.file_address = o_home.news.L_t_t_f[n].file_address;
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

                        *//*var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Images/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;*//*

                        string only_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media");
                        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media") + $@"\{newFileName}";


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
                        if (o_home.news.L_t_t_f[n].file_address != null)
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.news.L_t_t_f[n].file_address}");
                        
                        item.file = null;
                        item.file_address = Path.Combine($@"/" + "Media", newFileName);
                    }

                    n++;
                }

                o_home.news = n_news;
                o_home.H_new = h_new;

                client = new RestClient("https://localhost:44312/api/Home_API/edite");
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
        }*/








        ////////////////
    }
}
