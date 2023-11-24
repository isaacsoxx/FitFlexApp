using AutoMapper;
using FitFlexApp.BLL.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FitFlexApp.API.Controllers
{
    [ApiController]
    [Route("/api/users")]
    public class UserController : ControllerBase
    {
        private ILogger _logger;
        private IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IUserService userService, IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

            /* EF data peristance w/ repository pattern */
            _userService = userService ?? throw new ArgumentNullException();
        }

        [HttpGet]
        public async Task<ActionResult> GeUsers()
        {
            try
            {
                var serviceResponse = await _userService.GetUsersListAsync();
                return serviceResponse.Error ? StatusCode(serviceResponse.StatusCode, serviceResponse.Message) : Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while fetching user list", ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{userId}", Name = "GetUserByID")]
        public async Task<ActionResult> GetUserById(int userId)
        {
            try
            {
                var serviceResponse = await _userService.GetUserByIdIncludePlanAsync(userId);

                return serviceResponse.Error ? StatusCode(serviceResponse.StatusCode, serviceResponse.Message) : Ok(serviceResponse.Data);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while fetching the user id {userId}", ex);
                return StatusCode(500, ex.Message);
            }
        }
    }
}
