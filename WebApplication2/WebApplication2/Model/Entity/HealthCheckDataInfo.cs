using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model.Entity
{
    //健康数据表
    public class HealthCheckDataInfo
    {
        public int Id {  get; set; }
        [ForeignKey("SeniorInfo")]
        public int SeniorId { get; set; }//老人id
        [ForeignKey("CaregiverInfo")]
        public int CaregiverId {  get; set; }//护工id
        public DateTime CheckTime { get; set; }//检查时间
        public int HealthDataItemId {  get; set; }//项目id
        public double CheckData {  get; set; }//数据值
        public SeniorInfo SeniorInfo { get; set; }
        public CaregiverInfo CaregiverInfo { get; set; }
        public HealthDataItemInfo HealthDataItemInfo { get; set; }

    }
}
