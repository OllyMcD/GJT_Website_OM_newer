using GJT_Website_OM.Models;
using Microsoft.EntityFrameworkCore;



namespace GJT_Website_OM.Services
{
    public class QuizService
    {
        private readonly TlS2303831GjtContext _context;

        public QuizService(TlS2303831GjtContext context)
        {
            _context = context;
        }
        public async Task<List<Quiz>> GetQuizzes(int difficulty, string subject)
        {
            return await _context.Quizzes.Where(q => q.Difficuilty == difficulty && q.Subject == subject).ToListAsync();
        }

        public async Task<List<Question>> GetQuestions(int QuizId)
        {
            return await _context.Questions.Where(q => q.QuizId == QuizId).ToListAsync();
        }
        public async Task AwardCertificate(int userId, string topic, int difficulty, string badgeLevel)
        {
            var certificate = new Usercertificate
            {
                UserId = userId,
                Topic = topic,
                Difficulty = difficulty,
                BadgeLevel = badgeLevel
            };

            _context.Usercertificates.Add(certificate);
            await _context.SaveChangesAsync();
        }

        public async Task AwardAllstarBadge(int userId)
        {
            var allstarBadge = new Usercertificate
            {
                UserId = userId,
                Topic = "Allstar Completion",
                Difficulty = 5, // Assuming "Elite" difficulty corresponds to 5
                BadgeLevel = "Allstar", // Assuming Allstar badge is level 5
                DateEarned = DateTime.Now
            };

            _context.Usercertificates.Add(allstarBadge);
            await _context.SaveChangesAsync();
        }


        public async Task<List<Usercertificate>> GetCertificates(int userId)
        {
            return await _context.Usercertificates
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }



    }
}

//on your page
//let user select subject and difficulty
//search for quizzes using getQuizzes

//let user pick quiz
//use that quizId to search for questions using getQuestions