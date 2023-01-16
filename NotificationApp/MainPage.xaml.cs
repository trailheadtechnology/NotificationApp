using Xamarin.Forms;

namespace NotificationApp
{
   public partial class MainPage : ContentPage
   {
      public MainPage()
      {
         InitializeComponent();
      }

      protected override async void OnAppearing()
      {
         base.OnAppearing();
         var service = DependencyService.Get<IPostNotificationPermissionService>();
         await service.CheckAndRequestPermissions();
      }
   }
}
