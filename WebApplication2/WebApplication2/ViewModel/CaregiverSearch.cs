namespace WebApplication2.ViewModel
{
    public class CaregiverSearch
    {
        public string? Sex { get; set; } = string.Empty;
        public int? Grade { get; set; } = null;//护工等级
        public string? State { get; set; } = string.Empty;//0-不在职，1-在职
        public string? keyword {  get; set; } = string.Empty;
    }
}
