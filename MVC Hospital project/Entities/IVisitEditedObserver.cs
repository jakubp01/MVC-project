namespace MVC_Hospital_project.Entities
{
    public interface IVisitEditedObserver
    {
        void Notify(Visit visit);
    }
}
