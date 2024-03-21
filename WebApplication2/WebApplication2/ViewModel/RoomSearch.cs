namespace WebApplication2.ViewModel
{
    public class RoomSearch
    {
        public string? RoomNumber { get; set; }=string.Empty;
        public string? State { get; set; }=string.Empty;//0-待维修，1-维修中，2-可入住，3-已满员
    }
}
