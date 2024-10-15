using ConsoleApp4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Program
    {
       
        [STAThreadAttribute] static async Task Main(string[] args)
        {
            

            string path = FileOpen.OpenDialog();
            var progress = new Progress<ProgressReporter>(reporter =>
            {   
                Console.WriteLine($"Progress: {reporter.PercentageComplete}%");
                
            });


            if (!string.IsNullOrEmpty(path))
            {
                List<string> lines = await FileRead.LoadTextFileAsync(path, progress);

                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            else
            {
                Console.WriteLine("No file selected.");
            }




        }
    }
}
