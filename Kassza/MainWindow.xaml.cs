using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Kassza.Resources;

namespace Kassza
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            if (Kassza.Resources.FirstTime.CheckFirstTimeRun())
            {
                //TODO:Start setup process


                //TODO: Remove comment after debugging
                //SetKey();
            }
            else
            {
                //TODO:Start the application
            }
            //DbCls.CreateDB();
            DbCls.CreateTables();
        }

    }
}
