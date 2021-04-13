using System.Data;
using System.Collections.Generic;
using System.Windows;

using MySql.Data.MySqlClient;


namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AddRoom.xaml
    /// </summary>
    public partial class AddRoom : Window
    {
        public string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";
        private int type;
        private int House_Index;
        private int Room_Index;
        private RoomInfo the_window;

        public AddRoom(RoomInfo win,int _type, int house_index, int room_index)
        {
            InitializeComponent();

            the_window = win;
            type = _type;
            House_Index = house_index;
            Room_Index = room_index;

            MySqlConnection connector = new MySqlConnection(connection);
            DataTable dt = new DataTable();
            string Query = "SELECT Назначение_Помещения from назначение_помещения;";
            connector.Open();
            MySqlCommand command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            List<string> Purposes = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][0].ToString();
                Purposes.Add(s);
            }

            PurposeBox.DataContext = Purposes;
            PurposeBox.ItemsSource = Purposes;
            //////////////////////////


            if (type == 2)
            {
                this.Title = "Изменить помещения";
                dt = new DataTable();

                Query = "SELECT Назначение_помещения, Площадь, Высота, Этаж, Номер_помещения " +
                    "FROM информация_о_помещении RIGHT JOIN помещение ON помещение.Код_помещения = информация_о_помещении.Код_помещения" +
                   " WHERE информация_о_помещении.Код_Помещения = " + Room_Index + ";";

                command = new MySqlCommand(Query, connector);
                dt.Load(command.ExecuteReader());

                PurposeBox.Text = (string)dt.Rows[0][0].ToString();
                SquareBox.Text = (string)dt.Rows[0][1].ToString();
                HeightBox.Text = dt.Rows[0][2].ToString();
                LevelBox.Text = dt.Rows[0][3].ToString();
                NumberBox.Text = dt.Rows[0][4].ToString();

            }

            connector.Close();

        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {

            MySqlConnection connector = new MySqlConnection(connection);
            connector.Open();


            if (PurposeBox.Text == "" || SquareBox.Text == "" || HeightBox.Text == "" || LevelBox.Text == "" || NumberBox.Text == "")
            {

                test.Text = "Ошибка! Пустое поле ввода!";
                return;
            }

            string Purpose = SQLFixer(PurposeBox.Text);
            string Square = SQLFixer(SquareBox.Text);
            string Height = SQLFixer(HeightBox.Text);
            string Level = SQLFixer(LevelBox.Text);
            string Number = SQLFixer(NumberBox.Text);

            if (type == 1)
            {

                string Query = "INSERT INTO помещение (Номер_Помещения,Код_Здания) VALUES " +
                    "(" + Number + " ," + House_Index + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "SELECT Код_Помещения FROM помещение ORDER BY Код_Помещения DESC;";
                command = new MySqlCommand(Query, connector);
                Room_Index = (int)command.ExecuteScalar();

                Query = "INSERT INTO информация_о_помещении (Назначение_помещения, Площадь, Высота, Этаж, Код_помещения) VALUES " +
                    "(" + Purpose + ", " + Square + ", " + Height + ", " + Level + ", " + Room_Index + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();
            }
            else if (type == 2) //Изменить
            {

                string Query = "UPDATE помещение SET Номер_Помещения=" + Number + " WHERE (Код_Помещения=" + Room_Index + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "UPDATE информация_о_помещении SET Назначение_помещения=" + Purpose + ", Площадь= " + Square + ", Высота=" + Height + ", " +
                    "Этаж=" + Level + " WHERE (Код_Помещения=" + Room_Index + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

            }
            this.Close();
            the_window.updateTable();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private string SQLFixer(string a)
        {
            a = string.Concat("'", a, "'");

            return a;
        }

    }
}
