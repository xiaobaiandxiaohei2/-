using WebApplication2.Model.Entity;
using WebApplication2.ViewModel;

namespace WebApplication2.Repostories.Interfaces
{
    public interface ISuggestionRepostory
    {
        public Task<List<SuggestionInfo>> GetSuggestions(SuggestionSearch searchParam);
    }
}
