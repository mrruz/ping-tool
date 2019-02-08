using System;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows;


namespace ExampleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int _i;

        private int I { get => _i; set => _i = value; }

        public MainWindow()
        {

            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            // Use the default Ttl value which is 128,
            // but change the fragmentation behavior.
            options.DontFragment = true;

            // Create a buffer of 32 bytes of data to be transmitted.
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            try
            {
                PingReply reply = pingSender.Send(TextBox1.Text, timeout, buffer, options);
                if (reply.Status == IPStatus.Success)
                {
                    Label1.Content = "Address: " + reply.Address.ToString();
                    Label2.Content = "RoundTrip time: " + reply.RoundtripTime;
                    Label3.Content = "Time to live: " + reply.Options.Ttl;
                    Label4.Content = "Don't fragment: " + reply.Options.DontFragment;
                    Label5.Content = "Buffer size: " + reply.Buffer.Length;


                    //System.Diagnostics.Debug.WriteLine("Address: {0}", reply.Address.ToString());
                    //System.Diagnostics.Debug.WriteLine("RoundTrip time: {0}", reply.RoundtripTime);
                    //System.Diagnostics.Debug.WriteLine("Time to live: {0}", reply.Options.Ttl);
                    //System.Diagnostics.Debug.WriteLine("Don't fragment: {0}", reply.Options.DontFragment);
                    //System.Diagnostics.Debug.WriteLine("Buffer size: {0}", reply.Buffer.Length);
                }
            }
            catch (Exception)
            {
                Label1.Content = "You're an idiot.";
            }
           
        }

    }
}
