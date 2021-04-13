using System.Data;
using System.Windows;

using MySql.Data.MySqlClient;

namespace Kursach.View
{
    /// <summary>
    /// Логика взаимодействия для Dictionary.xaml
    /// </summary>
    public partial class Dictionary : Window
    {
        private int Ok_Type = 0;
       private int DictionaryType;
       public string QueryB;

        public Dictionary(int _type)
        {
            InitializeComponent();
            DictionaryType = _type;

            if (_type == 1)
            {
                this.Title = "Словарь городов";
            }
            else if (_type == 2)
            {
                this.Title = "Словарь назначений зданий";
            }
            else if (_type == 3)
            {
                this.Title = "Словарь назначений помещений";
            }

            updateTable();
        }

        public void updateTable(string Query, bool update)
        {
            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);
            DataTable dt = new DataTable();

                connector.Open();
                MySqlCommand command = new MySqlCommand(Query, connector);

            if (update)
            {
                command = new MySqlCommand(Query, connector);
                command.ExecuteScalar();

                switch (DictionaryType)
                {

                    case 1:
                        {
                            Query = "SELECT Город FROM город;";
                            break;
                        }
                    case 2:
                        {
                            Query = "SELECT Назначение_Здания AS 'Назначение здания' FROM назначение_здания;";
                            break;
                        }
                    case 3:
                        {
                            Query = "SELECT Назначение_Помещения AS 'Назначение помещения' FROM назначение_помещения;";
                            break;
                        }
                }
                command = new MySqlCommand(Query, connector);
            }

            dt.Load(command.ExecuteReader());

            Table.DataContext = dt;
            Table.ItemsSource = dt.DefaultView;

            connector.Close();
        }

        public void updateTable()
        {
            string connection = "server = localhost; user=root; database=kursach; password=Dragon2012";

            MySqlConnection connector = new MySqlConnection(connection);
            DataTable dt = new DataTable();

            connector.Open();

            string Query = "";

            switch (DictionaryType)
            {

                case 1:
                    {
                        Query = "SELECT Город FROM город;";
                        break;
                    }
                case 2:
                    {
                        Query = "SELECT Назначение_Здания AS 'Назначение здания' FROM назначение_здания;";
                        break;
                    }
                case 3:
                    {
                        Query = "SELECT Назначение_Помещения AS 'Назначение помещения' FROM назначение_помещения;";
                        break;
                    }
            }

                    MySqlCommand command = new MySqlCommand(Query, connector);
            dt.Load(command.ExecuteReader());

            Table.DataContext = dt;
            Table.ItemsSource = dt.DefaultView;

            connector.Close();
        }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
           Error.Text = "";
            EnterText.Visibility = Visibility.Visible;
            OkButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;
            Ok_Type = 1;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            EnterText.Visibility = Visibility.Hidden;
            OkButton.Visibility = Visibility.Hidden;
            CancelButton.Visibility = Visibility.Hidden;

            EnterText.Clear();
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (Table.SelectedIndex == -1)
            {
                Error.IsEnabled = true;
                Error.Text = "Ошибка! Строка не выбрана!";
                return;
            }

            Error.Text = "";


            System.Data.DataRowView selectedRow = (System.Data.DataRowView)Table.SelectedItems[0];
            string oldValue = selectedRow.Row[0].ToString();
            oldValue = string.Concat("'", oldValue, "'");
            string Query = "";
            switch (DictionaryType)
            {

                case 1:
                    {
                        Query = "DELETE FROM город WHERE Город = " + oldValue + ";";
                        break;
                    }
                case 2:
                    {
                        Query = "DELETE FROM назначение_здания WHERE Назначение_Здания = " + oldValue + ";";
                        break;
                    }
                case 3:
                    {
                        Query = "DELETE FROM назначение_помещения WHERE Назначение_Помещения = " + oldValue + ";";
                        break;
                    }
            }

            
            updateTable(Query, true);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
             if (Table.SelectedIndex == -1)
                {
                Error.IsEnabled = true;
                Error.Text = "Ошибка! Строка не выбрана!";
                    return;
                }

                Error.Text = "";

            EnterText.Visibility = Visibility.Visible;
            OkButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;

            Ok_Type = 2;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            EnterText.Visibility = Visibility.Hidden;
            OkButton.Visibility = Visibility.Hidden;
            CancelButton.Visibility = Visibility.Hidden;
            string newValue = string.Concat("'", EnterText.Text, "'");
            string Query = "";
            if (Ok_Type == 1) //Добавить
            {
                switch (DictionaryType)
                {

                    case 1:
                        {
                            Query = "INSERT INTO город (Город) VALUES(" + newValue + ");";
                            break;
                        }
                    case 2:
                        {
                            Query = "INSERT INTO назначение_здания (Назначение_Здания) VALUES(" + newValue + ");";
                            break;
                        }
                    case 3:
                        {
                            Query = "INSERT INTO назначение_помещения (Назначение_Помещения) VALUES(" + newValue + ");";
                            break;
                        }
                }
               updateTable(Query, true);
            }
            else if (Ok_Type == 2) // Изменить
            {

                System.Data.DataRowView selectedRow = (System.Data.DataRowView)Table.SelectedItems[0];
                string oldValue = selectedRow.Row[0].ToString();

                oldValue = string.Concat("'", oldValue, "'");

                switch (DictionaryType)
                {

                    case 1:
                        {
                            Query = "UPDATE город SET Город = " + newValue + " WHERE Город = " + oldValue + ";";
                            QueryB = "UPDATE адреса SET Город = " + newValue + " WHERE Город = " + oldValue + ";";
                            break;
                        }
                    case 2:
                        {
                            Query = "UPDATE назначение_здания SET Назначение_Здания = " + newValue + " WHERE Назначение_Здания = " + oldValue + ";";
                            break;
                        }
                    case 3:
                        {
                            Query = "UPDATE назначение_помещения SET Назначение_Помещения = " + newValue + " WHERE Назначение_Помещения = " + oldValue + ";";
                            break;
                        }
                }
   
                updateTable(Query, true);

                
            }
            else // Найти
            {
                switch (DictionaryType)
                {

                    case 1:
                        {
                            Query = "SELECT Город FROM город WHERE Город = " + newValue + ";";
                            break;
                        }
                    case 2:
                        {
                            Query = "SELECT Назначение_Здания FROM назначение_здания WHERE Назначение_Здания = " + newValue + ";";
                            break;
                        }
                    case 3:
                        {
                            Query = "SELECT Назначение_Помещения FROM назначение_помещения WHERE Назначение_Помещения = " + newValue + ";";
                            break;
                        }
                }

                
                updateTable(Query, false);
            }

            EnterText.Clear();

        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Error.Text = "";
            EnterText.Visibility = Visibility.Visible;
            OkButton.Visibility = Visibility.Visible;
            CancelButton.Visibility = Visibility.Visible;

            Ok_Type = 3;
        }
    }
}
