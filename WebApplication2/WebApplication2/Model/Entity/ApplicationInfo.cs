using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model.Entity
{
    //申请表
    public class ApplicationInfo
    {
        public int Id { get; set; }
        [ForeignKey("GuardianInfo")]
        public int GuardianId {  get; set; }//监护人id
        [ForeignKey("SeniorInfo")]
        public int SeniorId { get; set; }//老人id
        public string Type {  get; set; }//1-外出申请，2-出院申请
        public DateTime OutTime {  get; set; }//外出时间或出院时间
        public DateTime? BackTime {  get; set; }//外出返回时间
        public string State {  get; set; }//0-未处理，1-已通过，2-未通过
        public string? AuditTime {  get; set; }//审核时间
        [ForeignKey("AdminInfo")]
        public int? AdminId {  get; set; }//审核人id
        public string? Remark {  get; set; }//备注
        public GuardianInfo GuardianInfo { get; set; }
        public SeniorInfo SeniorInfo { get; set; }
        public AdminInfo AdminInfo { get; set; }
    }
}
