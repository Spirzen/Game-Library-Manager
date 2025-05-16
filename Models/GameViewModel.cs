namespace GameLibraryManager.Models
{
    /// <summary>
    /// Модель представления для передачи данных между пользовательским интерфейсом и логикой приложения.
    /// </summary>
    public class GameViewModel
    {
        /// <summary>
        /// Уникальный идентификатор игры.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Жанр игры.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Год выпуска игры.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Разработчик игры.
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Платформа, на которой доступна игра.
        /// </summary>
        public string Platform { get; set; }
    }
}