using System.Text;
using System.Threading.Tasks;
using ApiProject.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProject.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        //bu bizim metotlar icinde attributlere erisime olanak sagliyor GET POST DELETE PUT ATTIRIBUTLERI 
        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();//istemci olusturma kapiyi caldim kapi calma
            var responseMessage =await client.GetAsync("https://localhost:7263/api/Categories");//Gelen yanit mesajin yaniti burada get async yaptik delete put gibi islemlerini de baska yerde yapacagiz
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);

                //deserileze     bu api ve ui tarafinda uiden api istek ister eger olumlu donus yaparsa JSON veri seti doner! bu isleme de deserialize denir.
                //yani json verisini nesneye cevirme islemi yapiliyor
                return View(values);//values degerini view'e gonderiyorum
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            var cliennt = _httpClientFactory.CreateClient();//normal veriyi disaridan alinan veriyi jsona donusturur
            var jsonData=JsonConvert.SerializeObject(createCategoryDto); //DTO nesnesini JSON formatına çeviriyoruz
            StringContent content = new StringContent(jsonData,Encoding.UTF8, "application/json");//json verisini string content'e ceviriyoruz application json turun ismi json tutrunde onderdim
            var responseMessage = await cliennt.PostAsync("https://localhost:7263/api/Categories", content);//post async ile api'ye gonderiyoruz
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7263/api/Categories?id="+id);//id'ye gore silme islemi yapiliyor
            return RedirectToAction("CategoryList");
        }
        
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
            var cliennt = _httpClientFactory.CreateClient();//normal veriyi disaridan alinan veriyi jsona donusturur
            var responseMessage =await cliennt.GetAsync("https://localhost:7263/api/Categories/GetCategory?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<GetCategoryByIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(updateCategoryDto); //DTO nesnesini JSON formatına çeviriyoruz
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7263/api/Categories", content);//put async ile api'ye gonderiyoruz   
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["CategoryUpdated"] = true;
                return RedirectToAction("CategoryList");
            }
            return View();
        }
    }
}
