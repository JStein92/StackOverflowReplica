using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackOverflowReplica.Models;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StackOverflowReplica.Controllers
{
    public class ResponseController : Controller
    {
		private readonly StackOverflowDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

        public ResponseController(UserManager<ApplicationUser> userManager, StackOverflowDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

        public IActionResult Create(int QuestionId)
        {
            var thisQuestion = _db.Questions.FirstOrDefault(question => question.Id == QuestionId);
            ViewBag.thisQuestion = thisQuestion;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Response response)
        {
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			response.User = currentUser;
            _db.Responses.Add(response);
            _db.SaveChanges();
            return RedirectToAction("Details", "Question", new { QuestionId = response.QuestionId });
        }

        public IActionResult VoteResponse(int ResponseId, int QuestionId, int vote)
        {
            var thisResponse = _db.Responses.FirstOrDefault(response => response.Id == ResponseId);
            thisResponse.VoteCount += vote;
            _db.Entry(thisResponse).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Details", "Question", new { QuestionId = QuestionId });
        }

    }
}
