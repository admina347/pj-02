using EF.DataAccessLibrary.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EF.Web.Pages.Users
{
    public class List : PageModel
    {
        private readonly ILogger<List> _logger;
        public List<User> Users { get; set; }
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

        public async Task OnGet()
        {
            Users = await _userRepository.GetAllUsers();
        }
    }
}