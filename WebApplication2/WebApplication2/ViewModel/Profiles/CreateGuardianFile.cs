using AutoMapper;
using WebApplication2.Model.Entity;

namespace WebApplication2.ViewModel.Profiles
{
    public class CreateGuardianFile:Profile
    {
        public CreateGuardianFile()
        {
            CreateMap<CreateGuardian, GuardianInfo>();
        }

       
    }
}
