using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.Models.Game
{
    public class BilliardGameMode
    {
        [Key]
        public int BilliardGameModeId { get; set; }
        [Required]
        public string BilliardGameModeName { get; set; }
        public bool IsPlayoff { get; set; }
        public string Remarks { get; set; }

        public ICollection<BilliardMatch> BilliardMatches { get; set; }
    }
}