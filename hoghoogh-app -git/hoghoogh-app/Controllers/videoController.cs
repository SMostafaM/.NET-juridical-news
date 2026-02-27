using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hoghoogh_app.Controllers
{
    public class videoController : Controller
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


        //deatil
       /* public ActionResult Details()
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
                ///
                if (L_Home.H_new.txt == null || L_Home.H_new == null)
                {
                    List<string> s = new List<string>();
                    Models.new_news_mini ss = new Models.new_news_mini();
                    L_Home.H_new = ss;
                    L_Home.H_new.txt = s;
                }
                ///
                //////////////////////



                return View(L_Home);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }*/

    }
}
