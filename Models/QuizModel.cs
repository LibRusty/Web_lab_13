using System.ComponentModel.DataAnnotations;

namespace Backend3.Models
{
    public class QuizModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле обязательно для заполнения.")]
        [Range(-100, 100, ErrorMessage = "Ответ должен быть числом от -100 до 100.")]
        public int? UserAnswer { get; set; }

        public int CorrectAnswer { get; set; }
        public string Expression { get; set; }
    }
}