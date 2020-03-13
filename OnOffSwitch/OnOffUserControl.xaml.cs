using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OnOffSwitch
{
    /// <summary>
    /// Interaction logic for OnOffUserControl.xaml
    /// </summary>
    public partial class OnOffUserControl : UserControl
    {
        public Boolean IsOn
        {
            get { return (Boolean)GetValue(IsOnProperty); }
            set { SetValue(IsOnProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsOnProperty =
            DependencyProperty.Register("IsOn", typeof(Boolean), typeof(OnOffUserControl), new UIPropertyMetadata(false));


        public OnOffUserControl()
        {
            InitializeComponent();
            text();
        }

        private void text()
        {
            if (IsOn == true)
            {
                OffButton.Background = Brushes.Red;
                OffButton.Content = "OFF";
            }
            else
            {
                OnButton.Background = Brushes.Green;
                OnButton.Content = "ON";
            }
        }


        private void lessThan48()
        {
            OffButton.Content = "";
            OnButton.Content = "";
        }

        private void On_Click(object sender, RoutedEventArgs e)
        {
            IsOn = true;
            OffButton.Background = Brushes.Red;
            OnButton.Background = Brushes.Gray;
            if(ActualHeight < 48 && ActualWidth < 48)
            {
                lessThan48();
            }
            else
            {
                OffButton.Content = "OFF";
                OnButton.Content = "";
            }
            
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            IsOn = false;
            OnButton.Background = Brushes.Green;
            OffButton.Background = Brushes.Gray;
            if(ActualWidth < 48 && ActualHeight < 48)
            {
                lessThan48();
            }
            else
            {
                OnButton.Content = "ON";
                OffButton.Content = "";
            }
            
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth < 48 && ActualHeight < 48)
            {
                lessThan48();
            }
            else
                text();
        }
    }
}
