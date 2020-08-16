using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySqlConnector;

namespace pogged.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly MySqlConnection MySQL;

        public IndexModel(ILogger<IndexModel> logger, MySqlConnection mySQL)
        {
            _logger = logger;
            MySQL = mySQL;
        }

        public void OnGet()
        {

        }
    }
}
