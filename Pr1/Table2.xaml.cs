using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Pr1.employeeTableAdapters;

namespace Pr1
{
    /// <summary>
    /// Логика взаимодействия для Table2.xaml
    /// </summary>
    public partial class Table2 : Window
    {

        employeeEntities context = new employeeEntities();

        public Table2()
        {
            InitializeComponent();
            PostDrg.ItemsSource = context.Positions_of_employees.ToList();
            empCbx.ItemsSource = context.Employee.ToList();

        }

       

        private void PostDrg_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var info = PostDrg.SelectedItem as Positions_of_employees;
            postTbx.Text = info.Post; // подтягиваем данные из первого столбца
            empCbx.SelectedItem = info.Employee; // подтягиваем данные из привязки
            employeeesalaryTbx.Text = info.Employee_salary.ToString();
            




        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          var emp = new Pr1.Positions_of_employees();
          emp.Post = postTbx.Text;
          emp.Employee = null;
          emp.Employee_salary = Convert.ToInt32(employeeesalaryTbx.Text);
          context.Positions_of_employees.Add(emp);
          context.SaveChanges();
          PostDrg.ItemsSource= context.Positions_of_employees.ToList() ;



        }

        private void Button_Click_0(object sender, RoutedEventArgs e)
        {
            if(PostDrg.SelectedItem != null)
            {
                var emp = PostDrg.SelectedItem as Positions_of_employees;
                context.Positions_of_employees.Remove(emp);
                context.SaveChanges();
                PostDrg.ItemsSource = context.Positions_of_employees.ToList();

            }
            

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (PostDrg.SelectedItem != null)
            {
                var emp = PostDrg.SelectedItem as Positions_of_employees;
                emp.Post = postTbx.Text;
                emp.Employee_salary = Convert.ToInt32(employeeesalaryTbx.Text);
                context.SaveChanges();
                PostDrg.ItemsSource = context.Positions_of_employees.ToList();

            }
            
            

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainWindow mainwindow = new MainWindow();
            mainwindow.Show();
            
        }
    }
}
