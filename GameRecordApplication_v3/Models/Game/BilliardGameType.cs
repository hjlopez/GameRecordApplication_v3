using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.Models
{
    public class BilliardGameType
    {
        [Key]
        public int BilliardGameTypeId { get; set; }
        public string BilliardGameTypeName { get; set; }
        public bool IsActive { get; set; }

        public ICollection<BilliardMatch> BilliardMatches { get; set; }

    }
}