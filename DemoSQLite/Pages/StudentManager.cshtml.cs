using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repo;
using Repo.Models;

namespace LoginUnitOfWork.Pages
{
    public class StudentManagerModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;

        // BindProperty for the new student
        [BindProperty]
        public Student NewStudent { get; set; }

        // Constructor to inject the UnitOfWork
        public StudentManagerModel(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // Property to hold the list of students
        public IEnumerable<Student> Students { get; private set; }

        // Handler for GET requests
        public void OnGet()
        {
            // Retrieve the list of students
            Students = _unitOfWork.StudentRepository.Get();
        }

        // Handler for POST requests
        public IActionResult OnPost()
        {
            // Insert the new student into the database
            _unitOfWork.StudentRepository.Insert(NewStudent);
            _unitOfWork.Save();

            return RedirectToPage("/StudentManager");

        }

    }
}
