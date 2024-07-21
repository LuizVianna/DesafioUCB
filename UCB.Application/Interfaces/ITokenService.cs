using UBC.Application.DTOs;

namespace UBC.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(LoginDTO loginDto);
    }
}
