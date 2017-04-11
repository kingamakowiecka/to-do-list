using System;

namespace ToDoList.entity
{
    public class Item
    {
        private long id;
        private String name;
        private String decription;
        private DateTime date;
        private Boolean finished;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Decription { get => decription; set => decription = value; }
        public DateTime Date { get => date; set => date = value; }
        public bool Finished { get => finished; set => finished = value; }
    }
}
