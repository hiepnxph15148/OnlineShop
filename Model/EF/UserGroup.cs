using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF
{
    [Table("UserGroup")]
    internal class UserGroup
    {
        public string ID { set; get; }
        public string UserName { set; get; } 
    }
}
