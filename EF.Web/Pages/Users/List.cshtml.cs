using EF.DataAccessLibrary.Models;
using EF.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        public List<User> Users { get; set; }
        public int totalPages { get; set; }
        public int currentPage { get; set; }
        public int pageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(currentPage, pageSize));

        private readonly IUserRepository _userRepository;


        /* public void OnException(ExceptionContext exceptionContext)
{
if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is IndexOutOfRangeException)
{
//exceptionContext.Result = new RedirectResult("/Content/ExceptionFound.html");
//exceptionContext.ExceptionHandled = true;
ViewData["Message"] = "Ошибка: " + exceptionContext.Exception.Message;
}
} */
        public List(ILogger<List> logger, IUserRepository userRepository)
        {
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task OnGetAsync(int p = 1, int s = 10)
        {
            //Users = await _userRepository.GetAllUsersAsync();
            //
            var data = await _userRepository.GetAllUsersAsync();
            pageSize = s;
            currentPage = p;
            totalPages = (int)Math.Ceiling((decimal)data.Count() / (decimal)pageSize); //data.Count()/s;
            //(int)Math.Ceiling((decimal)totalItems / (decimal)pageSize)
            
            Users = data.Skip((p - 1) * s).Take(s).ToList();
            //
            //const int pageSize = 10;
            //if (pg < 1)
            //    pg = 1;
            //int recsCount = data.Count();
            //var pager = new Pager(recsCount, pg, pageSize);
            //int recSkip = (pg -1) * pageSize;
            //Users = data.Skip(recSkip).Take(pager.PageSize).ToList();
            //this.ViewBag.Pager = pager;
            //return View(data);
        }
    }
}