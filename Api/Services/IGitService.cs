using System.Threading.Tasks;

namespace Api.Services
{
    public interface IGitService
    {
        Task<string[]> GetGitRepos(string Username);
    }
}