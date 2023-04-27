using FormProject.Business.Abstract;
using FormProject.Entity.Concrate;
using FormProject.Entity.Concrate.Identity;
using FormProject.MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormProject.MVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class FormController : Controller
    {
        private IFormService _formService;
        
        private readonly UserManager<User> _userManager;

        public FormController(IFormService formService, UserManager<User> userManager)
        {
            _formService = formService;
            _userManager = userManager;
            
        }

        public async Task<IActionResult> Index()
        {
            var userName = User.Identity.Name;
            var user = await _userManager.FindByNameAsync(userName);
            var results = await _formService.GetAllFormFullDataAsync();
            FormViewModel formViewModel = new FormViewModel();
            foreach (var form in results)
            {
                formViewModel.Forms.Add(new FormViewModel
                {
                    FormId = form.Id,
                    UserName = form.User.UserName,
                    Description = form.Description,
                    FieldLastName = form.Fields.LastName,
                    FieldFirstName = form.Fields.FirstName,
                    Age = form.Fields.Age,
                    FormName = form.Name,
                    CreatedAt = form.CreatedAt,
                });
            }
            formViewModel.UserId= user.Id;
            return View(formViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Create(FormViewModel formViewModel)
        {
            if (ModelState.IsValid)
            {
                var form = new Form()
                {
                    Name = formViewModel.FormName,
                    Description = formViewModel.Description,
                    UserId = formViewModel.UserId,
                    CreatedAt = DateTime.Now,

                };
                var fields = new Fields()
                {
                    FormId=form.Id,
                    FirstName = formViewModel.FieldFirstName,
                    LastName = formViewModel.FieldLastName,
                    Age = formViewModel.Age,
                    
                    
                };
                _formService.CreateFormAndField(form, fields);
                RedirectToAction("Index");
            }
            return RedirectToAction("Index", formViewModel);
        }
    }
}
