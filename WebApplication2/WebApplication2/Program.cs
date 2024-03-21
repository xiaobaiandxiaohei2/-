using WebApplication2.Repostories;
using WebApplication2.Repostories.Implenents;
using WebApplication2.Repostories.Interfaces;
using WebApplication2.Services.Implements;
using WebApplication2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region 第三方模块注入

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion

//注入数据访问
builder.Services.AddDbContext<NursingDbContext>();

//依赖注入
builder.Services.AddScoped<IAdminRepostory, AdminRepostory>();
builder.Services.AddScoped<ISeniorRepostory, SeniorRepostory>();
builder.Services.AddScoped<IGuardianRepostory, GuardianRepostory>();
builder.Services.AddScoped<IRoomRepostory, RoomRepostory>();
builder.Services.AddScoped<ICaregiverRepostory, CaregiverRepostory>();
builder.Services.AddScoped<IBookingRepostory, BookingRepostory>();
builder.Services.AddScoped<IHospitalizationRecordRepostory, HospitalizationRecordRepostory>();
builder.Services.AddScoped<IApplicationRepostory, ApplicationRepostory>();
builder.Services.AddScoped<ISuggestionRepostory, SuggestionRepostory>();
builder.Services.AddScoped<IHealthDataItemRepostory, HealthDataItemRepostory>();

builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ISeniorService, SeniorService>();
builder.Services.AddScoped<IGuardianService, GuardianService>();
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<ICaregiverService, CaregiverService>();
builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<IHospitalizationRecordService, HospitalizationService>();
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<ISuggestionService, SuggestionService>();
builder.Services.AddScoped<IHealthDataItemService, HealthDataItemService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
