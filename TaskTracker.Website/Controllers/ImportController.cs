using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using System.IO;
using System.Xml;

namespace TaskTracker.Website.Controllers
{
    public class ImportController : Controller
    {
        // GET: Import
        public ActionResult Index()
        {
            string path = Server.MapPath("~/content/rss.xml");

            XmlSerializer serializer = new XmlSerializer(typeof(TaskTracker.Website.Models.IssueIntegrationModel));

            XmlTextReader reader = new XmlTextReader(path);

            TaskTracker.Website.Models.IssueIntegrationModel model = (TaskTracker.Website.Models.IssueIntegrationModel)serializer.Deserialize(reader);
            reader.Close();

            //TaskTracker.Website.Models.IssueIntegrationModel model = new Models.IssueIntegrationModel();
            //model.Items.Add(new TaskTracker.Website.Models.IssueIntegrationItem(){ key = "100", summary = "simple task" });
            //model.Items.Add(new TaskTracker.Website.Models.IssueIntegrationItem() { key = "102", summary = "simple task 2" });

            //Stream stream =  new FileStream(path, FileMode.Create,
            //             FileAccess.Write, FileShare.None);

            //serializer.Serialize(stream, model);
            //stream.Close();

            return View();
        }
    }
}