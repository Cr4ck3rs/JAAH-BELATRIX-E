using System;
using Log.Dto;
using NUnit.Framework;

namespace Log.UnitTest
{
    public class LoggerOptionsDtoTest
    {
        [Test]
        public void ConstructorShouldSetProperties()
        {
            // Test Data
            const bool logErrors = false;
            const bool logWarnings = true;
            const bool logMessages = false;

            // Prepare test
            var loggerOptionsDto = new LoggerOptionsDto(logErrors, logWarnings, logMessages);

            // Assert
            Assert.AreEqual(logErrors, loggerOptionsDto.LogErrors);
            Assert.AreEqual(logWarnings, loggerOptionsDto.LogWarnings);
            Assert.AreEqual(logMessages, loggerOptionsDto.LogMessages);
        }

        [Test]
        public void ConstructorShouldNotAcceptAllOptionsAsFalse()
        {
            Assert.Throws<Exception>(() => new LoggerOptionsDto(false, false, false));
        }
    }
}