using GameRecordApplication_v3.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GameRecordApplication_v3.ViewModel
{
    public class MainViewModel
    {
        public IPagedList<BilliardMatch> BilliardMatches { get; set; }
        public List<int> Seasons { get; set; }
        public BilliardMatch BilliardMatch { get; set; }
    }
}