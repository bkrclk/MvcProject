using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DrawData.Models
{
    public class UserDepartmanModel
    {
        [Key]
        public int UserDepartmanId { get; set; }
        public string UserDepartmanName { get; set; }
        public virtual ICollection<UserModel> User { set; get; }
    }
}
