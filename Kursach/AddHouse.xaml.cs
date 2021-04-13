using System.Data;
using System.Collections.Generic;
using System.Windows;

using MySql.Data.MySqlClient;
using Kursach.View;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AddHouse.xaml
    /// </summary>

    public partial class AddHouse : Window
    {
        public string[] House_types { get; set; }
       public string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";
        private int type;
        private int House_Index;
        private int Land_Index;
        private HouseInfo the_window;


        public AddHouse(HouseInfo win, int _type, int land_index, int house_index)
        {
            InitializeComponent();
            the_window = win;
            type = _type;
            Land_Index = land_index;
            House_Index = house_index;

            House_types = new string[] { "Основной", "Вспомогательный" };
            TypeBox.DataContext = House_types;
            TypeBox.ItemsSource = House_types;

            MySqlConnection connector = new MySqlConnection(connection);
            DataTable dt = new DataTable();
            string Query = "SELECT Назначение_Здания from назначение_здания;";
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
                this.Title = "Изменить здание";
                dt = new DataTable();

                Query = "SELECT Возведено_самовольно, Назначение, Тип," +
                   "Год_постройки, Износ, Общая_площадь, Жилая_площадь, Материал_стен, Инвентаризационная_стоимость," +
                   "Этажность, Номер_здания FROM информация_о_здании RIGHT JOIN здание ON здание.Код_здания = информация_о_здании.Код_здания" +
                   " WHERE информация_о_здании.Код_Здания = " + House_Index + ";";

                command = new MySqlCommand(Query, connector);
                dt.Load(command.ExecuteReader());

                string SelfBuild__ = dt.Rows[0][0].ToString();
                

                if (SelfBuild__ == "1") SelfBuildBox.IsChecked = true;

                PurposeBox.Text = (string)dt.Rows[0][1];
                TypeBox.Text = (string)dt.Rows[0][2];
                YearBox.Text = dt.Rows[0][3].ToString();
                BrokenBox.Text = dt.Rows[0][4].ToString();
                TotalSquareBox.Text = dt.Rows[0][5].ToString();
                LifeSquareBox.Text = dt.Rows[0][6].ToString();
                WallsBox.Text = (string)dt.Rows[0][7];
                PriceBox.Text = dt.Rows[0][8].ToString();
                LevelsBox.Text = dt.Rows[0][9].ToString();
                NumberBox.Text = dt.Rows[0][10].ToString();

            }

            connector.Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);
            connector.Open();

            int SelfBuild = 0;

            if (SelfBuildBox.IsChecked == true) SelfBuild = 1;

            if (PurposeBox.Text == "" || TypeBox.Text == "" || YearBox.Text == "" || BrokenBox.Text == "" ||
                TotalSquareBox.Text == "" || LifeSquareBox.Text == "" || WallsBox.Text == "" || PriceBox.Text == "" || LevelsBox.Text == "" || NumberBox.Text == "")
            {

                test.Text = "Ошибка! Пустое поле ввода!";
                return;
            }

            string Purpose = SQLFixer(PurposeBox.Text);
            string Type = SQLFixer(TypeBox.Text);
            string Year = SQLFixer(YearBox.Text);
            string Wear = SQLFixer(BrokenBox.Text);
            string TotalSquare = SQLFixer(TotalSquareBox.Text);

            string LifeSquare = SQLFixer(LifeSquareBox.Text);
            string WallsMaterial = SQLFixer(WallsBox.Text);
            string Price = SQLFixer(PriceBox.Text);
            string Levels = SQLFixer(LevelsBox.Text);
            string Number = SQLFixer(NumberBox.Text);

            if (type == 1) //Добавить
            {
                
                
                string Query = "INSERT INTO здание (Номер_Здания,Код_Землевладения) VALUES " +
                    "(" + Number + " ," + Land_Index + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "SELECT Код_Здания FROM здание ORDER BY Код_Здания DESC;";
                command = new MySqlCommand(Query, connector);
                House_Index = (int)command.ExecuteScalar();

                Query = "INSERT INTO информация_о_здании (Назначение, Тип, Возведено_самовольно, Год_Постройки, Общая_площадь, Жилая_площадь," +
                    "Износ, Материал_стен, Инвентаризационная_стоимость,Этажность,Код_здания) VALUES " +
                    "(" + Purpose + ", " + Type + ", " + SelfBuild + ", " + Year + ", " + TotalSquare + ", " + LifeSquare + "" +
                    ", " + Wear + ", " + WallsMaterial + ", " + Price + ", " + Levels + ", " + House_Index + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();
            }
            else if (type == 2)
            {


                string Query = "UPDATE здание SET Номер_Здания=" + Number + " WHERE (Код_Здания=" + House_Index + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "UPDATE информация_о_здании SET Назначение=" + Purpose + ", Тип= " + Type + ", Возведено_самовольно=" + SelfBuild + ", " +
                    "Год_Постройки=" + Year + ", Общая_площадь = " + TotalSquare + ",Жилая_Площадь=" + LifeSquare + ",Износ=" + Wear + "" +
                    ",Материал_стен=" + WallsMaterial + ",Инвентаризационная_стоимость=" + Price + ", Этажность="+ Levels +"" +
                    " WHERE (Код_Здания=" + House_Index + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

            }
            this.Close();
            the_window.updateTable();
        }

        private string SQLFixer(string a)
        {
            a = string.Concat("'", a, "'");

            return a;
        }
    }
}