using Cameras.Response;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Cameras
{
    public sealed partial class CameraList : UserControl
    {
        public static DependencyProperty CamerasProperty =
           DependencyProperty.Register("Cameras", typeof(object), typeof(List<Camera>), null);

        public CameraList()
        {
            InitializeComponent();
        }

        public List<Camera> Cameras
        {
            get => (List<Camera>)GetValue(CamerasProperty);
            set => SetValue(CamerasProperty, value);
        }

    }
}
