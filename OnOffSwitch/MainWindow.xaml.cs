using OnOffSwitch.Model;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Thickness originalMargin;
        OnOffData onOffData = new OnOffData(false);

        public MainWindow()
        {
            
            this.DataContext = onOffData;

            InitializeComponent();
            
            originalMargin = OnOffUserControl.Margin;
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if(e.PreviousSize.Height != 0 && e.PreviousSize.Width != 0)
            {
                double originalHeight = e.PreviousSize.Height;
                double originalWidth = e.PreviousSize.Width;
                double newHeight = ActualHeight;
                double newWidth = ActualWidth;

                double percentH = newHeight / originalHeight;
                double percentW = newWidth / originalWidth;

                double controlHeight = OnOffUserControl.Height;
                double controlWidth = OnOffUserControl.Width;

                OnOffUserControl.Height = controlHeight * percentH;
                OnOffUserControl.Width = controlWidth * percentW;

                Thickness newMargin = new Thickness();
                newMargin.Left = originalMargin.Left * percentW;
                newMargin.Top = originalMargin.Top * percentH;
                newMargin.Bottom = originalMargin.Bottom * percentH;
                newMargin.Right = originalMargin.Right * percentW;
                OnOffUserControl.Margin = newMargin;
                originalMargin = newMargin;
            }
        }
    }
}
