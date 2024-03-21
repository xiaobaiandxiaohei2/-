namespace WebApplication2.Model.Entity
{
    //老人表
    public class SeniorInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentityCard {  get; set; }//身份证
        public string Sex { get; set; }//性别
        public string? AvatarPath {  get; set; }//头像
        public string Province {  get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address {  get; set; }
        public string UnderlyingDisease {  get; set; }//基础病
        public string State {  get; set; }//0-未入住，1-已入住
        //public List<HospitalizationRecordInfo> HospitalizationRecordInfos { set; get; } = new List<HospitalizationRecordInfo>();
        //public List<ApplicationInfo> ApplicationInfos { set; get; } = new List<ApplicationInfo>();
        public List<HealthCheckDataInfo> HealthCheckDataInfos { set; get; } = new List<HealthCheckDataInfo>();
    }
}
