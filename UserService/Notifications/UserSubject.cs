using CleanCodeLabb2.Model;

namespace CleanCodeLabb2.Notifications
{
    public class UserSubject
    {
        private readonly List<INotificationObserver> _observers = new List<INotificationObserver>();

        public void Attach(INotificationObserver observer)
        {
            // Lägg till en observatör
            _observers.Add(observer);
        }

        public void Detach(INotificationObserver observer)
        {
            // Ta bort en observatör
            _observers.Remove(observer);
        }

        public void NotifyUserAdded(User user)
        {
            // Notifiera alla observatörer om en ny produkt
            foreach (var observer in _observers)
            {
                observer.AddUser(user);
            }
        }

    }
}
