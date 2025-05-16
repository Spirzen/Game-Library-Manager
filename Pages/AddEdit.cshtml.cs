using GameLibraryManager.Data;
using GameLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameLibraryManager.Pages
{
    /// <summary>
    /// Модель страницы для добавления или редактирования игры.
    /// </summary>
    public class AddEditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Модель данных игры для формы.
        /// </summary>
        [BindProperty]
        public GameViewModel Game { get; set; }

        /// <summary>
        /// Флаг, указывающий, является ли операция редактированием.
        /// </summary>
        public bool IsEdit { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddEditModel"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public AddEditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Обрабатывает GET-запрос для загрузки данных игры.
        /// </summary>
        /// <param name="id">Идентификатор игры для редактирования (опционально).</param>
        /// <returns>Результат отображения страницы.</returns>
        public IActionResult OnGet(int? id)
        {
            if (id.HasValue)
            {
                var game = _context.Games.Find(id.Value);
                if (game == null)
                {
                    return NotFound();
                }
                Game = new GameViewModel
                {
                    Id = game.Id,
                    Name = game.Name,
                    Genre = game.Genre,
                    Year = game.Year,
                    Developer = game.Developer,
                    Platform = game.Platform
                };
                IsEdit = true;
            }
            else
            {
                Game = new GameViewModel();
                IsEdit = false;
            }
            return Page();
        }

        /// <summary>
        /// Обрабатывает POST-запрос для сохранения данных игры.
        /// </summary>
        /// <returns>Результат перенаправления на страницу списка игр.</returns>
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (Game.Id > 0) // Редактирование
            {
                var existingGame = _context.Games.Find(Game.Id);
                if (existingGame != null)
                {
                    existingGame.Name = Game.Name;
                    existingGame.Genre = Game.Genre;
                    existingGame.Year = Game.Year;
                    existingGame.Developer = Game.Developer;
                    existingGame.Platform = Game.Platform;
                }
            }
            else // Добавление
            {
                var newGame = new Data.Game
                {
                    Name = Game.Name,
                    Genre = Game.Genre,
                    Year = Game.Year,
                    Developer = Game.Developer,
                    Platform = Game.Platform
                };
                _context.Games.Add(newGame);
            }

            _context.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}