using Emedicine.Services;
using Microsoft.AspNetCore.Mvc;

namespace Emedicine.Controllers
{
    [ApiController]
    [Route("api/[contrller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService _tokenService;
        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost("generate")]
        public async Task<IActionResult> GenerateToken([FromBody] GenerateTokenRequest request)
        {
            var token = await _tokenService.GenerateTokenAsync(request.PhoneNumber, request.Email);
            return Ok(new { Token = token });
        }

        [HttpPost("verify")]
        public async Task<IActionResult> VerifyToken([FromBody] VerifyTokenRequest request)
        {
            var isValid = await _tokenService.VerifyTokenAsync(request.Token, request.PhoneNumber, request.Email);
            return Ok(new { IsValid = isValid });
        }
    }
}
