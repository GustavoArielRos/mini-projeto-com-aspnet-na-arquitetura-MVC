using Microsoft.AspNetCore.Mvc;
using miniprojeto_mvc.Models;
using System.Diagnostics;

namespace miniprojeto_mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ConexaoBancoDbContext _context;

        public HomeController(ILogger<HomeController> logger, ConexaoBancoDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Alunos()
        {
            var todosAlunos = _context.Alunos.ToList();

            

            return View(todosAlunos);
        }

        public IActionResult EditAluno(int? id)
        {   
            if(id != null)
            {
                var alunoNoDb = _context.Alunos.SingleOrDefault(x => x.Id == id);

                return View(alunoNoDb);
            }

            return View();
        }

        public IActionResult DeleteAluno(int id)
        {
            var alunoNoDb = _context.Alunos.SingleOrDefault(x => x.Id == id);

            _context.Alunos.Remove(alunoNoDb);

            _context.SaveChanges();

            return RedirectToAction("Alunos");
        }

        public IActionResult CreateEditAlunoForm(Aluno model)
        {
            if(model.Id == 0)
            {
                _context.Alunos.Add(model);
            } else
            {
                _context.Alunos.Update(model);
            }

            _context.SaveChanges();

            return RedirectToAction("Alunos");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
