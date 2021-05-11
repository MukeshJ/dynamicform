using Dynamic_form_api.DTO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Dynamic_form_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DynamicalFormController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public static DtoParentObject _DtoParentObject;
        public DynamicalFormController(
            IWebHostEnvironment webHostEnvironment,
            DtoParentObject DtoParentObject)
        {
            _webHostEnvironment = webHostEnvironment;
            _DtoParentObject = DtoParentObject;
        }

        [HttpGet]
        public async Task<IActionResult> GetDynamicaForms()
        {

            string filePath = $"{_webHostEnvironment.WebRootPath}\\data.json";
            var jsonString = await System.IO.File.ReadAllTextAsync(filePath);
            DtoParentObject item = System.Text.Json.JsonSerializer.Deserialize<DtoParentObject>(jsonString);
            _DtoParentObject = item;
            return Ok(item);

        }

        [HttpPost]
        public async Task<IActionResult> SaveDynamicaForm(DtoProperties dtoProperties)
        {
            string filePath = $"{_webHostEnvironment.WebRootPath}\\data.json";
            var jsonString = await System.IO.File.ReadAllTextAsync(filePath);
            DtoParentObject item = System.Text.Json.JsonSerializer.Deserialize<DtoParentObject>(jsonString);
            item.Datas.ForEach(c =>
            {
                if (c.SamplingTime == dtoProperties.SamplingTime)
                {
                    c.Properties = dtoProperties.Properties;
                }
            });
            string output = System.Text.Json.JsonSerializer.Serialize(item);
            await System.IO.File.WriteAllTextAsync(filePath, output);
            return Ok(dtoProperties);
        }
    }
}
