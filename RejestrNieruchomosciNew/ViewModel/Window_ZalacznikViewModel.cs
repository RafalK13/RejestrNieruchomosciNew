using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using RejestrNieruchomosciNew.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace RejestrNieruchomosciNew.ViewModel
{
    public class Window_ZalacznikViewModel : ViewModelBase,  IWindow_ZalacznikViewModel
    {
        public string pathFiles { get; set; }
        public string fileSel { get; set; }

        public List<string> filesList { get; set; }

        public ICommand doubleClick { get; set; }

        public Window_ZalacznikViewModel()
        { }
        public Window_ZalacznikViewModel( string _pathFiles)
        {
            doubleClick = new RelayCommand( onDoubleClick);

            pathFiles = _pathFiles;
            filesList = new List<string>(Directory.GetFiles(pathFiles ).ToList()
                                        .Where(a => File.GetAttributes(a) == FileAttributes.Archive));

        }

        private void onDoubleClick()
        {
            try
            {
                Process.Start(fileSel);
            }
            catch
            {
                MessageBox.Show( "Problem z siecią");
            }
        }
    }
}
