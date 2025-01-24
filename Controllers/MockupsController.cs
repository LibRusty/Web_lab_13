using Microsoft.AspNetCore.Mvc;
using Backend3.Models;
using System.Collections.Generic;
using System.Linq;

namespace Backend3.Controllers
{
    public class MockupsController : Controller
    {
        // Храним вопросы и ответы в статическом списке
        private static List<QuizModel> Questions { get; set; } = new List<QuizModel>
        {
            new QuizModel { Id = 1, Expression = "1 - 6", CorrectAnswer = -5 },
            new QuizModel { Id = 2, Expression = "8 + 6", CorrectAnswer = 14 },
            new QuizModel { Id = 3, Expression = "5 - 7", CorrectAnswer = -2 },
            new QuizModel { Id = 4, Expression = "5 - 2", CorrectAnswer = 3 }
        };

        public IActionResult Quiz()
        {
            // Начинаем викторину с первого вопроса
            var model = Questions[0];
            return View(model);
        }

        [HttpPost]
        public IActionResult Quiz(int id, int? userAnswer)
        {
            // Находим текущий вопрос
            var currentQuestion = Questions.Find(q => q.Id == id);

            // Проверяем, был ли предоставлен ответ
            if (userAnswer == null)
            {
                ModelState.AddModelError("UserAnswer", "Поле обязательно для заполнения.");
            }

            // Если есть ошибки, возвращаем текущий вопрос с ошибками
            if (!ModelState.IsValid)
            {
                return View(currentQuestion);
            }

            // Сохраняем ответ пользователя
            currentQuestion.UserAnswer = userAnswer;

            // Если это не последний вопрос, переходим к следующему
            if (id < Questions.Count)
            {
                var nextQuestion = Questions.Find(q => q.Id == id + 1);
                return View(nextQuestion);
            }
            else
            {
                // Если это последний вопрос, переходим к результатам
                return RedirectToAction("QuizResult");
            }
        }

        public IActionResult QuizResult()
        {
            // Подсчитываем количество правильных ответов
            int correctAnswers = Questions.Count(q => q.UserAnswer == q.CorrectAnswer);
            ViewBag.CorrectAnswers = correctAnswers;
            ViewBag.TotalQuestions = Questions.Count;

            // Отображаем результаты
            return View(Questions);
        }
    }
}