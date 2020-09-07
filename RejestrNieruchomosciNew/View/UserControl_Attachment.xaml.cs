using RejestrNieruchomosciNew.Model;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace RejestrNieruchomosciNew.View
{
    public partial class UserControl_Attachment : UserControl
    {
        public CopyFiles copyFiles;

        public UserControl_Attachment()
        {
            InitializeComponent();
            copyFiles = new CopyFiles();
        }

        public string pathRaf
        {
            get { return (string)GetValue(pathRafProperty); }
            set { SetValue(pathRafProperty, value); }
        }

        public static readonly DependencyProperty pathRafProperty =
            DependencyProperty.Register("pathRaf", typeof(string), typeof(UserControl_Attachment));
        
        private void Button_Add(object sender, RoutedEventArgs e)
        {
            string p = copyFiles.getFilePath();
         
            Directory.CreateDirectory( pathRaf);

            if( p != null)
                File.Copy(p, pathRaf+$"\\{copyFiles.fileName}", true);
        }

        private void Button_Prev(object sender, RoutedEventArgs e)
        {

            if (Directory.Exists(pathRaf) )
            {
                if (Directory.GetFiles(pathRaf).Length > 0)
                    Process.Start(pathRaf);
            }
        }
    }
}
