using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Assignment1_PRN232.Pages
{
    public class EditModel : PageModel
    {
        private readonly Repository.Models.FUNewsManagementContext _context;

        public EditModel(Repository.Models.FUNewsManagementContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SystemAccount SystemAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var systemaccount =  await _context.SystemAccounts.FirstOrDefaultAsync(m => m.AccountId == id);
            if (systemaccount == null)
            {
                return NotFound();
            }
            SystemAccount = systemaccount;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(SystemAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SystemAccountExists(SystemAccount.AccountId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool SystemAccountExists(short id)
        {
            return _context.SystemAccounts.Any(e => e.AccountId == id);
        }
    }
}
