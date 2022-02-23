using System;
using System.Threading.Tasks;
using WorkScheduleBlazorApp.Data.Notifications.NotificationModel;

namespace WorkScheduleBlazorApp.Data.Notifications
{
    public class NotificationManager
    {
        public  event Action<Notification> OnShow;
        public  event Action OnHide;

        public  async Task Show(Notification notification)
        {
            OnShow?.Invoke(notification);
            await Task.Delay(3000);
            try
            {
                OnHide?.Invoke();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}