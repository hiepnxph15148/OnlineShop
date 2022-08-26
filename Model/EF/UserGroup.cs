using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UseGroup")]
    public class UserGroup
    {
        [Key]
        [StringLength(20)]
        public long ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }
    }
}
