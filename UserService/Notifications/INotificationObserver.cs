using CleanCodeLabb2.Model;

namespace CleanCodeLabb2.Notifications
{
    public interface INotificationObserver
    {
        void AddUser(User user);
    }
}
