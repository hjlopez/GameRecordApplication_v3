using GameRecordApplication_v3.Models.Game;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.Models
{
    public class BilliardMatch
    {
        [Key]
        public long BilliardMatchId { get; set; }
        public Player PlayerWin { get; set; }
        public int PlayerWinId { get; set; }
        public Player PlayerLose { get; set; }
        public int PlayerLoseId { get; set; }
        public int WinnerWins { get; set; }
        public int LoserWins { get; set; }
        public int Season { get; set; }
        public BilliardGameType BilliardGameType { get; set; }
        public int BilliardGameTypeId { get; set; }
        public BilliardGameMode BilliardGameMode{ get; set; }
        public int BilliardGameModeId { get; set; }

    }
}