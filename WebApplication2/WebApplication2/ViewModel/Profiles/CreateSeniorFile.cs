using AutoMapper;
using WebApplication2.Model.Entity;

namespace WebApplication2.ViewModel.Profiles
{
    public class CreateSeniorFile : Profile
    {
        public CreateSeniorFile()
        {
            CreateMap<SeniorCreate, SeniorInfo>();
        }
    }

}
