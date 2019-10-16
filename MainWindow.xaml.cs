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
            foreach (var s in Service.Levels) AddRadioButtonToStackPanel(stpSchulstufe, $"{s}");
        }

        private void initSubjectStackPanel()
        {
            foreach (string sub in Service.Subjects) AddRadioButtonToStackPanel(stpGegenstand, sub);
        }

        private void initButtonBackgrounds()
        {
            btn4a.Background = Brushes.Gray;
            btn4b.Background = Brushes.Gray;
        }

        private void SetStudentImage(Student student)
        {
            imgStudent.Source = new BitmapImage(new Uri(student.ImagePath, UriKind.Relative));
        }

        private void AddRadioButtonToStackPanel(StackPanel sp, string radioButtonName)
        {
            var rdb = new RadioButton
            {
                Content = radioButtonName
            };

            sp.Children.Add(rdb);
            rdb.Checked += Rdb_Checked;
        }

        private void Rdb_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void Btn4a_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btn4b_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnOpen_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CbxStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
