using System.ComponentModel.DataAnnotations;

namespace GameLibraryManager.Data
{
    /// <summary>
    /// Модель данных для представления игры в базе данных.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Уникальный идентификатор игры.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название игры.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Жанр игры.
        /// </summary>
        [MaxLength(50)]
        public string Genre { get; set; }

        /// <summary>
        /// Год выпуска игры.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Разработчик игры.
        /// </summary>
        [MaxLength(100)]
        public string Developer { get; set; }

        /// <summary>
        /// Платформа, на которой доступна игра.
        /// </summary>
        [MaxLength(50)]
        public string Platform { get; set; }
    }
}