using System;
using Log.Dto;
using NUnit.Framework;

namespace Log.UnitTest
{
    public class LogDtoTest
    {
        [Test]
        public void ObjectInitializerShouldSetProperties()
        {
            // Test Data
            const string message = "Test";
            const MessageType messageType = MessageType.Warning;

            // Prepare test
            var logDto = new LogDto
            {
                Message = message,
                MessageType = messageType
            };

            // Assert
            Assert.AreEqual(message, logDto.Message);
            Assert.AreEqual(messageType, logDto.MessageType);
        }

        [Test]
        public void EmptyStringThrowsInvalidArgumentException()
        {
            // Test Data
            const string message = "    ";
            const MessageType messageType = MessageType.Warning;
            
            // Assert   
            Assert.Throws<ArgumentNullException>(() => new LogDto
            {
                Message = message,
                MessageType = messageType
            });
        }
        
    }
}
