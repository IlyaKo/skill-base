using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
public class PingController
{
    [Route("api/ping")]
    [HttpGet]
    public string Ping() => "pong";
}
