using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using StackOverflowReplica.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace StackOverflowReplica.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        private readonly StackOverflowDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public QuestionController(UserManager<ApplicationUser> userManager, StackOverflowDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

		public async Task<IActionResult> Index()
		{
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			//return View(_db.Questions.ToList()); 
            return View(_db.Questions.Include(x => x.User).ToList());
		}

        public IActionResult Create()
        {
            return View();
        }


		[HttpPost]
		public async Task<IActionResult> Create(Question question)
		{
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			question.User = currentUser;
            _db.Questions.Add(question);
			_db.SaveChanges();
			return RedirectToAction("Index");
		}

        public IActionResult Details(int QuestionId)
        {
            var thisQuestion = _db.Questions.Include(x=>x.Responses).FirstOrDefault(x => x.Id == QuestionId);
            return View(thisQuestion);
        }
    }
}
