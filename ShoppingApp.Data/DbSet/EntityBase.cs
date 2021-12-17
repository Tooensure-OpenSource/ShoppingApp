using System.ComponentModel.DataAnnotations;
using ShoppingApp.Data.DbSet;

namespace shoppingApp.Data.DbSet
{
    ///<summary>
    /// 
    ///</summary>
    public class EntityBase
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();
        private DateTime DateCreated { get; set; } = DateTime.Now;
        public Status Status { get; set; } = 0;
    
    }

  
}
