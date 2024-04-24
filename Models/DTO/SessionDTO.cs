using System.ComponentModel.DataAnnotations;
using webapi.Models;

namespace Puzzle_API.Model;

    public class SessionDTO
    {
        [Required]
        public string? SessionId { get; set; }
        [Required]
        public string? UserName { get; set; }
    }

