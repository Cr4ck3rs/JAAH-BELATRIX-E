using System;
using Log.Application;
using Log.Application.Factory;
using Log.Dto;
using Log.Interface;
using Moq;
using NUnit.Framework;

namespace Log.UnitTest
{
    public class JobLoggerTest
    {
        [Test]
        public void ObjectInitializerShouldSetProperties()
        {
            // Test Data
            var loggerOptionsDto = new LoggerOptionsDto(true, true, true);
            
            var destination = DestinationFactory.Make(DestinationFactoryOption.Console);

            // Prepare test
            var jobLogger = new JobLogger
            {
                LoggerOptionsDto = loggerOptionsDto,
                Destination = destination
            };

            // Assert
            Assert.AreEqual(loggerOptionsDto, jobLogger.LoggerOptionsDto);
            Assert.AreEqual(destination, jobLogger.Destination);
        }

        [Test]
        public void LogMessageShouldCallDestinationLogMessageMethod()
        {
            // Test Data
            var mockDestination = new Mock<IDestination>();
            var loggerOptionsDto = new LoggerOptionsDto(true, true, true);
            var jobLogger = new JobLogger
            {
                LoggerOptionsDto = loggerOptionsDto,
                Destination = mockDestination.Object
            };
            var message = new LogDto
            {
                MessageType = MessageType.Error,
                Message = "Test"
            };
            
            // Act
            jobLogger.LogMessage(message);

            // Assert
            mockDestination.Verify(x => x.LogMessage(It.IsAny<LogDto>()));
        }

        [Test]
        public void ProgramShouldValidateIncompatibleOptions()
        {
            // Test Data
            var mockDestination = new Mock<IDestination>();
            var loggerOptionsDto = new LoggerOptionsDto(false, true, true);
            var jobLogger = new JobLogger
            {
                LoggerOptionsDto = loggerOptionsDto,
                Destination = mockDestination.Object
            };
            var message = new LogDto
            {
                MessageType = MessageType.Error,
                Message = "Test"
            };

            var loggerOptionsDto2 = new LoggerOptionsDto(false, false, true);
            var jobLogger2 = new JobLogger
            {
                LoggerOptionsDto = loggerOptionsDto2,
                Destination = mockDestination.Object
            };
            var message2 = new LogDto
            {
                MessageType = MessageType.Warning,
                Message = "Test"
            };

            var loggerOptionsDto3 = new LoggerOptionsDto(false, true, false);
            var jobLogger3 = new JobLogger
            {
                LoggerOptionsDto = loggerOptionsDto3,
                Destination = mockDestination.Object
            };
            var message3 = new LogDto
            {
                MessageType = MessageType.Message,
                Message = "Test"
            };
            
            // Assert
            Assert.Throws<Exception>(() => jobLogger.LogMessage(message));
            Assert.Throws<Exception>(() => jobLogger2.LogMessage(message2));
            Assert.Throws<Exception>(() => jobLogger3.LogMessage(message3));
        }

    }
}