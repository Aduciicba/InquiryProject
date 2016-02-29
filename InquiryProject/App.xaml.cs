using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using Simple.Data;
using Simple.OData;
using Simple.OData.Client;

namespace InquiryProject
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        static dynamic _db;
        public static dynamic db
        {
            get
            {
                if (_db == null)
                {
                    try
                    {
                        _db = Database.OpenFile(@"F:\qu.sqlite");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Не удалось открыть подключение к БД: " + ex.Message
                                       , "Ошибка"
                                       , MessageBoxButton.OK
                                       , MessageBoxImage.Error);
                    }
                }
                return _db;
            }
        }

    }
}
