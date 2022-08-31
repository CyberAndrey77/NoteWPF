using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IWebService _webService;
        private readonly IJsonSerializerService _jsonSerializerService;
        public CategoryService(IWebService webService, IJsonSerializerService jsonSerializerService)
        {
            _jsonSerializerService = jsonSerializerService;
            _webService = webService;
        }

        public DeserializedData<CategoryCollection> GetAllCategories(string accessToken)
        {
            ResponceData responceData = _webService.SendGetResponceAsync(ControllerTypes.GetAllCategory, accessToken);
            var categoriesData = new DeserializedData<CategoryCollection>()
            {
                StatusCode = responceData.StatusCode
            };
            if (string.IsNullOrEmpty(responceData.JsonAnswer))
            {
                categoriesData.Value = new CategoryCollection();
                return categoriesData;
            }
            CategoryCollection categories = _jsonSerializerService.Deserialize<CategoryCollection>(responceData.JsonAnswer);
            categoriesData.Value = categories ?? throw new ArgumentException("Данные не десериализовались");
            return categoriesData;
        }
    }
}
