using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskTracker.Website.Models
{
    [System.Xml.Serialization.XmlRootAttribute("channel", Namespace = "", IsNullable = false)]
    public class IssueIntegrationModel
    {
        public IssueIntegrationModel()
        {
            this.Items = new List<IssueIntegrationItem>();
        }


        [System.Xml.Serialization.XmlArrayItem("item", typeof(IssueIntegrationItem))]
        public List<IssueIntegrationItem> Items { get; set; }


    }

    public class IssueIntegrationItem
    {
        public string key { get; set; }
        public string summary { get; set; }
    }
}