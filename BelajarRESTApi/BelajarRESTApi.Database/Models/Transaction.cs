﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BelajarRESTApi.Database.Models
{
    [Table("Transaction", Schema ="dbo")]
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Transaction Id")]
        public int TransactionId { get; set; }

        [Required]
        [Column(TypeName = "VarChar(10)")]
        [Display(Name = "Transaction Code")]
        public string TransactionCode { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
    }
}
