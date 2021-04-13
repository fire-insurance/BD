using System.Data;
using System.Windows;


using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace Kursach.View
{
    /// <summary>
    /// Логика взаимодействия для LandInfo.xaml
    /// </summary>
    /// 

    public partial class LandInfo : Window
    {
        private MainWindow back_window;
        private int index;


        public LandInfo(MainWindow _back_window, int _index)
        {
            InitializeComponent();

            back_window = _back_window;
            index = _index;

            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);

            connector.Open();

            DataTable dt = new DataTable();

            string Query = "SELECT освещение FROM землевладение WHERE Код_Землевладения LIKE " + index + "; ";
            MySqlCommand command = new MySqlCommand(Query, connector);
            string test_for_light = command.ExecuteScalar().ToString();

            if (test_for_light == "1")
            {
                LightBox.IsChecked = true;
            }

            Query = "SELECT водопровод FROM землевладение WHERE Код_Землевладения LIKE " + index + "; ";
            command = new MySqlCommand(Query, connector);
            string test_for_water = command.ExecuteScalar().ToString();

            if (test_for_water == "1")
            {
                WaterBox.IsChecked = true;
            }

            Query = "SELECT отопление FROM землевладение WHERE Код_Землевладения LIKE " + index + "; ";
            command = new MySqlCommand(Query, connector);
            string test_for_heat = command.ExecuteScalar().ToString();



            if (test_for_heat == "1")
            {
                HeatBox.IsChecked = true;
            }

            Query = "SELECT Фактическая_площадь AS 'Фактическая площадь', Площадь_застройки AS 'Площадь застройки'," +
                "Площадь_двора AS 'Площадь двора', Площадь_озеленения AS 'Площадь озеленения', Площадь_огорода AS 'Площадь огорода'," +
                "Неудобья from площади WHERE Код_Землевладения LIKE " + index + "; ";

            command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            LandInfoTable.DataContext = dt;
            LandInfoTable.ItemsSource = dt.DefaultView;

            connector.Close();


        }

        private void CloseButton1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.Close();
        }

        private void HideButton1_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }



        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.Show();
        }

        private void OpenFolder_Click(object sender, RoutedEventArgs e)
        {
            var master_folder = @"E:\Visual Studio projects\Kursach\Photos\";
            var Land_Folder = index.ToString();
            var path = System.IO.Path.Combine(master_folder, Land_Folder);

            Process.Start(path);
        }

        private void HousesInfo_Click(object sender, RoutedEventArgs e)
        {
            HouseInfo info = new HouseInfo(this, index);
            this.Hide();
            info.Show();
        }
        public void CloseBoth()
        {
            back_window.Close();
            this.Close();
        }
    }
}
