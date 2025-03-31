using MusicBookingApp.Models;

namespace MusicBookingApp.Services
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
