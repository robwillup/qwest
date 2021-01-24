using System;

namespace Quest.Models
{
    public class QuestTask
    {
        public QuestTask()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AppName { get; set; }
        public string FeatureName { get; set; }
    }
}
