using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristNavigationApp
{
   public class ChatMessage
    {
        public string Message { get; set; }
        public bool IsUserMessage { get; set; }
        public string BackgroundColor => IsUserMessage ? "#DCF8C6" : "#FFFFFF";
        public LayoutOptions HorizontalOptions => IsUserMessage ? LayoutOptions.Start : LayoutOptions.End;
        public LayoutOptions PointerAlignment => IsUserMessage ? LayoutOptions.End : LayoutOptions.Start;
    }
}
