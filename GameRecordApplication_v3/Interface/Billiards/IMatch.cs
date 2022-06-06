using GameRecordApplication_v3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameRecordApplication_v3.Interface.Billiards
{
    public interface IMatch
    {
        Task<IEnumerable<BilliardMatch>> GetMatchesAsync();
        Task<IEnumerable<BilliardMatch>> GetMatchesBySeasonAsync(int season);
        Task<IEnumerable<BilliardMatch>> GetMatchesBySeasonTypeAsync(int season, int typeId);
        Task<IEnumerable<BilliardMatch>> GetMatchesByTypeAsync(int typeId);
        Task<BilliardMatch> GetSingleMatchAsync(int matchId);
        Task<bool> InsertMatchAsync(BilliardMatch match);
    }
}
