using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace hoghoogh_app.Controllers
{
    public class HomeController : Controller
    {
        private IHostingEnvironment Environment;
        public HomeController(IHostingEnvironment _environment)
        {
            Environment = _environment;
        }

        // GET: HomeController
        public ActionResult Index()
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
                
                if(L_Home.M2 == null)
                {
                    L_Home.M2 = send_lttf;
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                }
                else
                {
                    L_Home.M2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
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




              
                ViewBag.home = L_Home;
               
                //////////////////////
                return View(L_Home);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }




        // GET: HomeController/Details/5
        public ActionResult about()
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

                /////

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
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                }
                else
                {
                    L_Home.M2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
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
                //////
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        public ActionResult contact()
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

                /////

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
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                }
                else
                {
                    L_Home.M2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
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
                //////
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        ///upload large file
        [RequestFormLimits(MultipartBodyLengthLimit = 209715200)]
        [RequestSizeLimit(209715200)]
        [DisableRequestSizeLimit]
        ///
        public ActionResult contact(Models.Data_U_S data,[FromServices] IHostingEnvironment ohostingEnvironment)
        {

           

            try
            {
                /* string pathwww = this.Environment.WebRootPath;
                 string conpath = this.Environment.ContentRootPath;
                 string pa = Path.Combine(this.Environment.WebRootPath, "User_Send");
                 if (!Directory.Exists(pa))
                     Directory.CreateDirectory(pa);
                 string fnm = Path.GetFileName(data.file.FileName);
                 using(FileStream stream= new FileStream(Path.Combine(pa, fnm), FileMode.Create))
                 {
                     data.file.CopyTo(stream);
                     stream.Flush();
                 }
                 data.file = null;
                 data.file_address = Path.Combine($@"/" + "User_Send", fnm);*/

                if (data.file != null)
                {
                    //Getting FileName
                    var fileName = Path.GetFileName(data.file.FileName);

                    //Assigning Unique Filename (Guid)
                    var myUniqueFileName = Convert.ToString(Guid.NewGuid());

                    //Getting file Extension
                    var fileExtension = Path.GetExtension(fileName);

                    // concatenating  FileName + FileExtension
                    var newFileName = String.Concat(myUniqueFileName, fileExtension);

                    // Combines two strings into a path.

                   /* var filepath = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Media")).Root + $@"\{newFileName}";
                    string filepath_DB = "/Media/" + newFileName;
                    string filepath_new = "";
                    filepath_new = filepath_DB;*/

                    string only_path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "User_Send");
                    var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "User_Send") + $@"\{newFileName}";


                    //linux
                    string name_f = filepath; string new_name_f = ""; foreach (var c in filepath) { if (c.ToString() == "\\") { new_name_f = new_name_f + "/"; } else { new_name_f = new_name_f + c; } }
                    filepath = new_name_f;

                    if (!Directory.Exists(only_path))
                        Directory.CreateDirectory(only_path);
                    using (FileStream fs = System.IO.File.Create(filepath))
                    {
                        data.file.CopyTo(fs);
                        fs.Flush();
                    }
                    data.file = null;
                    data.file_address = Path.Combine($@"/" + "User_Send", newFileName);
                }



                RestClient client = new RestClient("https://localhost:44312/api/Data_U_S/create");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                string json_user = JsonConvert.SerializeObject(data);
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
                    ViewBag.send = "1";

                }
                else
                {
                    ViewBag.send = "0";
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
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
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                }
                else
                {
                    L_Home.M2.L_t_t_f.AddRange(send_lttf.L_t_t_f);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
                    L_Home.M2.L_t_t_f.Add(s_ttf);
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
                //////
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

            return View();
        }


        public ActionResult singel_post(string add)
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



                var add_L = add.Split(".");
                add = add_L[0];
                /////
                Models.L_T_T_F l = new Models.L_T_T_F();
                if (add == "M2")
                {
                    ViewBag.data = L_Home.M2.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.M2.name;
                }
                if (add == "M3")
                {
                    ViewBag.data = L_Home.M3.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.M3.name;
                }
                if (add == "M4")
                {
                    ViewBag.data = L_Home.M4.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.M4.name;
                }
                if (add == "M5")
                {
                    ViewBag.data = L_Home.M5.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.M5.name;
                }
                if (add == "left_img")
                {
                    ViewBag.data = L_Home.left_img.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.left_img.name;
                }
                if (add == "slider")
                {
                    ViewBag.data = L_Home.slider.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.slider.name;
                }
                if (add == "video")
                {
                    ViewBag.data = L_Home.video.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.video.name;
                }
                if (add == "left_1")
                {
                    ViewBag.data = L_Home.left_1.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.left_1.name;
                }
                if (add == "left_2")
                {
                    ViewBag.data = L_Home.left_2.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.left_2.name;
                }
                if (add == "left_3")
                {
                    ViewBag.data = L_Home.left_3.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.left_3.name;
                }


                if (add == "news")
                {
                    ViewBag.data = L_Home.news.L_t_t_f[Int32.Parse(add_L[1])];
                    ViewBag.type = L_Home.news.name;
                }

                if (add == "M1_L_4")
                {
                    if (add_L[1] == "L_t_t_f_1")
                    {
                        ViewBag.data = L_Home.M1_L_4.L_t_t_f_1.L_t_t_f[Int32.Parse(add_L[2])];
                    }
                    if (add_L[1] == "L_t_t_f_2")
                    {
                        ViewBag.data = L_Home.M1_L_4.L_t_t_f_2.L_t_t_f[Int32.Parse(add_L[2])];
                    }
                    if (add_L[1] == "L_t_t_f_3")
                    {
                        ViewBag.data = L_Home.M1_L_4.L_t_t_f_3.L_t_t_f[Int32.Parse(add_L[2])];
                    }
                    if (add_L[1] == "L_t_t_f_4")
                    {
                        ViewBag.data = L_Home.M1_L_4.L_t_t_f_4.L_t_t_f[Int32.Parse(add_L[2])];
                    }
                    ViewBag.type = L_Home.M1_L_4.name;
                }

                if (L_Home.H_new.txt == null || L_Home.H_new == null)
                {
                    List<string> s = new List<string>();
                    Models.new_news_mini ss = new Models.new_news_mini();
                    L_Home.H_new = ss;
                    L_Home.H_new.txt = s;
                }

                ///
                ViewBag.type_Link = add_L[0];
                return View(L_Home);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
