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

namespace RoutedEventHandle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //add by AddHander

            //add by Lambda expression
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            //demo for direct Routed Event
            MessageBox.Show("sender: " + sender.GetType().ToString());
        }

        private void noButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            //tunneling
            MessageBox.Show("sender: " + sender.GetType().ToString());
        }
       
    }

    public partial class MyButton : Button
    {
        //create a Routed event
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(MyButton));


        //add Handler
        public event RoutedEventHandler Tap
        {
            add
            {
                base.AddHandler(TapEvent, value);
            }
            remove
            {
                base.RemoveHandler(TapEvent, value);
            }
        }

        void RaiseTapEvent()
        {
            RoutedEventArgs args = new RoutedEventArgs(MyButton.TapEvent);
            RaiseEvent(args);
        }

        protected override void OnClick()
        {
            //base.OnClick();
            RaiseTapEvent();
        }
    }
}
