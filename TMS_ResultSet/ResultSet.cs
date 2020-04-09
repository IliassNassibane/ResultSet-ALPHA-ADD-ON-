using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using TMS_ResultSet.Model;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using Newtonsoft.Json.Linq;

namespace TMS_ResultSet
{
    public class ResultSet : IEnumerable
    {
        public List<TestResult> _resultSet = new List<TestResult>();

        public ResultSet(List<BsonDocument> dataSet)
        {
            foreach(BsonDocument bson in dataSet)
            {
                _resultSet.Add(GetTestResult(bson.ToString()));
            }
        }

        private static TestResult GetTestResult(string input)
        {
            JObject parsed = JObject.Parse(input);
            var id = (JObject)(parsed.Property("_id").Value);
            var Test = id.Property("Test");
            var Testpad = id.Property("Testpad");
            var Omgeving = SetOmgeving(parsed);
            var StartVanTest = parsed.Property("StartVanTest");
            var EindVanTest = parsed.Property("EindVanTest");
            var passedSteps = GetPassedStepsFromMessage(parsed);
            var failedSteps = GetFailedStepsFromMessage(parsed);
            
            return new TestResult(Test.Value.ToString(), Testpad.Value.ToString(), StartVanTest.Value.ToString(), 
                EindVanTest.Value.ToString(), passedSteps, failedSteps, Omgeving);
        }

        private static List<FailedTestStep> GetFailedStepsFromMessage(JObject input)
        {
            List<TestStep> berichten = GetBerichtenSet(input);

            MatchCollection matches;

            List<FailedTestStep> failedTestStepList = new List<FailedTestStep>();

            foreach (TestStep item in berichten)
            {
                matches = Regex.Matches(item._stepDescription, @"(\'((([0-9]+)[-/]?)*)\s((([0-9]{2})\:*){3})\s((PM|AM)?)\'\s\-\s\'Fail\'\s\:\s)(.[^-\n]*)");

                foreach (Match failStep in matches)
                {
                    failedTestStepList.Add(new FailedTestStep(failStep.ToString(), GetTestedBrowserFromMessage(item._stepDescription)));
                }
            }

            return failedTestStepList;
        }

        private static List<PassedTestStep> GetPassedStepsFromMessage(JObject input)
        {
            List<TestStep> berichten = GetBerichtenSet(input);

            MatchCollection matches;

            List<PassedTestStep> passedTestStepList = new List<PassedTestStep>();

            foreach (TestStep item in berichten)
            {
                matches = Regex.Matches(item._stepDescription, @"(\'((([0-9]+)[-/]?)*)\s((([0-9]{2})\:*){3})\s((PM|AM)?)\'\s\-\s\'Pass\'\s\:\s([0-9]*)\.)");

                foreach (Match passStep in matches)
                {
                    passedTestStepList.Add(new PassedTestStep(passStep.ToString(), GetTestedBrowserFromMessage(item._stepDescription)));
                }
            }

            return passedTestStepList;
        }

        private static List<TestStep> GetBerichtenSet(JObject input)
        {
            var Resultaten = input.Property("Resultaten").Children();

            List<TestStep> berichten = new List<TestStep>();

            foreach (JToken token in Resultaten)
            {
                TestStep teststep = new TestStep(token.ToString());
                
                berichten.Add(teststep);
            }
            return berichten;
        }

        private static string GetTestedBrowserFromMessage(string source)
        {
            if(Regex.IsMatch(source, @"(InternetExplorer|FireFox|Chrome)"))
            {
                switch(Regex.Match(source, @"(InternetExplorer|FireFox|Chrome)").Value)
                {
                    case "InternetExplorer":
                        return "Internet Explorer";
                    case "FireFox":
                        return "FireFox";
                    case "Chrome":
                        return "Google Chrome";
                    default:
                        return "Browser not defined...";
                }
            }
            return "Browser not defined...";
        }

        private static Omgevingen SetOmgeving(JObject input)
        {
            var EersteResultaat = input.Property("Resultaten").Children().First().ToString();

            Omgevingen omgeving = new Omgevingen(EersteResultaat);

            return omgeving;
        }

        public IEnumerator GetEnumerator()
        {
            foreach(TestResult item in _resultSet)
            {
                yield return item;
            }
        }
    }
}
