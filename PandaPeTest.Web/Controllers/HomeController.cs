using Microsoft.AspNetCore.Mvc;
using PandaPeTest.Web.Entities;
using PandaPeTest.Web.Models;
using System.Diagnostics;
using System.Text;
using System.Text.Json;

namespace PandaPeTest.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClient;

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClient)
        {
            _logger = logger;
            _httpClient = httpClient;
        }

        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        };

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Candidates()
        {
            List<Candidates> Result = new();

            try
            {
                var client = _httpClient.CreateClient("GetApi");
                var response = await client.GetAsync("");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<List<Candidates>>(content, options);

                    return View(result);
                }
                return View();
            }
            catch(Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("EditApi");
                var response = await client.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<CandidateDetails>(content, options);

                    return View(result);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                Candidates Obj = new();

                Obj.IdCandidate = Convert.ToInt32(collection["Candidate.IdCandidate"].ToString());
                Obj.Name = collection["Candidate.Name"].ToString();
                Obj.SurName = collection["Candidate.SurName"].ToString();
                Obj.BirthDate = Convert.ToDateTime(collection["Candidate.BirthDate"].ToString());
                Obj.Email = collection["Candidate.Email"].ToString();
                Obj.InsertDate = System.DateTime.Now;
                Obj.ModifyDate = System.DateTime.Now;

                var sJson = JsonSerializer.Serialize(Obj);

                var client = _httpClient.CreateClient("UpdateCandidateApi");
                var response = await client.PutAsync(client.BaseAddress, new StringContent(sJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return RedirectToAction(nameof(Candidates));
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> DeleteExperience(int id)
        {
            try
            {
                var client = _httpClient.CreateClient("GetExperienceApi");
                var response = await client.GetAsync(id.ToString());

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var result = JsonSerializer.Deserialize<CanidateExperiences>(content, options);

                    return View(result);
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteExperience(int id, IFormCollection collection)
        {
            try
            {
                var client = _httpClient.CreateClient("DeleteExperienceByIdApi");
                HttpRequestMessage request = new HttpRequestMessage
                {
                    Content = new StringContent(id.ToString(), Encoding.UTF8, "application/json"),
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(client.BaseAddress.ToString())
                };

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return RedirectToAction(nameof(Candidates));
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateCandidate(IFormCollection collection)
        {
            try
            {
                Candidates Obj = new();

                Obj.IdCandidate = 0;
                Obj.Name = collection["Name"].ToString();
                Obj.SurName = collection["SurName"].ToString();
                Obj.BirthDate = Convert.ToDateTime(collection["BirthDate"].ToString());
                Obj.Email = collection["Email"].ToString();
                Obj.InsertDate = System.DateTime.Now;
                Obj.ModifyDate = System.DateTime.Now;

                var sJson = JsonSerializer.Serialize(Obj);

                var client = _httpClient.CreateClient("CreateApi");
                var response = await client.PostAsync(client.BaseAddress, new StringContent(sJson, Encoding.UTF8, "application/json"));

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    return RedirectToAction(nameof(Candidates));
                }
                return View();
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }
        public IActionResult CreateCandidate()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}