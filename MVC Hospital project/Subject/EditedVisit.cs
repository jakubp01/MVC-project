using MVC_Hospital_project.Entities;

namespace MVC_Hospital_project.Subject
{
    public class EditedVisit : IVisitEdited
    {
        List<IVisitEditedObserver> observerList;

        public EditedVisit()
        {
            observerList= new List<IVisitEditedObserver>();
        }
        public void AddObserver(IVisitEditedObserver observer)
        {
            observerList.Add(observer);
        }

        public void NotifyObserver(Visit visit)
        {
            foreach(var item in observerList)
            {
                item.Notify(visit);
            }
        }

        public void RemoveObserver(IVisitEditedObserver observer)
        {
            observerList.Remove(observer);
        }
    }
}
