using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerPortal.Domain.Entities
{
    public class AppointmentEntity : BaseEntity
    {
        public Guid CustomerID { get; set; }
        public Guid InspectorID { get; set; }
        public Guid ShiftID { get; set; }
        public DateTime InspectionStart { get; set; }
        public DateTime InspectionEnd { get; set; }
        public string Location { get; set; }

    }
}
