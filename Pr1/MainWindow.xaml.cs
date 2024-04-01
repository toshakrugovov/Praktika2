using System;
using System.Collections.Generic;
using System.Data;
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
using Pr1.employeeTableAdapters;

namespace Pr1
{

 
    public partial class MainWindow : Window
    {
        // DataSet
        EmployeeTableAdapter employee = new EmployeeTableAdapter();
        Positions_of_employeesTableAdapter post = new Positions_of_employeesTableAdapter();

        //EF

        //employeeEntities context = new employeeEntities();


        public MainWindow()
        {
            //DataSet
            InitializeComponent();
            EmployeeDgr.ItemsSource = employee.GetData();
            pstCbx.ItemsSource = post.GetData();

            //EF
            //EmployeeDgr.ItemsSource = context.Employee.ToList(); //выгрузка
            //pstCbx.ItemsSource = context.Positions_of_employees.ToList(); //выгрузка

        }

        /* private void EmployeeDgr_SelectionChanged(object sender, SelectionChangedEventArgs e)
           {

             //DataSet
             var info = (EmployeeDgr.SelectedItem as DataRowView).Row;
             empTbx.Text= info[1].ToString();//подтягивает данные из первого столбца
             pstCbx.SelectedValue = Convert.ToInt32(info[4]); //подтягивает данные из привязки


             //EF

            //var info = (EmployeeDgr.SelectedItem as Employee);
           //empTbx.Text = info.Surname; // подтягиваем данные из первого столбца
             //pstCbx.SelectedItem= info.Positions_of_employees; // подтягиваем данные из привязки



            } */

        private void Button_Click(object sender, RoutedEventArgs e)
            {
                Table2 table2 = new Table2();
                table2.ShowDialog();
               
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            employee.InsertQuery(NameTbx.Text,SurnameTbx.Text, PatronymicTbx.Text, Convert.ToInt32(pstCbx.SelectedValue));
            EmployeeDgr.ItemsSource = employee.GetData();

        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if (EmployeeDgr.SelectedItem !=null)
            {
                var id = Convert.ToInt32((EmployeeDgr.SelectedItem as DataRowView).Row[0]);
                employee.DeleteQuery(id);
                EmployeeDgr.ItemsSource = employee.GetData();
            }
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (EmployeeDgr.SelectedItem != null)
            {
                var id = Convert.ToInt32((EmployeeDgr.SelectedItem as DataRowView).Row[0]);
                employee.UpdateQuery(NameTbx.Text, SurnameTbx.Text, PatronymicTbx.Text, Convert.ToInt32(pstCbx.SelectedValue), id);
                EmployeeDgr.ItemsSource = employee.GetData();
            }
        }
    }
}

