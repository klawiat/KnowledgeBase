using System.ComponentModel.DataAnnotations;

namespace Knowledge_Base.Models.ViewModels
{
    public class NoteViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Обязательное поле!")]
        public string Title { get; set; } = string.Empty;
        [StringLength(100000, ErrorMessage = $"Максимальная длинна контента не должна превышать 1000000 символов")]
        public string Content { get; set; } = string.Empty;
    }
}
