using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
   

    public class TimetableRow
    {
        public TimetableRow(int number, string lesson,string au, string nameTeacher) {
            Number = number;
            Lesson = lesson;
            Au = au;
            NameTeacher = nameTeacher;

        }
        public int Number { get; set; }
        public string Lesson { get; set; }
        public string Au { get; set; }
        public string NameTeacher { get; set; }

        public override string ToString()
        {
            return Number + " " + "-" + " " + Lesson + " " + $"[{Au}]" + " " + $"({NameTeacher})";
        }
    }
  
    public partial class Window1 : Window
    {
        public readonly TimetableRow timetableRow;
       public Window1()
        {
          
            InitializeComponent();

        }
        private void AuditoryCB(object sender, RoutedEventArgs e)
        {
            if (tAuditory.Text.Trim().Length <= 10)
            {
                bAuditory.IsEnabled = true;
            }
            else { bAuditory.IsEnabled = false; }
            
        }
        private void TecherCB(object sender, RoutedEventArgs e)
        {
            if (tTeacher.Text.Trim().Length <= 10)
            {
                bTeacher.IsEnabled = true;
            }
            else {  tTeacher.IsEnabled = false; }
        }
        private void LessonCB(object sender, RoutedEventArgs e)
        {
            if (tLesson.Text.Trim().Length <= 10)
            {
                bLesson.IsEnabled = true;
            }
            else { bLesson.IsEnabled = false; }
        }
        private void Add_CBAuditory(object sender, RoutedEventArgs e)
        {
            cbAuditory.Items.Add(tAuditory.Text.Trim());
            tAuditory.Clear();
            bAuditory.IsEnabled = false;
        }
        private void Add_CBLesson(object sender, RoutedEventArgs e)
        {
            cbLesson.Items.Add(tLesson.Text.Trim());
            tLesson.Clear();
            bLesson.IsEnabled = false;
        }
        private void Add_CBTeacher(object sender, RoutedEventArgs e)
        {
           
            cbTeacher.Items.Add(tTeacher.Text.Trim());
            tTeacher.Clear(); 
            bTeacher.IsEnabled = false;
          

        }

        public void onChange(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox == null)
            {
                bRemove.IsEnabled = false;
                return;
            }

            var selected = listBox.SelectedItem as TimetableRow;
            if (selected == null)
            {
                bRemove.IsEnabled = false;
                return;
            }

            bRemove.IsEnabled = true;
        }
        public void onRemove(object sender, RoutedEventArgs e)
        {
            if (window.SelectedItem == null)
            {
              
                return;
            }
            else
            {
                bRemove.IsEnabled = true;
            }

            
                for (int i = window.SelectedIndex ; i < window.Items.Count; i++)
                {
                    TimetableRow row = (TimetableRow)window.Items[i];
                    row.Number = i;

                }
 
            window.Items.Remove(window.SelectedItem);
            window.Items.Refresh();
        }

        public void onCreate(object sender, RoutedEventArgs e)
        {
            string au = cbAuditory.Text.Trim();
            string teacher =cbTeacher.Text.Trim();  
            string lesson = cbLesson.Text.Trim();
            int number = window.Items.Count + 1;
        
            window.Items.Add(new TimetableRow(number,lesson,au,teacher));
            cbTeacher.SelectedIndex = -1;
            cbAuditory.SelectedIndex = -1;
            cbLesson.SelectedIndex = -1;
        }
    
   
    }
}
