namespace WebApplication2.Model.Entity
{
    //房间表
    public class RoomInfo
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; }
        public string? Remark {  get; set; }//备注
        public string State {  get; set; }//0-待维修，1-维修中，2-可入住，3-已满员
        //public List<BookingInfo> BookingInfos { set; get; } = new List<BookingInfo>();
        //public List<HospitalizationRecordInfo> HospitalizationRecordInfos { set; get; } = new List<HospitalizationRecordInfo>();

    }
}
