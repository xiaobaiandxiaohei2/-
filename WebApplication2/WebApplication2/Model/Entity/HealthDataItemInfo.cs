namespace WebApplication2.Model.Entity
{
    //健康项目表
    public class HealthDataItemInfo
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int Weight {  get; set; }
        public List<HealthCheckDataInfo> HealthCheckDataInfos { set; get; } = new List<HealthCheckDataInfo>();
    }
}
