  using System.Collections.Generic;
using NUnit.Framework;

namespace TemplateEngine.Tests
{
    public class TemplateEngineTestSuite
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("Ranjith")]
        [TestCase("Anju")]
        public void ShouldWorkWithOneVariable(string value)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {name}");
            templateEngine.SetVariable("name", value);
            string result = templateEngine.Evaluate();
            Assert.That(result, Is.EqualTo("Hello " + value));
        }

        [TestCase("Anju", "M")]
        public void ShouldWorkWithTwoVariables(string firstName, string secondName)
        {
            TemplateEngine templateEngine = new TemplateEngine();
            templateEngine.SetTemplate("Hello {firstName} {secondName}");
            templateEngine.SetVariable("firstName", firstName);
            templateEngine.SetVariable("secondName", secondName);
            string result = templateEngine.Evaluate();
            Assert.That(result, Is.EqualTo("Hello " + firstName + " " + secondName));
        }
    }
}
