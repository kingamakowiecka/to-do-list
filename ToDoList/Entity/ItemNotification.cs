using System;
using System.ComponentModel.DataAnnotations;

namespace ToDoList.Entity
{
    public class ItemNotification
    {
        [Key]
        public long Id { get; set; }
        public DateTime? NotifiactionDate { get; set; }
        public Boolean Notified { get; set; }

        public long ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
