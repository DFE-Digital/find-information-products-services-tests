using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace find_information_products_services_tests.HomePageTestCases.utilities
{
    public class FipsSheetRow
    {
        public string Product_Locator { get; set; }
        public string Filter_Tag { get; set; }
        public string Message { get; set; }
        public string Heading { get; set; }
        public string Filter_Text_Locator { get; set; }
        public string Checkbox_Locator { get; set; }
    }
}
