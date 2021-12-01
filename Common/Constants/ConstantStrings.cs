using StarterForSeleniumAutomation.Enums;
using System;

namespace StarterForSeleniumAutomation.Constants
{
    public class ConstantStrings
    {
        public static string GetUrl()
        {
            if (TestEnvironment.QA == ConstantTestProperties.ENVIRONMENT)
                return "http://google.pl";
            else
                throw new NotImplementedException();
        }
    }
}
