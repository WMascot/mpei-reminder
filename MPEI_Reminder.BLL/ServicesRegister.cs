using Microsoft.Extensions.DependencyInjection;
using MPEI_Reminder.BLL.Services;

namespace MPEI_Reminder.BLL
{
    public static class ServicesRegister
    {
        public static IServiceCollection AddServices(this IServiceCollection services) =>
            services.AddScoped<CoursesService>()
                    .AddScoped<SemestrDatesService>()
                    .AddScoped<StudentsService>()
                    .AddScoped<ProfessorsService>()
            ;
    }
}
