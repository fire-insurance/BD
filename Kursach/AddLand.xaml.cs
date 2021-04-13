using System.Data;
using System.Collections.Generic;
using System.Windows;

using MySql.Data.MySqlClient;
using System.IO;

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для AddLand.xaml
    /// </summary>
    public partial class AddLand : Window
    {
        private int type;
        private MainWindow the_window;
        private string landIndex;


        public AddLand(MainWindow win, int _type, int land_index)
        {
            InitializeComponent();
            landIndex = string.Concat("'", land_index.ToString(), "'");

            type = _type;
            the_window = win;

            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);
            DataTable dt = new DataTable();
            string Query = "SELECT Город from город;";
            connector.Open();
            MySqlCommand command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            List<string> Cities = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string s = dt.Rows[i][0].ToString();
                Cities.Add(s);
            }
            
            CityBox.DataContext = Cities;
            CityBox.ItemsSource = Cities;

            if (type == 2) //Изменить
            {
                this.Title = "Изменить землевладение";
            dt = new DataTable();

                Query = "SELECT землевладение.освещение, землевладение.водопровод, землевладение.отопление," +
                   "Дата_Инвентаризации,  адреса.Город, " +
                   " адреса.Район, адреса.Улица, адреса.Номер_Дома, Примечания, Фактическая_Площадь, Площадь_застройки," +
                   "Площадь_двора, Площадь_озеленения, Площадь_огорода, Неудобья from землевладение RIGHT JOIN адреса " +
                   "ON землевладение.Код_Землевладения = " +
                   "адреса.Код_Землевладения RIGHT JOIN площади ON землевладение.Код_Землевладения = площади.Код_Землевладения WHERE землевладение.Код_Землевладения = " + landIndex + ";";

                command = new MySqlCommand(Query, connector);
                dt.Load(command.ExecuteReader());

                int Light__ = (int)dt.Rows[0][0];
                int Water__ = (int)dt.Rows[0][1];
                int Heat__ = (int)dt.Rows[0][2];

                if (Light__ == 1) LightBox.IsChecked = true;
                if (Water__ == 1) WaterBox.IsChecked = true;
                if (Heat__ == 1) WaterBox.IsChecked = true;

                DateP.Text = (string)dt.Rows[0][3];
                CityBox.Text = (string)dt.Rows[0][4];
                BlockBox.Text = (string)dt.Rows[0][5];
                StreetBox.Text = (string)dt.Rows[0][6];
                HouseBox.Text = dt.Rows[0][7].ToString();
                InfoBox.Text = (string)dt.Rows[0][8];   
                FactSq.Text = (string)dt.Rows[0][9];
                BuildSq.Text = (string)dt.Rows[0][10];
                DvorSq.Text = (string)dt.Rows[0][11];
                GreenSq.Text = (string)dt.Rows[0][12];
                FruitSq.Text = (string)dt.Rows[0][13];
                BadSq.Text = (string)dt.Rows[0][14];
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

            int Light = 0;
            int Heat = 0;
            int Water = 0;

            if (LightBox.IsChecked == true) Light = 1;
            if (HeatBox.IsChecked == true) Heat = 1;
            if (WaterBox.IsChecked == true) Water = 1;

            if (CityBox.Text == "" || BlockBox.Text == "" || StreetBox.Text == "" || HouseBox.Text == "" ||
                DateP.Text == "" || FactSq.Text == "" || BuildSq.Text == "" || DvorSq.Text == "" || GreenSq.Text == "" ||
                FruitSq.Text == "" || BadSq.Text == "")
            {

                test.Text = "Ошибка! Пустое поле ввода!";
                return;
            }

                string City = SQLFixer(CityBox.Text);
                string Block = SQLFixer(BlockBox.Text);
                string Street = SQLFixer(StreetBox.Text);
                string HouseN = SQLFixer(HouseBox.Text);
                string Date = SQLFixer(DateP.Text);

                string FactSquare = SQLFixer(FactSq.Text);
                string BuildSquare = SQLFixer(BuildSq.Text);
                string DvorSquare = SQLFixer(DvorSq.Text);
                string GreenSquare = SQLFixer(GreenSq.Text);
                string OgorodSquare = SQLFixer(FruitSq.Text);
                string BadSquare = SQLFixer(BadSq.Text);

                string InfoSquare = SQLFixer(InfoBox.Text);
            
            
            
            if (type == 1)
            {   
                string Query = "INSERT INTO землевладение (Дата_Инвентаризации,Освещение,Водопровод,Отопление,Примечания) VALUES (" + Date + " ," + Light + "," + Water + ", " + Heat + "," +
                    "" + InfoSquare + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "SELECT Код_Землевладения FROM землевладение ORDER BY Код_Землевладения DESC;";
                command = new MySqlCommand(Query, connector);
                int LandIndex = (int)command.ExecuteScalar();

                Query = "INSERT INTO адреса (Город, Район, Улица, Номер_дома, Код_Землевладения) VALUES (" + City + ", " + Block + ", " + Street + ", " + HouseN + ", " + LandIndex + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "INSERT INTO площади (Фактическая_площадь, Площадь_застройки, Площадь_двора, Площадь_озеленения, Площадь_огорода, Неудобья, Код_Землевладения) " +
                    "VALUES (" + FactSquare + ", " + BuildSquare + ", " + DvorSquare + ", " + GreenSquare + ", " + OgorodSquare + ", " + BadSquare + ", " + LandIndex + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                string folderpath = @"E:\Visual Studio projects\Kursach\Photos\";
                string foldername = LandIndex.ToString();
                string path = System.IO.Path.Combine(folderpath, foldername);

                Directory.CreateDirectory(path);
            }
            else if (type == 2)
            {
                

                string Query = "UPDATE землевладение SET Дата_Инвентаризации=" + Date + ",Освещение=" + Light + ",Водопровод=" + Water + "," +
                    " Отопление=" + Heat + ",Примечания=" + InfoSquare + " WHERE (Код_Землевладения=" + landIndex + ");";
                MySqlCommand command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "UPDATE адреса SET Город=" + City + ", Район= " + Block + ", Улица=" + Street + ", Номер_дома=" + HouseN + " WHERE (Код_Землевладения=" + landIndex + ");";
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                Query = "UPDATE площади SET Фактическая_площадь="+ FactSquare +", Площадь_застройки=" + BuildSquare + ", Площадь_двора=" + DvorSquare + ", Площадь_озеленения=" + GreenSquare + ", " +
                    "Площадь_огорода=" + OgorodSquare + ", Неудобья=" + BadSquare + "  WHERE (Код_Землевладения=" + landIndex + ");";

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
