using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatientAngularCore.Model
{
    public class PatientQuery
    {
        public int ID { get; set; }
        public string Query { get; set; }
        public Disease disease { get; set; }
    }
}
