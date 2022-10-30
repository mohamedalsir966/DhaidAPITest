using CustomerPortal.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Service.RequestService
{
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
    public class ShiftEntityDto
    {
        public Guid Id { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public string Name { get; set; }
        public ShiftType ShiftType { get; set; }
    }
    public class InspectorEntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
