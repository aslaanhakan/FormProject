using FormProject.Entity.Abstract;
using FormProject.Entity.Concrate.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FormProject.Entity.Concrate
{
    public class Form: IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } //CreatedBy
        public User User { get; set; }
        public virtual Fields Fields { get; set; }
        
    }
}
