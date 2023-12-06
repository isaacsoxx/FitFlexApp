using FitFlexApp.BLL.Services.Interface;
using FitFlexApp.DTOs.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitFlexApp.API.Controllers
{
    [Route("api/[controller]"), ApiController]
    public class AuthenticationController : ControllerBase
    {
        private ILogger _logger;
        private IAuthenticationService _authenticationService;
        private readonly IConfiguration _configuration;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService, IConfiguration configuration)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _authenticationService = authenticationService ?? throw new ArgumentException(nameof(authenticationService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        public async Task<ActionResult> Authenticate(AuthenticationRequestDto authenticationRequest)
        {
            try
            {
                var serviceResponse = await _authenticationService.ValidateCredentials(authenticationRequest.EmailAddress, authenticationRequest.Password);

                if (serviceResponse.Data != null)
                {
                    var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
                    var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                    var claimsForToken = new List<Claim>();
                    claimsForToken.Add(new Claim("sub", serviceResponse.Data.UserId.ToString()));
                    claimsForToken.Add(new Claim("email_address", serviceResponse.Data.Email));

                    var jwtSecurityToken = new JwtSecurityToken(
                        _configuration["Authentication:Issuer"],
                        _configuration["Authentication:Audience"],
                        claimsForToken,
                        DateTime.UtcNow,
                        DateTime.UtcNow.AddHours(1),
                        signingCredentials
                    );

                    var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                    return Ok(tokenToReturn);
                }

                return StatusCode(serviceResponse.StatusCode, serviceResponse.Message);
            } catch (Exception ex)
            {
                _logger.LogCritical($"Exception while authenticating {authenticationRequest.EmailAddress}", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
