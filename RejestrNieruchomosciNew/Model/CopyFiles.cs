using System.Windows.Forms;

namespace RejestrNieruchomosciNew.Model
{
    public class CopyFiles
    {
        public string inPath { get; set; }
        public string outPath { get; set; }
        public string fileName { get; set; }

        public string getFilePath()
        {
            string filePath = string.Empty;
            
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileName = openFileDialog.SafeFileName;
                    
                    return filePath;
                }
            }
            return null;
        }
    }
}
