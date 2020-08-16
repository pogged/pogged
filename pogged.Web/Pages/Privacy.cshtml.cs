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
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly MySqlConnection MySQL;

        public PrivacyModel(ILogger<PrivacyModel> logger, MySqlConnection mySQL)
        {
            _logger = logger;
            MySQL = mySQL;
        }

        public void OnGet()
        {
        }
    }
}
