using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ThreadAffinity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Task.Factory.StartNew(ChangeTestValue);
        }

        private void ChangeTestValue()
        {
            Thread.Sleep(2500);

            UpdateTestValue("Change test value");
        }

        private void UpdateTestValue(string value)
        {
            // If we did it this way we would receive an InvalidOperationException, because 
            // the caller thread cannot access this object because a different thread owns it.
            //txtMessage.Text = value;

            // We need to use the UI thread to make any changes to XAML (our UI)
            Dispatcher.Invoke(() =>
            {
                txtMessage.Text = value;
            });
        }
    }
}
