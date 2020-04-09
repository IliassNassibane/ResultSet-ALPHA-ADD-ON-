using System;
using System.Collections.Generic;
using System.Text;

namespace TMS_ResultSet.Model
{
    internal class FailedTestStep : TestStep
    {
        internal FailedTestStep(string description, string browser) : base(description, browser)
        {
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            var result = sb.AppendFormat(
                "Foutbericht: {1}{0}Browser: {2}{0}{0}",
                Environment.NewLine, _stepDescription, _testedBrowser
                );

            return result.ToString();
        }
    }
}
