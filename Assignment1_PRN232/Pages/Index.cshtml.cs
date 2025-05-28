using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Repository.Models;

namespace Assignment1_PRN232.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Repository.Models.FUNewsManagementContext _context;

        public IndexModel(Repository.Models.FUNewsManagementContext context)
        {
            _context = context;
        }

        public IList<SystemAccount> SystemAccount { get;set; } = default!;

        public async Task OnGetAsync()
        {
            SystemAccount = await _context.SystemAccounts.ToListAsync();
        }
    }
}
