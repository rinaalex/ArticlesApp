using System;
using System.Collections.Generic;
using System.Text;

namespace ArticlesApp.DAL.DataObjects
{
    public class AuthResultObject
    {
        public bool IsAuthentificated { get; set; }
        public string Login { get; set; }
        public string Token { get; set; }
    }
}
