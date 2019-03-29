using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Shake4Quake.Models
{
    enum MessageType { Vibrate, Text2Speech, Light };

    class MulticastMessage
    {
        public MulticastMessage(MessageType type, string Data = "", string Sender = "")
        {
            this.Sender = Sender ?? DeviceInfo.Name;
            this.Data = Data;
            this.Type = Type;
        }

        public MessageType Type{ get; set; }

        public string Data { get; set; }

        public string Sender { get; set; }
    }
}
