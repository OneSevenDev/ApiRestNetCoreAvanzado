using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NTT.Backend.API.Controllers
{
    [Route("api/[controller]/[action]")]
    // [Authorize]
    public class ApiBase : ControllerBase
    {
    }
}
