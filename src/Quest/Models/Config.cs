using System;
using System.Collections.Generic;

namespace Quest.Models
{
    public class Config
    {        
        public DateTime Date { get; set; }
        public Dev Dev { get; set; }
        public List<App> Applications { get; set; }
    }
}
