using CleanCodeLabb2.Model;

namespace CleanCodeLabb2.Notifications
{
    public class EmailNotification : INotificationObserver
    {
        public void AddUser(User user)
        {
            Console.WriteLine($"Email Notification: New user added - {user.FirstName}");

        }
    }
}
