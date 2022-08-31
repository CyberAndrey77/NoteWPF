using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface ICategoryService
    {
        DeserializedData<CategoryCollection> GetAllCategories(string accessToken);
    }
}
