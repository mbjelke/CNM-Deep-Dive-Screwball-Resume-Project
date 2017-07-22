using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrewballResume.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
