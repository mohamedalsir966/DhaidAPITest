using Inspector.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Entities
{
    public class InspectorEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }

    }
}
