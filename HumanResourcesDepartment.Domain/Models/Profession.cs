﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HumanResourcesDepartment.Domain.Models
{
    public class Profession : DomainObject
    {
        public string Name { get; private set; }

        public int ProfessionCode { get; private set; }

        public int AverageSalery { get; private set; }

        public string Description { get; private set; }


        public Profession(int professionCode, int averageSalery, string description)
        {
            ProfessionCode = professionCode;
            AverageSalery = averageSalery;
            Description = description;
        }
    }
}
