using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface IApplicationRepostory
    {
        public Task<List<ApplicationInfo>> GetApplicationInfos();
    }
}
