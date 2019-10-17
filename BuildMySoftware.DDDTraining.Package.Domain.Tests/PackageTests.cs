using System.Collections.Generic;
using NFluent;
using NUnit.Framework;

namespace BuildMySoftware.DDDTraining.Package.Tests
{
    public class PackageTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void PackageExample()
        {
            // given
            var collectedMessages = new List<string>();

            void MessageCollector(string msg)
            {
                collectedMessages.Add(msg);
            }

            var package = new Package(MessageCollector);

            // when
            package.Operation(); // should send state 1 message
            package.Operation(); // should send state 2 message
            package.Operation(); // should send state 1 message again

            // then
            Check.That(collectedMessages).ContainsExactly("Handling state 1", "Handling state 2", "Handling state 1");
        }

        [Test]
        public void PackageUsingStatePatternExample()
        {
            // given
            var collectedMessages = new List<string>();

            void MessageCollector(string msg)
            {
                collectedMessages.Add(msg);
            }

            var package = new PackageUsingStatePattern(MessageCollector);

            // when
            package.Operation(); // should send state 1 message
            package.Operation(); // should send state 2 message
            package.Operation(); // should send state 1 message again

            // then
            Check.That(collectedMessages).ContainsExactly("Handling state 1", "Handling state 2", "Handling state 1");
        }
    }
}