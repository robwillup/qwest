using System.Collections.Generic;

namespace Quest.Models
{
    public class App
    {
        public string Name { get; set; }
        public string LocalPath { get; set; }
        public string Remote { get; set; }
        public List<Feature> Features { get; set; }
    }
}
