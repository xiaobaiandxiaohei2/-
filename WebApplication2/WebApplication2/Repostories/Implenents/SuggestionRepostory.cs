using Microsoft.EntityFrameworkCore;
using WebApplication2.Model.Entity;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.ViewModel;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApplication2.Repostories.Implenents
{
    public class SuggestionRepostory : ISuggestionRepostory
    {
        private readonly NursingDbContext dbContext;

        public SuggestionRepostory(NursingDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<SuggestionInfo>> GetSuggestions(SuggestionSearch searchParam)
        {
            IQueryable<SuggestionInfo> query = this.dbContext.suggestionInfos;
            if (searchParam.StartTime != null)
            {
                query = query.Where(a => a.Time >= searchParam.StartTime);
            }
            if (searchParam.EndTime != null)
            {
                query = query.Where(a => a.Time <= searchParam.EndTime);
            }
            return await query.ToListAsync();
        }
    }
}
