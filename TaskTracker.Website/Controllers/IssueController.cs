using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using TaskTracker.Common.DataAccess;

namespace TaskTracker.Website.Controllers
{
    public class IssueController : Controller
    {
        //
        // GET: /Issue/
        public ActionResult Index(string id)
        {
            //using (TaskTracker.Common.DataAccess.TTDataContext context = new TaskTracker.Common.DataAccess.TTDataContext())
            //{
            //    //if (context.Database.Exists())
            //    //{
            //    //    context.Database.Delete();
            //    //}


            //    context.Database.Initialize(true);
            //}

            using (UnitOfWork unit = new UnitOfWork((DbContext)new TTDataContext()))
            {
                var query = unit.IssueRepository.All<TaskTracker.Common.Entities.Issue>(new string[] {"Status","Release"});

                if (!string.IsNullOrEmpty(id))
                {
                    query = query.Where(i => i.Status.Name == id);
                }

                var issueList = query.OrderByDescending(i => i.IssueNumber).ToList();

                ViewData.Model = issueList;
            }

            return View();
        }

        public ActionResult Create()
        {
            using(UnitOfWork unit = new UnitOfWork((DbContext)new TTDataContext()))
            {
                SelectList statusSelectList = new SelectList(unit.IssueStatusRepository.Get().ToList(), "Id", "Name");
                ViewData["StatusList"] = statusSelectList;


                List<Common.Entities.Release> releaseList = new List<Common.Entities.Release>();
                releaseList.Add(new Common.Entities.Release() { Id = 0, Number = "Select Release" });
                releaseList.AddRange(unit.ReleaseRepository.Get().ToList());
                SelectList releaseSelectList = new SelectList(releaseList, "Id", "Number", releaseList.Single(r => r.Id == 0));

                ViewData["ReleaseList"] = releaseSelectList;
            }

            return View("Edit");
        }

        public ActionResult Edit(int id)
        {
            using(UnitOfWork unit = new UnitOfWork((DbContext)new TTDataContext()))
            {
                TaskTracker.Website.Models.IssueViewModel model = new Models.IssueViewModel();

                var issue = unit.IssueRepository.Get().SingleOrDefault(i => i.Id == id);

                model.Id = issue.Id;
                model.Title = issue.Title;
                model.IssueNumber = issue.IssueNumber;
                model.Description = issue.Description;

                model.StatusId = issue.Status.Id;
                model.ReleaseId = (issue.Release != null)? issue.Release.Id: 0;

                SelectList statusList = new SelectList(unit.IssueStatusRepository.Get().ToList(), "Id", "Name");
                ViewData["StatusList"] = statusList;

                List<Common.Entities.Release> releaseList = new List<Common.Entities.Release>();
                releaseList.Add(new Common.Entities.Release() { Id = 0, Number = "Select Release" });
                releaseList.AddRange(unit.ReleaseRepository.Get().ToList());
                SelectList releaseSelectList = new SelectList(releaseList, "Id", "Number", releaseList.Single(r => r.Id == 0));

                ViewData["ReleaseList"] = releaseSelectList;

                ViewData.Model = model;

            }
            
            return View("Edit");
        }

        public ActionResult Update(TaskTracker.Website.Models.IssueViewModel model)
        {
            using(UnitOfWork unit = new UnitOfWork((DbContext)new TTDataContext()))
            {
                TaskTracker.Common.Entities.Issue Issue = null;

                if (model.Id == 0)
                {
                    Issue = new TaskTracker.Common.Entities.Issue();

                }
                else
                {
                    Issue = unit.IssueRepository.Get().SingleOrDefault(i => i.Id == model.Id);
                }

                Issue.Title = model.Title;
                Issue.IssueNumber = model.IssueNumber;
                Issue.Description = model.Description;

                Issue.Status = unit.IssueStatusRepository.Get().SingleOrDefault(s => s.Id == model.StatusId);

                if ((model.ReleaseId == 0) && (Issue.Release != null))
                {
                    Issue.Release = null;
                }

                if (model.ReleaseId > 0)
                {
                    Issue.Release = unit.ReleaseRepository.Get().SingleOrDefault(r => r.Id == model.ReleaseId);
                }

                if (model.Id == 0)
                {
                    unit.IssueRepository.Create(Issue);
                }

                unit.Commit();
            }

            return RedirectToAction("Index");
        }
	}
}