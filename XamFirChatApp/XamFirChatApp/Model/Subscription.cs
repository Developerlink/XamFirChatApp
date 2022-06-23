using System;
using System.Collections.Generic;
using System.Text;

namespace XamFirChatApp.Model
{
    public class Subscription
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public DateTime SupscriptionDate { get; set; }
        public bool IsActive { get; set; } = false;

        public Subscription()
        {

        }
    }
}
