using Microsoft.AspNetCore.Mvc;
using Bookstore.Infraestructure.Persistence;
using Bookstore.Application.Models.InputModel.Loans;

namespace Bookstore.API.Controllers
{
    [ApiController]
    [Route("api/loans")]
    public class LoanController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LoanController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult StartLoan(StartLoanInputModel model)
        {
            model.LoanDate = DateTime.Now;
            var loan = model.ToEntity();

            _context.Loans.Add(loan);
            _context.SaveChanges();

            return Created();
        }


        [HttpPut("{idBook}/{idUser}")]
        public IActionResult EndLoan(int idBook, int idUser)
        {
            var loan = _context.Loans.SingleOrDefault(l => l.IdBook == idBook && l.IdUser == idUser);
            if (loan == null)
                return NotFound();
            
            var loanMessage = loan.ReturnDate < DateTime.Now ? "Data de devolução ultrapassada" : "Devolução no prazo";

            loan.EndLoan(DateTime.Now);
            _context.Loans.Update(loan);
            _context.SaveChanges();

            return Ok(loanMessage);         
        }
    }
}
