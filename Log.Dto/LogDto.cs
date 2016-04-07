using System;

namespace Log.Dto
{
    public class LogDto
    {
        private string _message;

        public string Message
        {
            get { return _message; }
            set
            {
                // Validate empty messages
                if (string.IsNullOrEmpty(value.Trim()))
                {
                    var messageName = "Message";
                    throw new ArgumentNullException(messageName);
                }
                _message = value;
            }
        }

        public MessageType MessageType { get; set; }
    }
}
