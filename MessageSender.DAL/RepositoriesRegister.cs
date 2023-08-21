using MessageSender.DAL.Entities;
using MessageSender.DAL.Interfaces;
using MessageSender.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace MessageSender.DAL
{
    public static class RepositoriesRegister
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services) =>
            services.AddScoped<IRepository<Course>, CoursesRepository>()
                    .AddScoped<IRepository<SemestrDate>, SemestrDatesRepository>()
                    .AddScoped<IRepository<Student>, StudentsRepository>()
                    .AddScoped<IRepository<Professor>, ProfessorsRepository>()
            ;
    }
}
