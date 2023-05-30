using DION_BTVN.Services;
using DION_BTVN.Utilities;
using DION_BTVN.ViewModels.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DION_BTVN.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAccountService accountService, ILogger<AccountController> logger)
        {
            _accountService = accountService;
            _logger = logger;
        }

        [HttpPost("api/dang-ky")]
        public async Task<IActionResult> RegisterVM([FromBody] registerViewModel obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<string> listErrors = new();

                    if (await _accountService.IsEmailExist( obj.email))
                    {
                        listErrors.Add("Tên email đã tồn tại.");
                    }

                    if (listErrors.Count > 0)
                    {
                        return Ok(DionResponse.BadRequest(listErrors));
                    }

                    await _accountService.RegisterWM(obj);
                    var response = DionResponse.Success(obj);
                    return Ok(response);
                }
                else
                {
                    var erors = ModelState.Values.SelectMany(c => c.Errors.Select(c => c.ErrorMessage));
                    return Ok(DionResponse.BadRequest(erors));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to insert account.");
                return BadRequest();
            }
        }
        [HttpGet("dang-ky")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
