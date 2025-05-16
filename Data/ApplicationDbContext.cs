using Microsoft.EntityFrameworkCore;

namespace GameLibraryManager.Data
{
    /// <summary>
    /// Контекст базы данных для управления данными приложения.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicationDbContext"/>.
        /// </summary>
        /// <param name="options">Параметры конфигурации контекста базы данных.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Набор данных игр в базе данных.
        /// </summary>
        public DbSet<Game> Games { get; set; }
    }
}