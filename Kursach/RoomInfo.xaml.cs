using System.Data;
using System.Windows;

using MySql.Data.MySqlClient;
using Kursach.View;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class RoomInfo : Window
    {
        private HouseInfo back_window;
        private int House_Index;
        public DataTable dt;
        public string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";
        public MySqlConnection connector;
        public string Query;
        public MySqlCommand command;
        public RoomInfo(HouseInfo win, int ind)
        {
            back_window = win;
            House_Index = ind;

            InitializeComponent();
            updateTable();
        }

        public void updateTable()
        {
            Error.Text = "";

            connector = new MySqlConnection(connection);

            connector.Open();

            dt = new DataTable();

            Query = "SELECT Номер_Помещения AS '#', Назначение_помещения AS 'Назначение помещения', Площадь, Высота, " +
               "Этаж FROM помещение RIGHT JOIN информация_о_помещении " +
               "ON помещение.Код_Помещения = информация_о_помещении.Код_помещения WHERE помещение.Код_Здания = " + House_Index + " ;";

            command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            RoomInfoTable.DataContext = dt;
            RoomInfoTable.ItemsSource = dt.DefaultView;

            connector.Close();
        }
        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.CloseAll();
        }

        private void HideButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddRoom newHouse = new AddRoom(this, 1, House_Index, 0);
            newHouse.Show();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoomInfoTable.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                return;
            }
            Error.Text = "";
            int RowIndex = RoomInfoTable.SelectedIndex;
            int Room_Number = (int)dt.Rows[RowIndex][0];

            Query = "SELECT Код_помещения FROM помещение WHERE Номер_Помещения =" + Room_Number + " AND Код_Здания = " + House_Index + ";";
            connector = new MySqlConnection(connection);

            connector.Open();
            command = new MySqlCommand(Query, connector);
            int Room_index = (int)command.ExecuteScalar();

            Query = "DELETE FROM информация_о_помещении WHERE информация_о_помещении.Код_Помещения = " + Room_index + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM помещение WHERE помещение.Код_Помещения = " + Room_index + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            updateTable();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (RoomInfoTable.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                return;
            }
            Error.Text = "";
            int RowIndex = RoomInfoTable.SelectedIndex;
            int Room_Number = (int)dt.Rows[RowIndex][0];

            Query = "SELECT Код_помещения FROM помещение WHERE Номер_Помещения =" + Room_Number + " AND Код_Здания= " + House_Index + ";";
            connector = new MySqlConnection(connection);

            connector.Open();
            command = new MySqlCommand(Query, connector);
            int Room_index = (int)command.ExecuteScalar();


            AddRoom newHouse = new AddRoom(this, 2, House_Index, Room_index);
            newHouse.Show();
            connector.Close();
        }
    }
}
