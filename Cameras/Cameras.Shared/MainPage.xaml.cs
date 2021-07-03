using Cameras.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Cameras
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page, INotifyPropertyChanged
    {
        private List<Camera> _cameras = new List<Camera>();

        public MainPage()
        {
            DataContext = this;
            this.InitializeComponent();
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            DispatchAsync(() => GetCameras());
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        private async Task GetCameras()
        {
            var weatherClient = new RestClient(new System.Uri("https://localhost:44346"));
            var requestModel = new Models.Request.CamerasBase();
            status.Text = "Requesting data...";
            var response = await weatherClient.Request<List<Camera>>(requestModel).ConfigureAwait(false);

            Cameras = response;
            status.Text = $"{Cameras.Count} Records";

            Console.WriteLine(response.ToString());
        }


        public List<Camera> Cameras {
            get
            {
                return _cameras;
            }
            set
            {
                _cameras = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Cameras3));
                OnPropertyChanged(nameof(Cameras5));
                OnPropertyChanged(nameof(Cameras35));
                OnPropertyChanged(nameof(CamerasOverig));
            }
        }

        public List<Camera> Cameras3
        {
            get
            {
                return _cameras.Where(x => x.ID % 3 == 0).ToList();
            }
        }

        public List<Camera> Cameras5
        {
            get
            {
                return _cameras.Where(x => x.ID % 5 == 0).ToList();
            }
        }

        public List<Camera> Cameras35
        {
            get
            {
                return _cameras.Where(x => x.ID % 5 == 0 && x.ID % 5 ==0).ToList();
            }
        }

        public List<Camera> CamerasOverig
        {
            get
            {
                return _cameras.Where(x => x.ID % 5 != 0 && x.ID % 5 != 0).ToList();
            }
        }

        private async Task DispatchAsync(DispatchedHandler callback)
        {
            // As WASM is currently single-threaded, and Dispatcher.HasThreadAccess always returns false for broader compatibility  reasons
            // the following code ensures the app always directly invokes the callback on WASM.
            var hasThreadAccess =
#if __WASM__
        true;
#else
        Dispatcher.HasThreadAccess;
#endif

            if (hasThreadAccess)
            {
                callback.Invoke();
            }
            else
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, callback);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
