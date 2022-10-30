using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Domain.Entities
{
    public class InspectorShiftEntity:BaseEntity
    {
        public Guid ShiftEntityId { get; set; }
        public Guid InspectorEntityId { get; set; }
        public DateTime StartWeek { get; set; }
        public DateTime EndWeek { get; set; }
        public virtual ShiftEntity ShiftEntity { get; set; }
        public virtual InspectorEntity InspectorEntity { get; set; }

    }
}
