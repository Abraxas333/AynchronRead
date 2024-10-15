using System;
using System.Windows.Forms;
namespace ConsoleApp4
{
    internal class FileOpen
    {

        public static string OpenDialog()
        {
            string filePath = string.Empty;

           
            Thread t = new Thread(() =>
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        filePath = openFileDialog.FileName;
                    }
                }
            });

            
            t.SetApartmentState(ApartmentState.STA);

            
            t.Start();
            t.Join();

            return filePath;
        }
    }
}