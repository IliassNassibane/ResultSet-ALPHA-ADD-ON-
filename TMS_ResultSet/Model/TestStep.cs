using System;
using System.Collections.Generic;
using System.Text;

namespace TMS_ResultSet.Model
{
    internal class TestStep
    {
        internal string _stepDescription;
        internal string _testedBrowser;

        internal TestStep(string description)
        {
            _stepDescription = description;
        }

        internal TestStep(string description, string browser) : this(description)
        {
            _testedBrowser = browser;
        }
    }
}
