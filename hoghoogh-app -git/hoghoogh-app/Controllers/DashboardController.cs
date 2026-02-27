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
    public class DashboardController : Controller
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


        public IActionResult remove_cookie()
        {
            Response.Cookies.Delete("token");
            return Redirect("#");


        }
        public IActionResult Index()
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
                //ViewBag.home = L_Home;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
                return Redirect("~/User/index");
        }




       /* [HttpPost]*/
        // GET: HomeController/Details/5
        public ActionResult Details(string type)
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




                    /////
                    Models.L_T_T_F l = new Models.L_T_T_F();
                    if (type == "M2")
                    {
                        ViewBag.data = L_Home.M2;
                    }
                    if (type == "M3")
                    {
                        ViewBag.data = L_Home.M3;
                    }
                    if (type == "M4")
                    {
                        ViewBag.data = L_Home.M4;
                    }
                    if (type == "M5")
                    {
                        ViewBag.data = L_Home.M5;
                    }
                    if (type == "left_img")
                    {
                        ViewBag.data = L_Home.left_img;
                    }
                    if (type == "slider")
                    {
                        ViewBag.data = L_Home.slider;
                    }
                    if (type == "video")
                    {
                        ViewBag.data = L_Home.video;
                    }
                    if (type == "left_1")
                    {
                        ViewBag.data = L_Home.left_1;
                    }
                    if (type == "left_2")
                    {
                        ViewBag.data = L_Home.left_2;
                    }
                    if (type == "left_3")
                    {
                        ViewBag.data = L_Home.left_3;
                    }
                    if (type == "news")
                    {
                        ViewBag.data = L_Home.news;
                    }

                if (L_Home.H_new.txt == null || L_Home.H_new == null)
                    {
                        List<string> s = new List<string>();
                        Models.new_news_mini ss = new Models.new_news_mini();
                        L_Home.H_new = ss;
                        L_Home.H_new.txt = s;
                    }

                ///
                ViewBag.type = type;
                return View(L_Home);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }


           [HttpGet]
        // GET: HomeController/Create
        public IActionResult Create(string type)
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



            /////
            if (type == "M2")
            {  
                ViewBag.type = "M2";
            }
            if (type == "M3")
            {
                ViewBag.type = "M3";
            }
            if (type == "M4")
            {
                ViewBag.type = "M4";
            }
            if (type == "M5")
            {
                ViewBag.type = "M5";
            }
            if (type == "left_img")
            {
                ViewBag.type = "left_img";
            }
            if (type == "slider")
            {
                ViewBag.type = "slider";
            }

            if (type == "video")
            {
                ViewBag.type = "video";
            }

            if (type == "left_1")
            {
                ViewBag.type = "left_1";
            }

            if (type == "left_2")
            {
                ViewBag.type = "left_2";
            }

            if (type == "left_3")
            {
                ViewBag.type = "left_3";
            }

            if (type == "news")
            {
                ViewBag.type = "news";
            }
            //////
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
                //ViewBag.home = L_Home;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public ActionResult Create(Models.L_T_T_F h_d , string type ,string state)
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
                h_d.L_t_t_f.RemoveAll(item => item.title == null && item.file == null && item.txt == null);


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

                        /*var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Media/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;*/

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



                /////
                Models.L_T_T_F l = new Models.L_T_T_F();
                if (type == "M2")
                {
                    if (state == "1")
                    {
                        try
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.M2.L_t_t_f);
                            L_Home.M2.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        catch
                        {
                            L_Home.M2 = h_d;
                        }
                    }
                    else
                    {
                        L_Home.M2 = h_d;
                    }    
                }
                if (type == "M3")
                {
                    if (state == "1")
                    {
                        try
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.M3.L_t_t_f);
                            L_Home.M3.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        catch
                        {
                            L_Home.M3 = h_d;
                        }
                    }
                    else
                    {
                        L_Home.M3 = h_d;
                    }
                }
                if (type == "M4")
                {
                    if (state == "1")
                    {
                        try
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.M4.L_t_t_f);
                            L_Home.M4.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        catch
                        {
                            L_Home.M4 = h_d;
                        }
                    }
                    else
                    {
                        L_Home.M4 = h_d;
                    }
                }
                if (type == "M5")
                {
                    if (state == "1")
                    {
                        try
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.M5.L_t_t_f);
                            L_Home.M5.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        catch
                        {
                            L_Home.M5 = h_d;
                        }
                    }
                    else
                    {
                        L_Home.M5 = h_d;
                    }
                }

                
                    if (type == "left_img")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.left_img.L_t_t_f);
                                L_Home.left_img.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.left_img = h_d;
                            }
                        }
                        else
                        {
                            L_Home.left_img = h_d;
                        }
                    }

                    if (type == "slider")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.slider.L_t_t_f);
                                L_Home.slider.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.slider = h_d;
                            }
                        }
                        else
                        {
                            L_Home.slider = h_d;
                        }
                    }

                    if (type == "video")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.video.L_t_t_f);
                                L_Home.video.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.video = h_d;
                            }
                        }
                        else
                        {
                            L_Home.video = h_d;
                        }
                    }

                    if (type == "left_1")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.left_1.L_t_t_f);
                                L_Home.left_1.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.left_1 = h_d;
                            }
                        }
                        else
                        {
                            L_Home.left_1 = h_d;
                        }
                    }

                    if (type == "left_2")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.left_2.L_t_t_f);
                                L_Home.left_2.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.left_2 = h_d;
                            }
                        }
                        else
                        {
                            L_Home.left_2 = h_d;
                        }
                    }

                
                    if (type == "left_3")
                    {
                        if (state == "1")
                        {
                            try
                            {
                                //h_d.L_t_t_f.AddRange(L_Home.left_3.L_t_t_f);
                                L_Home.left_3.L_t_t_f.AddRange(h_d.L_t_t_f);
                            }
                            catch
                            {
                                L_Home.left_3 = h_d;
                            }
                        }
                        else
                        {
                            L_Home.left_3 = h_d;
                        }
                    }

                if (type == "news")
                {
                    if (state == "1")
                    {
                        try
                        {
                            //h_d.L_t_t_f.AddRange(L_Home.left_3.L_t_t_f);
                            L_Home.news.L_t_t_f.AddRange(h_d.L_t_t_f);
                        }
                        catch
                        {
                            L_Home.news = h_d;
                        }
                    }
                    else
                    {
                        L_Home.news = h_d;
                    }
                }
                //////





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

        [HttpGet]
        // GET: HomeController/Edit/5
        public ActionResult Edit(string type)
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





                /////
                Models.L_T_T_F l = new Models.L_T_T_F();
                if (type == "M2")
                {
                    l = L_Home.M2;
                    ViewBag.type = "M2";
                }
                if (type == "M3")
                {
                    l = L_Home.M3;
                    ViewBag.type = "M3";
                }
                if (type == "M4")
                {
                    l = L_Home.M4;
                    ViewBag.type = "M4";
                }
                if (type == "M5")
                {
                    l = L_Home.M5;
                    ViewBag.type = "M5";
                }
                if (type == "left_img")
                {
                    l = L_Home.left_img;
                    ViewBag.type = "left_img";
                }
                if (type == "slider")
                {
                    l = L_Home.slider;
                    ViewBag.type = "slider";
                }
                if (type == "video")
                {
                    l = L_Home.video;
                    ViewBag.type = "video";
                }

                if (type == "left_1")
                {
                    l = L_Home.left_1;
                    ViewBag.type = "left_1";
                }

                if (type == "left_2")
                {
                    l = L_Home.left_2;
                    ViewBag.type = "left_2";
                }

                if (type == "left_3")
                {
                    l = L_Home.left_3;
                    ViewBag.type = "left_3";
                }

                if (type == "news")
                {
                    l = L_Home.news;
                    ViewBag.type = "news";
                }

                //ViewBag.home = L_Home;

                //////
                return View(l);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisableRequestSizeLimit]
        public ActionResult Edit(Models.L_T_T_F n_d, string type)
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
                if (n_d.L_t_t_f != null) { n_d.L_t_t_f.RemoveAll(item => item.title == null && item.file == null && item.txt == null); }
                else
                {
                    List<Models.T_T_F> lt = new List<Models.T_T_F>();
                    n_d.L_t_t_f = lt;
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
                L_Home = JsonConvert.DeserializeObject<Models.Home>(L_Subset);
                Models.Home o_home = L_Home;
                int n = 0;
                foreach (var item in n_d.L_t_t_f)
                {

                    if (item.file == null)
                    {
                        /*if (n < o_home.masadigh_EN_main.Count)
                        {*/
                        if (type == "M2")
                        {
                            item.file_address = o_home.M2.L_t_t_f[n].file_address;
                        }
                        if (type == "M3")
                        {
                            item.file_address = o_home.M3.L_t_t_f[n].file_address;
                        }
                        if (type == "M4")
                        {
                            item.file_address = o_home.M4.L_t_t_f[n].file_address;
                        }
                        if (type == "M5")
                        {
                            item.file_address = o_home.M5.L_t_t_f[n].file_address;
                        }
                        if (type == "left_img")
                        {
                            item.file_address = o_home.left_img.L_t_t_f[n].file_address;
                        }
                        if (type == "slider")
                        {
                            item.file_address = o_home.slider.L_t_t_f[n].file_address;
                        }
                        if (type == "video")
                        {
                            item.file_address = o_home.video.L_t_t_f[n].file_address;
                        }

                        if (type == "left_1")
                        {
                            item.file_address = o_home.left_1.L_t_t_f[n].file_address;
                        }

                        if (type == "left_2")
                        {
                            item.file_address = o_home.left_2.L_t_t_f[n].file_address;
                        }

                        if (type == "left_3")
                        {
                            item.file_address = o_home.left_3.L_t_t_f[n].file_address;
                        }

                        if (type == "news")
                        {
                            item.file_address = o_home.news.L_t_t_f[n].file_address;
                        }

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

                        /*var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images")).Root + $@"\{newFileName}";
                        string filepath_DB = "/Images/" + newFileName;
                        string filepath_new = "";
                        filepath_new = filepath_DB;*/

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

                        /*if (type == "M2" && o_home.M2.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.M2.L_t_t_f[n].file_address}");
                        }
                        if (type == "M3" && o_home.M3.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.M3.L_t_t_f[n].file_address}");
                        }
                        if (type == "M4" && o_home.M4.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.M4.L_t_t_f[n].file_address}");
                        }
                        if (type == "M5" && o_home.M5.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.M5.L_t_t_f[n].file_address}");
                        }
                        if (type == "left_img" && o_home.left_img.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.left_img.L_t_t_f[n].file_address}");
                        }
                        if (type == "slider" && o_home.slider.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.slider.L_t_t_f[n].file_address}");
                        }
                        if (type == "video" && o_home.video.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.video.L_t_t_f[n].file_address}");
                        }

                        if (type == "left_1" && o_home.left_1.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.left_1.L_t_t_f[n].file_address}");
                        }

                        if (type == "left_2" && o_home.left_2.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.left_2.L_t_t_f[n].file_address}");
                        }

                        if (type == "left_3" && o_home.left_3.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.left_3.L_t_t_f[n].file_address}");
                        }

                        if (type == "news" && o_home.news.L_t_t_f[n].file_address != null)
                        {
                            System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot") + $@"/{o_home.news.L_t_t_f[n].file_address}");
                        }*/

                        item.file = null;
                        item.file_address = Path.Combine($@"/" + "Media", newFileName);
                    }

                    n++;
                }
                /////
                Models.L_T_T_F l = new Models.L_T_T_F();
                if (type == "M2")
                {
                    o_home.M2 = n_d;
                }
                if (type == "M3")
                {
                    o_home.M3 = n_d;
                }
                if (type == "M4")
                {
                    o_home.M4 = n_d;
                }
                if (type == "M5")
                {
                    o_home.M5 = n_d;
                }
                if (type == "left_img")
                {
                    o_home.left_img = n_d;
                }
                if (type == "slider")
                {
                    o_home.slider = n_d;
                }
                if (type == "video")
                {
                    o_home.video = n_d;
                }

                if (type == "left_1")
                {
                    o_home.left_1 = n_d;
                }

                if (type == "left_2")
                {
                    o_home.left_2 = n_d;
                }

                if (type == "left_3")
                {
                    o_home.left_3 = n_d;
                }

                if (type == "news")
                {
                    o_home.news = n_d;
                }
                //////
                /*o_home.M2 = n_d;*/

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
            return Redirect("~/User/index");
        }




    }
}
