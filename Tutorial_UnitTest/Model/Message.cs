using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial_UnitTest.Model
{
    public class Message
    {
        public event EventHandler<MessageEventArgs>? SendMessageEvent;

        public void OnSendMessageHandler(object? sender, MessageEventArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void SendMessageToUser(string message)
        {
            SendMessageEvent += OnSendMessageHandler;
            SendMessageEvent.Invoke(this, new MessageEventArgs { Message = message });
        }

        public async Task SendMessageToUserAsync(string message)
        {
            await Task.Run(() =>
            {
                SendMessageEvent += OnSendMessageHandler;
                SendMessageEvent.Invoke(this, new MessageEventArgs { Message = message });
            });
        }
    }

    public class MessageEventArgs : EventArgs
    {
        public string Message { get; set; } = string.Empty;
    }
}
