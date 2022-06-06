using GameRecordApplication_v3.DataAccessLayer;
using GameRecordApplication_v3.Models;
using GameRecordApplication_v3.ViewModel;
using Newtonsoft.Json;
using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GameRecordApplication_v3.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db;
        MainViewModel viewModel;
        public HomeController()
        {
            db = new DataContext();
            viewModel = new MainViewModel();
        }

        public ActionResult Index(int? page)
        {
            // lagyan caching
            var billiardMatches = db.BilliardMatches.Include(b => b.BilliardGameType).Include(b => b.PlayerLose).Include(b => b.PlayerWin).Include(b => b.BilliardGameMode)
                .OrderByDescending(b => b.BilliardGameTypeId).OrderByDescending(b => b.BilliardGameMode.BilliardGameModeId).OrderByDescending(b => b.BilliardMatchId).ToList();
            viewModel.Seasons = db.BilliardMatches.OrderByDescending(s => s.Season).Select(s => s.Season).Distinct().ToList();

            if (viewModel.Seasons == null)
            {
                viewModel.Seasons = new List<int>();
                viewModel.Seasons[0] = 1;
            }

            // pagination
            // get number of pages
            int pageSize = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(billiardMatches.Count) / 2));
            int pageNumber = (page ?? 1);
            viewModel.BilliardMatches = billiardMatches.ToPagedList(pageNumber, pageSize);

            return View(viewModel);
        }

        //public ActionResult About()
        //{
        //    ViewBag.Message = "Your application description page.";

        //    return View();
        //}

        public async Task<ActionResult> About()
        {
            ViewBag.Message = "Your application description page.";

            try
            {
                //string Baseurl = "https://jsonplaceholder.typicode.com/";
                string Baseurl = "https://localhost:44397/";

                using (var client = new HttpClient())
                {
                    //Passing service base url
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient
                    HttpResponseMessage Res = await client.GetAsync("api/MatchRepository");
                    //Checking the response is successful or not which is sent using HttpClient
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                        //Deserializing the response recieved from web api and storing into the Employee list
                    }
                    //returning the employee list to view
                    return View();
                }

            }
            catch (Exception ex)
            {

            }

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ShowNewMatchPopup()
        {
            return PartialView("_AddMatch", null);
        }

        public ActionResult AddMatch()
        {
            return View();
        }
    }
}