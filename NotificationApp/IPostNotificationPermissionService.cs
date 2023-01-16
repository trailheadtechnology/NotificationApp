using System.Threading.Tasks;

namespace NotificationApp
{
   public interface IPostNotificationPermissionService
   {
      Task<bool> CheckAndRequestPermissions();
   }
}
