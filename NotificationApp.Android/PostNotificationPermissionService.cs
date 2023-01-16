using Android;
using Android.OS;
using NotificationApp.Droid;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

[assembly: Dependency(typeof(PostNotificationPermissionService))]
namespace NotificationApp.Droid
{
   // Extend Xamarin Essentials
   internal class PostNotificationsPermission : BasePlatformPermission
   {
      public override (string androidPermission, bool isRuntime)[] RequiredPermissions =>
          new List<(string androidPermission, bool isRuntime)>
          {
             (Manifest.Permission.PostNotifications, true)
          }.ToArray();
   }

   // Implementing PostNotificationPermission
   public class PostNotificationPermissionService : IPostNotificationPermissionService
   {
      public async Task<bool> CheckAndRequestPermissions()
      {
         // Tiramisu is Android v13
         if (Build.VERSION.SdkInt >= BuildVersionCodes.Tiramisu)
         {
            var status = await CheckStatusAsync<PostNotificationsPermission>();

            if (status == PermissionStatus.Granted)
            {
               return true;
            }

            status = await RequestAsync<PostNotificationsPermission>();

            return status == PermissionStatus.Granted;
         }
         return true;
      }
   }
}