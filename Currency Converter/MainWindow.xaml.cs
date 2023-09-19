using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;



namespace Currency_Converter
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            GetDate();
           
        }

        





         private void GetDate()
         {

             DispatcherTimer timer = new DispatcherTimer();
             timer.Tick += new EventHandler(dispatcherTimer_Tick);
             timer.Interval = TimeSpan.FromSeconds(1);
             timer.Start();





         }


         private void dispatcherTimer_Tick(object sender, EventArgs e)
         {
             DateTime dateTime = DateTime.Now;
             dateField.Text = dateTime.ToString();
         }

         
    }
}
