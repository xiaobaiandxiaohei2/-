using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model.Entity
{
    //意见表
    public class SuggestionInfo
    {
        public int Id { get; set; }
        [ForeignKey("GuardianInfo")]
        public int GuardianId { get; set; }//监护人id
        public string Content {  get; set; }//建议内容
        public DateTime Time { get; set; }//建议时间
        public GuardianInfo GuardianInfo { get; set; }
    }
}
