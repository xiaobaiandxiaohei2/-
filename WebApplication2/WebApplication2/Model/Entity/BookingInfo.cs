using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication2.Model.Entity
{
    //预约表
    public class BookingInfo
    {
        public int Id { get; set; }

        [ForeignKey("GuardianInfo")]
        public int WeChatUserId {  get; set; }//监护人id

        [ForeignKey("RoomInfo")]
        public int RoomId {  get; set; }//房间id
        public DateTime Staytime {  get; set; } //入住时间
        public DateTime BookingTime {  get; set; }//预约时间
        public string Name {  get; set; }//联系人
        public string Phone {  get; set; }//联系电话
        public string State {  get; set; }//0-未审核，1-通过审核，2-未通过审核
        public DateTime? AuditTime {  get; set; }//审核时间

        [ForeignKey("AdminInfo")]
        public int? AdminId {  get; set; }
        public string? Remark {  get; set; }//备注
        public GuardianInfo GuardianInfo { set; get; }
        public RoomInfo RoomInfo { get; set; }
        public AdminInfo AdminInfo { get; set; }


    }
}
