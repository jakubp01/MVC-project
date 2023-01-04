using MVC_Hospital_project.Entities;

namespace MVC_Hospital_project.Subject
{
    public interface IVisitEdited
    {
        void AddObserver(IVisitEditedObserver observer);
        void RemoveObserver(IVisitEditedObserver observer);
        
        void NotifyObserver(Visit visit);
    }
}
