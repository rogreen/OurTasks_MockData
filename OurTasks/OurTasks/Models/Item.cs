using System;

namespace OurTasks
{
    public class Item
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Location { get; set; }
        public string AssignedTo { get; set; }
        public DateTime DueDate { get; set; }
        public bool Completed { get; set; }
    }
}
