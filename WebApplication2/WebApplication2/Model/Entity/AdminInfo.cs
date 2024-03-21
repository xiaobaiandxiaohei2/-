namespace WebApplication2.Model.Entity
{
    //管理员实体类
    public class AdminInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone {  get; set; }
        public string Password {  get; set; }
        public char State {  get; set; }  //1-在职，0-离职

        //public List<ApplicationInfo> ApplicationInfos { set; get; } = new List<ApplicationInfo>();
        //public List<BookingInfo> BookingInfos { set; get; } = new List<BookingInfo>();
    }
}
