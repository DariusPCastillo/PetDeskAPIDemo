using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Darius_PetDesk.Data.Interfaces;
using Xunit.Abstractions;
using Darius_PetDesk.Data;
using JavaScriptEngineSwitcher.Core.Helpers;

namespace PetDeskTests
{
    public class AppointmentContextTestBase
    {
       
        protected ITestOutputHelper _output;
        protected IConfiguration _config = TestHelper.GetConfig();
      
        protected ILogger<AppointmentContext> _logger => _output.GetLogger<AppointmentContext>();
        protected CancellationToken cToken = new CancellationToken();
        public AppointmentContextTestBase(ITestOutputHelper output)
        {
            _output = output;
          
        }
    }
}
