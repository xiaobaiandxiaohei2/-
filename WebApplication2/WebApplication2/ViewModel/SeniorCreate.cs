namespace WebApplication2.ViewModel
{
    public class SeniorCreate
    {
        public string Name { get; set; }
        public string IdentityCard { get; set; }//身份证
        public string Sex { get; set; }//性别
        public string? AvatarPath { get; set; } = string.Empty;//头像
        public string Province { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string? UnderlyingDisease { get; set; } = string.Empty;//基础病
        public string State { get; set; }//0-未入住，1-已入住
    }
}
