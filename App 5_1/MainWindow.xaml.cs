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
using Microsoft.Win32;
using System.IO;
using System.Windows.Ink;


namespace App_5_1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            inc.EditingMode = InkCanvasEditingMode.Ink;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {                                             
            inc.EditingMode=  InkCanvasEditingMode.EraseByPoint;          
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Inkcanvas Format (*.sandy)|*.sandy|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                var fs = new FileStream(dlg.FileName, FileMode.OpenOrCreate);
                StrokeCollection strokes = new StrokeCollection(fs);
                inc.Strokes = strokes;
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();  
            dlg.Filter = "Inkcanvas Format (*.sandy)|*.sandy|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            { 
            FileStream fs = File.Open(dlg.FileName, FileMode.OpenOrCreate);
                inc.Strokes.Save(fs);
                fs.Close();
            }
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown(); 
        }
    }
}
