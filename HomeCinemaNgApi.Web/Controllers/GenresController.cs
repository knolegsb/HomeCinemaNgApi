using HomeCinemaNgApi.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace HomeCinemaNgApi.Web.Controllers
{
    [Authorize(Roles = "Admin")]

    public class GenresController : ApiControllerBase
    {
    }
}