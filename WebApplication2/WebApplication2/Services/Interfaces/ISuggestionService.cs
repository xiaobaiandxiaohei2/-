using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Interfaces
{
    public interface ISuggestionService
    {
        public Task<List<SuggestionInfo>> GetSuggestions(SuggestionSearch searchParam);
    }
}
