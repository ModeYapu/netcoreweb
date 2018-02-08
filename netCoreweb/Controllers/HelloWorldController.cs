using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace netCoreweb.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is my default action...";
        }
        public string Welcome(string name,int ID=1)
        {
            return HtmlEncoder.Default.Encode($"Hellow {name} ,ID {ID}");
        }
    }
}