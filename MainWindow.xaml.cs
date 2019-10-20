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
using System.IO;

namespace Nachhilfeboerse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private List<Student> students = new List<Student>();
        private Student curretnStudent;
        private int selectedYear = -1;
        private string selectedClazz = "-1";

        public MainWindow() => InitializeComponent();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            loadStudents();
            initButtonBackgrounds();
            initSubjectStackPanel();
            initSchoolyearStackPanel();
            initComboBox();
        }

        private void initComboBox()
        {
            cbxStudents.ItemsSource = students;
        }

        private void loadStudents()
        {
            foreach (var line in File.ReadLines("students.csv"))
            {
                students.Add(Student.Parse(line));
            }
        }

        private void initSchoolyearStackPanel()
        {
            foreach (var i in Service.Levels) AddRadioButtonToStackPanel(stpSchulstufe, $"{i}");
        }

        private void initSubjectStackPanel()
        {
            foreach (var s in Service.Subjects) AddRadioButtonToStackPanel(stpGegenstand, s);
        }

        private void initButtonBackgrounds()
        {
            btn4a.Background = Brushes.Gray;
            btn4b.Background = Brushes.Gray;
        }

        private void SetStudentImage()
        {
            imgStudent.Source = new BitmapImage(new Uri(curretnStudent.ImagePath, UriKind.Relative));
        }

        private void AddRadioButtonToStackPanel(StackPanel sp, string radioButtonName)
        {
            var rdb = new RadioButton
            {
                Content = radioButtonName
            };

            sp.Children.Add(rdb);

            if (sp == stpGegenstand)
            {
                rdb.Checked += Rdb_Checked;
            }
            else
            {
                rdb.Checked += Rdb_Checked2;
            }
        }

        private void Rdb_Checked(object sender, RoutedEventArgs e)
        {
            selectedClazz = (string) ((RadioButton)sender).Content;
        }

        private void Rdb_Checked2(object sender, RoutedEventArgs e)
        {
            selectedYear = int.Parse((string)((RadioButton)sender).Content);
        }

        private void Btn4a_Click(object sender, RoutedEventArgs e)
        {
            FilterComboboxForClass("4a");
        }

        private void Btn4b_Click(object sender, RoutedEventArgs e)
        {
            FilterComboboxForClass("4b");
        }
        private void FilterComboboxForClass(string v)
        {
            var temp = new List<Student>();
            foreach(var student in students) if (student.Clazz.Equals(v)) temp.Add(student);
            cbxStudents.ItemsSource = temp;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var service = new Service
            {
                Level = selectedYear,
                Subject = selectedClazz
            };

            curretnStudent.Services.Add(service);
            SetStudentsNachhilfeen();
            SetLabelText();
        }

        private void SetStudentsNachhilfeen()
        {
            if(lstNames.Items.Count > 0) lstNames.Items.Clear();
            foreach (var service in curretnStudent.Services) lstNames.Items.Add(service); 
            lstNames.Items.Refresh();
        }

        private void CbxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            curretnStudent = (Student) cbxStudents.SelectedItem;


            SetStudentImage();
            SetStudentsNachhilfeen();
            SetLabelText();
        }

        private void SetLabelText()
        {
            lblDisplayNachhilfeschueler.Content = $"{curretnStudent.Services.Count} Nachhilfen:";
        }
    }
}
