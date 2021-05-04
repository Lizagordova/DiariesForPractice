using DiariesForPractice.Domain.Models;

namespace DiariesForPractice.Domain.Services.Authorization
{
    public interface IAuthorizationService
    {
        int Authorize(User user);
        int Register(User user);
    }
}