using System.Data;
using System.Windows;
using System.Windows.Input;
using ClosedXML.Excel;

using MySql.Data.MySqlClient;
using Kursach.View;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string[] combo_Names { get; set; }
        private DataTable dt;
        public MainWindow()
        {
            InitializeComponent();

            combo_Names = new string[] { "Словарь городов", "Назначения зданий", "Назначение помещений" };
            DataContext = this;

            LoadLoginWindow(this);
            updateTable();

            
        }

        public void updateTable()
        {
            Error.Text = "";
            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);

            connector.Open();

             dt = new DataTable();

            string Query = "SELECT землевладение.Код_Землевладения AS '#', " +
                "DATE_FORMAT(Дата_Инвентаризации, '%D,%M,%Y') AS 'Дата инвентаризации', CONCAT('г. ', адреса.Город,', район '," +
                " адреса.Район, ', ул. ', адреса.Улица, ', д. '," +
                "адреса.Номер_Дома) AS Адрес, Примечания from землевладение RIGHT JOIN адреса " +
                "ON землевладение.Код_Землевладения = " +
                "адреса.Код_Землевладения;";

            MySqlCommand command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            TableView.DataContext = dt;
            TableView.ItemsSource = dt.DefaultView;


            connector.Close();
        }

        public void LoadLoginWindow(MainWindow window)
        {
            this.Hide();
            Login login = new Login(window);
            login.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
             this.Close();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TableView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Data.DataRowView selectedRow = (System.Data.DataRowView)TableView.SelectedItems[0];
            int landId = (int)selectedRow.Row[0];

            LandInfo l_info = new LandInfo(this,landId);
            this.Hide();
            l_info.Show();
            Error.Text = "";
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            AddLand add = new AddLand(this,1,0);
            add.Show();
            
        }

        private void CityS_Click(object sender, RoutedEventArgs e)
        {
            Dictionary CityDictionary = new Dictionary(1);
            CityDictionary.Show();
        }

        private void HouseS_Click(object sender, RoutedEventArgs e)
        {
            Dictionary HouseDictionary = new Dictionary(2);
            HouseDictionary.Show();
        }

        private void RoomS_Click(object sender, RoutedEventArgs e)
        {
            Dictionary RoomDictionary = new Dictionary(3);
            RoomDictionary.Show();
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableView.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                
                return;
            }
            Error.Text = "";


            System.Data.DataRowView selectedRow = (System.Data.DataRowView)TableView.SelectedItems[0];
            int landId = (int)selectedRow.Row[0];

            AddLand edit = new AddLand(this, 2, landId);
            edit.Show();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TableView.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                return;
            }
            Error.Text = "";

            System.Data.DataRowView selectedRow = (System.Data.DataRowView)TableView.SelectedItems[0];
            int landId = (int)selectedRow.Row[0];

            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);
            connector.Open();
            string Query = "DELETE FROM адреса WHERE Код_Землевладения = " + landId + ";";
            MySqlCommand command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM площади WHERE Код_Землевладения = " + landId + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM здание WHERE Код_Землевладения = " + landId + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM землевладение WHERE Код_Землевладения = " + landId + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            connector.Close();

            updateTable();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchBox.Text != "")
            {
                string find = SearchBox.Text;

                find = string.Concat("'%", find, "%'");

                string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

                MySqlConnection connector = new MySqlConnection(connection);
                connector.Open();
                string Query = "SELECT землевладение.Код_Землевладения AS '#', " +
                "DATE_FORMAT(Дата_Инвентаризации, '%D,%M,%Y') AS 'Дата инвентаризации', CONCAT('г. ', адреса.Город,', район '," +
                " адреса.Район, ', ул. ', адреса.Улица, ', д. '," +
                "адреса.Номер_Дома) AS Адрес, Примечания from землевладение RIGHT JOIN адреса " +
                "ON землевладение.Код_Землевладения = " +
                "адреса.Код_Землевладения WHERE (Дата_Инвентаризации LIKE " + find + ") OR (Город LIKE " + find + ") OR (Район LIKE " + find + ")" +
                "OR (Улица LIKE " + find + ") OR (Номер_Дома LIKE " + find + ") OR (Примечания LIKE " + find + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                dt = new DataTable();

                dt.Load(command.ExecuteReader());

                TableView.DataContext = dt;
                TableView.ItemsSource = dt.DefaultView;

                connector.Close();
            }
            else updateTable();
        }

        private void ExportButton_Click(object sender, RoutedEventArgs e)
        {
            XLWorkbook wb = new XLWorkbook();
            wb.Worksheets.Add(dt, "Таблица землевладений");
            wb.Worksheet(1).Column(1).AdjustToContents();
            wb.Worksheet(1).Column(2).AdjustToContents();
            wb.Worksheet(1).Column(3).AdjustToContents();
            wb.Worksheet(1).Column(4).AdjustToContents();


            wb.SaveAs(@"C:\Users\Дмитрий\Desktop\Отчет.xlsx");
        }
    }
}
