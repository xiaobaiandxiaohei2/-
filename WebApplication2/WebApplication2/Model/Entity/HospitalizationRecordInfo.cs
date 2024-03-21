using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model.Entity
{
    //入住登记表
    public class HospitalizationRecordInfo
    {
        public int Id {  get; set; }

        [ForeignKey("SeniorInfo")]
        public int SeniorId {  get; set; }//老人id
        public DateTime EnterTime {  get; set; }//入住时间
        public DateTime? ExitTime { get; set; }//出院时间

        [ForeignKey("GuardianInfo")]
        public int GuardianId {  get; set; }//监护人id
        [ForeignKey("RoomInfo")]
        public int RoomId {  get; set; }//房间id
        [ForeignKey("CaregiverInfo")]
        public int CaregiverId {  get; set; }//护工id
        public SeniorInfo  SeniorInfo{ get; set; }
        public GuardianInfo  GuardianInfo{ get; set; }
        public RoomInfo  RoomInfo{ get; set; }
        public CaregiverInfo CaregiverInfo{ get; set; }

    }
}
