using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public Boolean Value
        {
            get { return (Boolean)GetValue(ValueProperty); }
            set
            {
                SetValue(ValueProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for IsOn.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(Boolean), typeof(OnOffUserControl), new PropertyMetadata(false, new PropertyChangedCallback(OnValueChanged)));

        public OnOffUserControl()
        {
            InitializeComponent();
        }

        private static void OnValueChanged(DependencyObject d,
         DependencyPropertyChangedEventArgs e)
        {
            OnOffUserControl uc = (OnOffUserControl) d;
            uc.text((bool)e.NewValue);
        }
        
        private void text(bool isTrue)
        {
            if (isTrue)
            {
                Value = true;
                OnButton.Background = Brushes.Gray;
                OnButton.Content = "";
                OffButton.Background = Brushes.Red;
                OffButton.Content = "OFF";
            }
            else
            {
                Value = false;
                OffButton.Background = Brushes.Gray;
                OffButton.Content = "";
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
            if (ActualHeight < 48 && ActualWidth < 48)
            {
                lessThan48();
            }
            else
            {
                text(true);
            }
            
        }

        private void Off_Click(object sender, RoutedEventArgs e)
        {
            if(ActualWidth < 48 && ActualHeight < 48)
            {
                lessThan48();
            }
            else
            {
                text(false);
            }
            
        }

        private void UserControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ActualWidth < 48 && ActualHeight < 48)
            {
                lessThan48();
            }
            else
                text(Value);
        }
    }
}
