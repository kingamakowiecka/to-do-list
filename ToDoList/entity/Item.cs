using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entity
{
    public class Item
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Please fill the item's name.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(typeof(DateTime), "1/1/1970", "1/1/2100", ErrorMessage = "Invalid time format.")]
        public DateTime Date { get; set; }
        public bool Finished { get; set; }
    }
}
