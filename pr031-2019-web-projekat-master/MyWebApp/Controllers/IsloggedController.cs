using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyWebApp.Controllers
{
    public class IsloggedController : ApiController
    {
        [HttpGet]
        public bool IsLoggedUser()
        {
            if (Korisnici.Ulogovan == true)
                return true;
            else
                return false;

        }
    }
}
