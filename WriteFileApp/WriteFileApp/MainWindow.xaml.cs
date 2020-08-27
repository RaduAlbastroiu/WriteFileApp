using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MessageBox = System.Windows.MessageBox;

namespace WriteFileApp
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    private FolderBrowserDialog folderBrowserDialog1;
    private OpenFileDialog openFileDialog1;

    private string openFileName, folderName;

    public MainWindow()
    {
      InitializeComponent();
    
      this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
      this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
    }

    private void ChooseFolder(object sender, RoutedEventArgs e)
    {
      DialogResult result = folderBrowserDialog1.ShowDialog();
      
      folderName = folderBrowserDialog1.SelectedPath;
      label.Content = folderName;
    }

    private void CreateFile(object sender, RoutedEventArgs e)
    {
      var saveThisToFile = "This is some sample text to save";
      var fileName = "MyOutput.txt";

      var path = folderName != null ? folderName + "/" + fileName : fileName;
      try
      {
        using (System.IO.StreamWriter sw = System.IO.File.CreateText(path))
        {
          sw.Write(saveThisToFile);
          label1.Content = "File Written";
        }
      }
      catch { }
      
    }
  }
}
