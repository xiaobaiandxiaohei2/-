
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Eventing.Reader;

namespace WebApplication2.ViewModel
{
    public class HospitalizationRecordSearch
    {
        public DateTime? StartTime { get; set; } = null;//开始时间
        public DateTime? EndTime { get; set; } = null;//结束时间  
        public string? keyword {  get; set; } = string.Empty;
    }
}
