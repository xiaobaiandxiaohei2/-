namespace WebApplication2.Model.Entity
{
    //监护人表
    public class GuardianInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdentificationCard {  get; set; }//身份证
        public string Password {  get; set; }
        public string Phone {  get; set; }

        //public List<BookingInfo> BookingInfos { set; get; } = new List<BookingInfo>();
        //public List<HospitalizationRecordInfo> HospitalizationRecordInfos { set; get; } = new List<HospitalizationRecordInfo>();
        //public List<ApplicationInfo> ApplicationInfos { set; get; } = new List<ApplicationInfo>();
        public List<SuggestionInfo> SuggestionInfos { set; get; } = new List<SuggestionInfo>();

    }
}
