﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace PatientAngularCore.Model
{
    public class Disease
    {
        [Key]
        public int ID { get; set; }
        public string DiseaseName { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }

    }
}
