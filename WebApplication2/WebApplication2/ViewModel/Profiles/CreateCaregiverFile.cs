using AutoMapper;
using WebApplication2.Model.Entity;

namespace WebApplication2.ViewModel.Profiles
{
    public class CreateCaregiverFile:Profile
    {
        public CreateCaregiverFile()
        {
            CreateMap<CaregiverCreate, CaregiverInfo>();
        }
    }
}
