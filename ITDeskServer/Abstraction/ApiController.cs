using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ITDeskServer.Abstraction;
[Route("api/[controller]/[action]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public abstract class ApiController : ControllerBase
{

}
