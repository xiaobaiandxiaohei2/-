using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Interfaces;
using WebApplication2.ViewModel;

namespace WebApplication2.Services.Implements
{
    public class SuggestionService : ISuggestionService
    {
        private readonly ISuggestionRepostory suggestionRepostory;

        public SuggestionService(ISuggestionRepostory suggestionRepostory)
        {
            this.suggestionRepostory = suggestionRepostory;
        }

        public async Task<List<SuggestionInfo>> GetSuggestions(SuggestionSearch searchParam)
        {
            return await this.suggestionRepostory.GetSuggestions(searchParam);
        }
    }
}
