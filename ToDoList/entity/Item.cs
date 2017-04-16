using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entity
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool Finished { get; set; }
    }
}
