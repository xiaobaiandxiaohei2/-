namespace WebApplication2.Model.Entity
{
    //护士表
    public class CaregiverInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string IdentificationCard {  get; set; }//身份证
        public int WorkYears {  get; set; }//工作年限
        public int Grade {  get; set; }//护工等级
        public string? AvatarPath {  get; set; }//头像
        public string? Remark {  get; set; }//备注
        public string State {  get; set; }//0-不在职，1-在职
      //  public List<HospitalizationRecordInfo> HospitalizationRecordInfos { set; get; } = new List<HospitalizationRecordInfo>();
        //public List<HealthCheckDataInfo> HealthCheckDataInfos { set; get; } = new List<HealthCheckDataInfo>();
    }
}
