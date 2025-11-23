using Portfolio_Tracker_API.DTO;

namespace Portfolio_Tracker_API.Services
{
        public interface IAuthService
        {
            Task<UserResponseDto> RegisterAsync(UserRegisterDto dto);
            Task<UserResponseDto> LoginAsync(UserLoginDto dto);
            string GenerateToken(Models.User user);
        }
}
