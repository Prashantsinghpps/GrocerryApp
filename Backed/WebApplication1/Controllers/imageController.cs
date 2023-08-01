using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System.Web.Http;
using System.Net.Http;

using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

using NonActionAttribute = Microsoft.AspNetCore.Mvc.NonActionAttribute;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class imageController : Controller
    {


    }
}













