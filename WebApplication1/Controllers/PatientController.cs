using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class PatientController : Controller
    {
       [HttpGet]
       [Route('api/dept/GetPatients')]
    }
}
