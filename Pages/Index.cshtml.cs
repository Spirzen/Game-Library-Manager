using GameLibraryManager.Data;
using GameLibraryManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace GameLibraryManager.Pages
{
    /// <summary>
    /// ������ �������� ��� ����������� ������ ���.
    /// </summary>
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// ������ ��� ��� ����������� �� ��������.
        /// </summary>
        public List<GameViewModel> Games { get; set; }

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="IndexModel"/>.
        /// </summary>
        /// <param name="context">�������� ���� ������.</param>
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// ������������ GET-������ ��� ����������� ������ ���.
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
        /// ������������ POST-������ ��� �������� ����.
        /// </summary>
        /// <param name="id">������������� ���� ��� ��������.</param>
        /// <returns>��������� ��������������� �� �������� ������ ���.</returns>
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