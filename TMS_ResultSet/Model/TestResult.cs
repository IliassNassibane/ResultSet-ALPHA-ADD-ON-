using System;
using System.Collections.Generic;
using System.Text;

namespace TMS_ResultSet.Model
{
    public class TestResult
    {
        private string _testName;
        private string _testPath;
        private Omgevingen _omgeving;
        private string _startTest;
        private string _endTest;
        private List<PassedTestStep> _passedTestSteps;
        private List<FailedTestStep> _failedTestSteps;

        internal TestResult(string testName, string testPath, string startTest, 
            string endTest, List<PassedTestStep> passedteststeps, List<FailedTestStep> failedteststeps,
            Omgevingen omgeving)
        {
            _testName = testName;
            _testPath = testPath;
            _startTest = startTest;
            _endTest = endTest;
            _omgeving = omgeving;
            _passedTestSteps = passedteststeps;
            _failedTestSteps = failedteststeps;
        }

        internal int GetFailedCount()
        {
            return _failedTestSteps.Count;
        }

        internal int GetPassedCount()
        {
            return _passedTestSteps.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string lineDevide = new string('-', 50);

            var result = sb.AppendFormat(
                "{0}{1}{1}Test: {2}{1}Locatie van test: {3}{1}Start van test: {4}{1}Eind van test: {5}{1}Teststappen totaal uitgevoerd: {6}{1}Omgeving: {7}{1}Gebruikte URL: {8}{1}{1}", 
                lineDevide, Environment.NewLine, _testName, _testPath, _startTest, _endTest, (GetFailedCount() + GetPassedCount()), _omgeving.GetOmgeving(), _omgeving._usedURL);

            foreach (FailedTestStep step in _failedTestSteps)
            {
                result = sb.AppendFormat("{0}", step.ToString());
            }

            result = sb.AppendFormat("{1}{1}{0}", lineDevide, Environment.NewLine);

            return result.ToString();
        }
    }
}
