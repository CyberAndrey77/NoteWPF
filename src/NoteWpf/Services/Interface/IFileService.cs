using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface IFileService
    {
        Task CreateFileAsync(string path, User user);
        Task<User> ReadFileAsync(string path);
    }
}
