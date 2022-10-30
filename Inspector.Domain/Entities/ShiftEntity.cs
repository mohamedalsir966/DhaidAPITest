using Inspector.Domain.Enum;
using Inspector.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Entities
{
    public class ShiftEntity : BaseEntity
    {
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Name { get; set; }
        public ShiftType ShiftType { get; set; }

    }
}
