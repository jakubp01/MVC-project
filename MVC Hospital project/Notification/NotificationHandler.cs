using MVC_Hospital_project.Entities;
using MVC_Hospital_project.Subject;
using System.Xml.Linq;

namespace MVC_Hospital_project.Notification
{
    public class NotificationHandler : IVisitEditedObserver, INotificationHandler
    {
        public NotificationHandler(IVisitEdited visitEdited)
        {
            visitEdited.AddObserver(this);
        }
        public void Notify(Visit visit)
        {
            XDocument xDocument = XDocument.Load("wwwroot/XMLFile.xml");
            XElement element = xDocument.Element("Visit");
            element.Add(new XElement("VisitId", visit.Id));
            xDocument.Save("wwwroot/XMLFile.xml");
            
        }
    }
}
