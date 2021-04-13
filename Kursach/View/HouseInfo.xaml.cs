using System.Data;
using System.Windows;
using System.Windows.Input;

using MySql.Data.MySqlClient;

namespace Kursach.View
{
    /// <summary>
    /// Логика взаимодействия для HouseInfo.xaml
    /// </summary>
    public partial class HouseInfo : Window

    {
        private LandInfo back_window;
        private int Land_Index;
        public DataTable dt;
        public string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";
        public MySqlConnection connector;
        public string Query;
        public MySqlCommand command;

        public HouseInfo(LandInfo w, int ind)
        {
            InitializeComponent();
            back_window = w;
            Land_Index = ind;

            updateTable();
        }

        public void updateTable()
        {
            Error.Text = "";

            connector = new MySqlConnection(connection);

            connector.Open();

            dt = new DataTable();

            Query = "SELECT Номер_Здания AS '#', Назначение, Тип, Возведено_самовольно AS 'Самострой', " +
               "Год_постройки AS 'Год постройки', Общая_площадь AS 'Общая площадь', Жилая_площадь AS 'Жилая площадь'," +
               "Износ AS 'Износ, %', Материал_стен AS 'Материал стен', информация_о_здании.Инвентаризационная_стоимость AS 'Инв-ая стоимость' ," +
               "Этажность from здание RIGHT JOIN информация_о_здании " +
               "ON здание.Код_Здания = информация_о_здании.Код_Здания WHERE здание.Код_Землевладения = " + Land_Index + " ;";

            command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            HouseInfoTable.DataContext = dt;
            HouseInfoTable.ItemsSource = dt.DefaultView;

            connector.Close();
        }

        private void CloseButton2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.CloseBoth();
        }

        public void CloseAll()
        {
            this.Close();
                back_window.CloseBoth();
        }

        private void HideButton2_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HouseInfoTable.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                return;
            }
            Error.Text = "";
           int RowIndex = HouseInfoTable.SelectedIndex;
            int House_Number = (int)dt.Rows[RowIndex][0];



            Query = "SELECT Код_здания FROM здание WHERE Номер_Здания ="+ House_Number +" AND Код_Землевладения= "+ Land_Index +";";
            connector = new MySqlConnection(connection);

            connector.Open();
            command = new MySqlCommand(Query, connector);
            int House_index = (int)command.ExecuteScalar();


            AddHouse newHouse = new AddHouse(this, 2, Land_Index, House_index);
            newHouse.Show();
            connector.Close();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (HouseInfoTable.SelectedIndex == -1)
            {
                Error.Text = "Не выбрана строка!";
                return;
            }
            Error.Text = "";
           int RowIndex = HouseInfoTable.SelectedIndex;
            int House_Number = (int)dt.Rows[RowIndex][0];

            Query = "SELECT Код_здания FROM здание WHERE Номер_Здания =" + House_Number + " AND Код_Землевладения= " + Land_Index + ";";
            connector = new MySqlConnection(connection);

            connector.Open();
            command = new MySqlCommand(Query, connector);
            int House_index = (int)command.ExecuteScalar();

            Query = "DELETE FROM информация_о_здании WHERE информация_о_здании.Код_Здания = " + House_index + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM помещение WHERE помещение.Код_Здания = " + House_index + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            Query = "DELETE FROM здание WHERE здание.Код_Здания = " + House_index + ";";
            command = new MySqlCommand(Query, connector);
            command.ExecuteScalar();

            updateTable();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddHouse newHouse = new AddHouse(this,1,Land_Index,0);
            newHouse.Show();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            back_window.Show();
        }

        private void HouseInfoTable_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int RowIndex = HouseInfoTable.SelectedIndex;
            int houseIndex = (int)dt.Rows[RowIndex][0];
            RoomInfo room = new RoomInfo(this,houseIndex);
            this.Hide();
            room.Show();
            Error.Text = "";
        }
    }
}
