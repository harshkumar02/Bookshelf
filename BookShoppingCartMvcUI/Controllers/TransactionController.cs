using Microsoft.AspNetCore.Mvc;
using ThebookshelfUI.Models; // assuming models are in this namespace
using System;
using System.Threading.Tasks;

public class TransactionController : Controller
{
    private readonly ApplicationDbContext _context;

    public TransactionController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> SaveTransaction(string TransactionData)
    {
        if (!string.IsNullOrEmpty(TransactionData))
        {
            // Create a new transaction object with the current date and time
            var transaction = new TransactionDetail
            {
                TransactionData = TransactionData,
                CreatedAt = DateTime.Now // Record the timestamp of data entry
            };

            // Add the transaction to the database
            _context.TransactionDetails.Add(transaction);
            await _context.SaveChangesAsync();

            // Optionally redirect to a success page or show a success message
            return RedirectToAction("OrderSuccess");
        }

        // Handle the case where data is not valid
        return View();
    }

    public IActionResult OrderSuccess()
    {
        return View();
    }
}
