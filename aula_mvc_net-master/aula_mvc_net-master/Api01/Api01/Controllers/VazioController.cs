using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api01.Controllers
{
    public class VazioController : ApiController
    {
        // GET api/vazio
        public string Get()
        {
            return "vazio";
        }

        // GET api/vazio/5
        public string Get(int id)
        {
            return "vazio " + id;
        }
    }
}
