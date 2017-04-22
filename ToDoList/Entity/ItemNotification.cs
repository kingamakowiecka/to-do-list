using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoList.Entity
{
    public class ItemNotification
    {
        [Key, ForeignKey("Item")]
        public long ItemId { get; set; }
        [Required]
        public virtual Item Item { get; set; }

        [Required]
        [Range(typeof(DateTime), "1/1/1970", "1/1/2100", ErrorMessage = "Invalid time range.")]
        public DateTime NotifiactionDate { get; set; }
        public Boolean Notified { get; set; }
    }
}
