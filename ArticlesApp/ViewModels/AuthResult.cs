using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticlesApp.ViewModels
{
    public class AuthResult
    {
        public bool IsAuthentificated { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
