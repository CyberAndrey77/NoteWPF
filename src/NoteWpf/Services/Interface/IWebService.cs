using NoteWpf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteWpf.Services.Interface
{
    public interface IWebService
    {
        Task<string> SendPostResponceAsync(string json, ControllerTypes controller);
        Task<string> SendGetResponceAsync(string json, ControllerTypes controller);
        Task<string> SendGetResponceAsync(string json, ControllerTypes controller, string accessToken);
        Task<string> SendDeleteResponceAsync(string json, ControllerTypes controller, string accessToken);
        Task<string> SendPostResponceAsync(string json, ControllerTypes controller, string accessToken);
        Task<string> SendPutResponceAsync(string json, ControllerTypes controller, string accessToken);
    }
}
