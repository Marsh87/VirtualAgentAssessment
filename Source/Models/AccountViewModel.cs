﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VirtualAgentAssessment.Models
{
    public class AccountViewModel
    {
        public AccountViewModel()
        {
            Transactions = new List<TransactionViewModel>();
        }
        [Required]
        public int code { get; set; }
        [Required]
        public int person_code { get; set; }
        [DisplayName("Account Number")]
        [Required]
        [MaxLength(50)]
        public string account_number { get; set; }
        [DisplayName("Outstanding Balance")]
        public decimal outstanding_balance { get; set; }
        public bool IsActive { get; set; }
        
        public List<TransactionViewModel> Transactions { get; set; }
    }
}