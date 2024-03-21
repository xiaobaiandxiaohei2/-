using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepostory applicationRepostory;

        public ApplicationService(IApplicationRepostory applicationRepostory)
        {
            this.applicationRepostory = applicationRepostory;
        }

        public Task<List<ApplicationInfo>> GetApplicationInfos()
        {
            return this.applicationRepostory.GetApplicationInfos();
        }
    }
}
