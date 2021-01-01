using AspNetEntityFrameworkDataEncryption.Data;
using AspNetEntityFrameworkDataEncryption.Entities;
using AspNetEntityFrameworkDataEncryption.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetEntityFrameworkDataEncryption.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _applicationDbContext;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext applicationDbContext)
        {
            _logger = logger;
            _applicationDbContext = applicationDbContext;
        }
        public List<Person> Persons { get; set; }
        public void OnGet()
        {        
            Persons = _applicationDbContext.Persons.ToList();
        }
    }
}
