using BusinessObjects.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab3_Client.Controllers
{
    [Authorize]
    [Route("product")]
    public class ProductController : Controller
    {
        private readonly HttpClient client;
        private string api;

        public ProductController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
            api = "https://localhost:44357/api/products/";
        }

        [HttpGet]
        public IActionResult Index() => View();

        [HttpGet("detail/{id}", Name = "detail")]
        public async Task<IActionResult> Details(int id)
        {
            HttpResponseMessage res = await client.GetAsync(api + id);

            var data = await res.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var obj = JsonSerializer.Deserialize<Product>(data, opt);
            return View(obj);
        }

        [HttpGet("create", Name = "create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet("edit/{id}", Name = "edit")]
        public async Task<IActionResult> Edit(int id)
        {
            HttpResponseMessage res = await client.GetAsync(api + id);

            var data = await res.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var obj = JsonSerializer.Deserialize<Product>(data, opt);
            await SetCategoryList();
            return View(obj);
        }

        [HttpGet("delete/{id}", Name = "delete")]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage res = await client.GetAsync(api + id);

            var data = await res.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var obj = JsonSerializer.Deserialize<Product>(data, opt);
            return View(obj);
        }

        private async Task SetCategoryList()
        {
            HttpResponseMessage res = await client.GetAsync("https://localhost:44357/api/categories");

            var data = await res.Content.ReadAsStringAsync();
            var opt = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var obj = JsonSerializer.Deserialize<IEnumerable<Category>>(data, opt);
            ViewData["cate"] = new SelectList(obj, "CategoryId", "CategoryName");
        }
    }
}
