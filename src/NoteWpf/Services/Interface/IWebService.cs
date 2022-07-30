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
        ResponceData SendPostResponceAsync(string json, ControllerTypes controller);
        ResponceData SendGetResponceAsync(string json, ControllerTypes controller);
        ResponceData SendGetResponceAsync(ControllerTypes controller, string accessToken);
        ResponceData SendGetResponceAsync(string json, ControllerTypes controller, string accessToken);
        ResponceData SendDeleteResponceAsync(string json, ControllerTypes controller, string accessToken);
        ResponceData SendPostResponceAsync(string json, ControllerTypes controller, string accessToken);
        ResponceData SendPutResponceAsync(string json, ControllerTypes controller, string accessToken);
    }
}
