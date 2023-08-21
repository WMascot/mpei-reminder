using MessageSender.DAL.Context;
using MessageSender.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MessageSender.DAL
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<DbInitializer> _logger;

        public DbInitializer(ApplicationDbContext db, ILogger<DbInitializer> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task InitializeAsync()
        {
            _logger.LogInformation("Инициализация базы данных.");
            await _db.Database.EnsureCreatedAsync();

            _logger.LogInformation("Миграция базы данных.");
            await _db.Database.MigrateAsync();

            if (await _db.Courses.AnyAsync()) return;

            await InitializeCoursesAsync();
        }

        private async Task InitializeCoursesAsync()
        {
            _logger.LogInformation("Инициализация таблицы курсов.");

            var rand = new Random();
            var courses = new List<Course>
            {
                new Course
                {
                    Id = rand.Next(),
                    Number = 3
                },
                new Course
                {
                    Id = rand.Next(),
                    Number = 4
                },
                new Course
                {
                    Id = rand.Next(),
                    Number = 5
                },
                new Course
                {
                    Id = rand.Next(),
                    Number = 6
                }
            };

            await _db.Courses.AddRangeAsync(courses);
            await _db.SaveChangesAsync();
        }
    }
}
