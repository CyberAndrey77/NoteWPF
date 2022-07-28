using NoteWpf.Models;
using NoteWpf.Services.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NoteWpf.Services
{
    public class FileService : IFileService
    {
        public async Task CreateFileAsync(string path, User user)
        {
            if (user.Email == string.Empty)
            {
                throw new ArithmeticException("Эл. почта не может быть пустой");
            }
            if (user.Password == string.Empty)
            {
                throw new ArithmeticException("Пароль не может быть пустой");
            }
            if (path == string.Empty)
            {
                throw new ArithmeticException("Путь не может быть пустой");
            }

            if (!File.Exists(path))
            {
                if (!Directory.Exists(Path.GetDirectoryName(path)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(path));
                }
            }

            using (var fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync(fs, user);
            }
        }

        public async Task<User> ReadFileAsync(string path)
        {
            if (path == string.Empty)
            {
                throw new ArithmeticException("Путь не может быть пустой");
            }
            var user = new User();

            if (!File.Exists(path))
            {
                return user;
            }

            using (var fs = new FileStream(path, FileMode.Open))
            {
                user = await JsonSerializer.DeserializeAsync<User>(fs);
            }

            if (user == null)
            {
                return new User();
            }

            return user;
        }
    }
}
