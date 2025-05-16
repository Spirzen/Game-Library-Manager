using GameLibraryManager.Data;
using GameLibraryManager.Models;
using System.Collections.Generic;
using System.Linq;

namespace GameLibraryManager.Services
{
    /// <summary>
    /// Сервис для выполнения операций CRUD с играми.
    /// </summary>
    public class GameService
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="GameService"/>.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public GameService(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Получает список всех игр из базы данных.
        /// </summary>
        /// <returns>Список игр в виде модели представления.</returns>
        public List<GameViewModel> GetAllGames()
        {
            return _context.Games
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
        /// Добавляет новую игру в базу данных.
        /// </summary>
        /// <param name="game">Модель представления новой игры.</param>
        public void AddGame(GameViewModel game)
        {
            var newGame = new Data.Game
            {
                Name = game.Name,
                Genre = game.Genre,
                Year = game.Year,
                Developer = game.Developer,
                Platform = game.Platform
            };
            _context.Games.Add(newGame);
            _context.SaveChanges();
        }

        /// <summary>
        /// Обновляет данные существующей игры в базе данных.
        /// </summary>
        /// <param name="game">Модель представления обновляемой игры.</param>
        public void UpdateGame(GameViewModel game)
        {
            var existingGame = _context.Games.Find(game.Id);
            if (existingGame != null)
            {
                existingGame.Name = game.Name;
                existingGame.Genre = game.Genre;
                existingGame.Year = game.Year;
                existingGame.Developer = game.Developer;
                existingGame.Platform = game.Platform;
                _context.SaveChanges();
            }
        }

        /// <summary>
        /// Удаляет игру из базы данных по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор игры для удаления.</param>
        public void DeleteGame(int id)
        {
            var game = _context.Games.Find(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                _context.SaveChanges();
            }
        }
    }
}