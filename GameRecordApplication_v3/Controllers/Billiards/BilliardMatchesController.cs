using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GameRecordApplication_v3.Controllers.api;
using GameRecordApplication_v3.DataAccessLayer;
using GameRecordApplication_v3.Models;
using PagedList;

namespace GameRecordApplication_v3.Controllers.Billiards
{
    public class BilliardMatchesController : Controller
    {
        private DataContext db = new DataContext();
        private MatchRepositoryController repo;
        public BilliardMatchesController()
        {
            repo = new MatchRepositoryController();
        }

        // GET: BilliardMatches
        public ActionResult Index()
        {
            var billiardMatches = db.BilliardMatches.Include(b => b.BilliardGameType).Include(b => b.PlayerLose).Include(b => b.PlayerWin).Include(b => b.BilliardGameMode);
            return View(billiardMatches.ToList());
        }

        // GET: BilliardMatches/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            if (billiardMatch == null)
            {
                return HttpNotFound();
            }
            return View(billiardMatch);
        }

        // GET: BilliardMatches/Create
        public ActionResult Create()
        {
            ViewBag.BilliardGameModeId = new SelectList(db.BilliardGameModes, "BilliardGameModeId", "BilliardGameModeName");
            ViewBag.BilliardGameTypeId = new SelectList(db.BilliardGameTypes, "BilliardGameTypeId", "BilliardGameTypeName");
            ViewBag.PlayerLoseId = new SelectList(db.Players, "PlayerId", "Name");
            ViewBag.PlayerWinId = new SelectList(db.Players, "PlayerId", "Name");
            return View();
        }

        // POST: BilliardMatches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BilliardMatchId,PlayerWinId,PlayerLoseId,WinnerWins,LoserWins,Season,BilliardGameTypeId,BilliardGameModeId")] BilliardMatch billiardMatch)
        {
            if (ModelState.IsValid)
            {
                if (billiardMatch.PlayerWinId == billiardMatch.PlayerLoseId)
                {
                    ModelState.AddModelError(nameof(billiardMatch.PlayerLoseId), "Winner and Loser are the same!");
                }
                else
                {
                    db.BilliardMatches.Add(billiardMatch);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.BilliardGameModeId = new SelectList(db.BilliardGameModes, "BilliardGameModeId", "BilliardGameModeName", billiardMatch.BilliardGameModeId);
            ViewBag.BilliardGameTypeId = new SelectList(db.BilliardGameTypes, "BilliardGameTypeId", "BilliardGameTypeName", billiardMatch.BilliardGameTypeId);
            ViewBag.PlayerLoseId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerLoseId);
            ViewBag.PlayerWinId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerWinId);
            return View(billiardMatch);
        }

        // GET: BilliardMatches/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            if (billiardMatch == null)
            {
                return HttpNotFound();
            }
            ViewBag.BilliardGameModeId = new SelectList(db.BilliardGameModes, "BilliardGameModeId", "BilliardGameModeName", billiardMatch.BilliardGameModeId);
            ViewBag.BilliardGameTypeId = new SelectList(db.BilliardGameTypes, "BilliardGameTypeId", "BilliardGameTypeName", billiardMatch.BilliardGameTypeId);
            ViewBag.PlayerLoseId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerLoseId);
            ViewBag.PlayerWinId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerWinId);
            return View(billiardMatch);
        }

        // POST: BilliardMatches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BilliardMatchId,PlayerWinId,PlayerLoseId,WinnerWins,LoserWins,Season,BilliardGameTypeId,BilliardGameModeId")] BilliardMatch billiardMatch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(billiardMatch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BilliardGameModeId = new SelectList(db.BilliardGameModes, "BilliardGameModeId", "BilliardGameModeName", billiardMatch.BilliardGameModeId);
            ViewBag.BilliardGameTypeId = new SelectList(db.BilliardGameTypes, "BilliardGameTypeId", "BilliardGameTypeName", billiardMatch.BilliardGameTypeId);
            ViewBag.PlayerLoseId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerLoseId);
            ViewBag.PlayerWinId = new SelectList(db.Players, "PlayerId", "Name", billiardMatch.PlayerWinId);
            return View(billiardMatch);
        }

        // GET: BilliardMatches/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            BilliardMatch billiardMatch = db.BilliardMatches.Include(b => b.BilliardGameType).Include(b => b.PlayerLose).Include(b => b.PlayerWin).Include(b => b.BilliardGameMode)
                    .Where(s => s.BilliardMatchId == id).FirstOrDefault();
            if (billiardMatch == null)
            {
                return HttpNotFound();
            }
            return View(billiardMatch);
        }

        // POST: BilliardMatches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            BilliardMatch billiardMatch = db.BilliardMatches.Find(id);
            db.BilliardMatches.Remove(billiardMatch);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
