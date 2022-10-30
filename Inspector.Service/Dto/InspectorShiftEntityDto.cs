using Inspector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspector.Service.Dto
{
    public class InspectorShiftEntityDto
    {
        public Guid Id { get; set; }
        public Guid ShiftEntityId { get; set; }
        public Guid InspectorEntityId { get; set; }
        public DateTime StartWeek { get; set; }
        public DateTime EndWeek { get; set; }

    }
    public class InspectorShiftEntityResponse
    {
        public Guid Id { get; set; }
        public Guid ShiftEntityId { get; set; }
        public Guid InspectorEntityId { get; set; }
        public DateTime StartWeek { get; set; }
        public DateTime EndWeek { get; set; }
        public virtual ShiftEntityDto ShiftEntity { get; set; }
        public virtual InspectorEntityDto InspectorEntity { get; set; }

    }
}
