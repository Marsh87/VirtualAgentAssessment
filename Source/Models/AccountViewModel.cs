﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VirtualAgentAssessment.Models
{
    public class AccountViewModel
    {
        public int code { get; set; }
        public string person_code { get; set; }
        public string account_number { get; set; }
        public decimal outstanding_balance { get; set; }
    }
}