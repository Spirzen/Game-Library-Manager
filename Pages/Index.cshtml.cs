using GameLibraryManager.Data;
using GameLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GameLibraryManager.Pages
{
    /// <summary>
    /// Модель страницы для отображения списка игр.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Список игр для отображения на странице.
        /// </summary>
        public List<GameViewModel> Games { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для отображения списка игр.
        /// </summary>
        public void OnGet()
        {
            Games = _context.Games
                .Select(g => new GameViewModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Genre = g.Genre,
                    Year = g.Year,
                    Developer = g.Developer,
                    Platform = g.Platform
                })
                .ToList();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для удаления игры.
        /// </summary>
        /// <param name="id">Идентификатор игры для удаления.</param>
        /// <returns>Результат перенаправления на страницу списка игр.</returns>
        public IActionResult OnPostDelete(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
            return RedirectToPage();
        }
    }
}