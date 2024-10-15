using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class FileRead
    {
        public static async Task<List<string>> LoadTextFileAsync(string path, IProgress<ProgressReporter> progress)
        {
            List<string> list = new List<string>();
            string[] lines = await File.ReadAllLinesAsync(path);

            for (int i = 0; i < lines.Length; i++)
            {
                list.Add(lines[i]);

                // Create a new ProgressReporter for each update to ensure changes
                var reporter = new ProgressReporter
                {
                    PercentageComplete = ((i + 1) * 100) / lines.Length
                };

                // Report the progress
                progress.Report(reporter);

            }

            return list;
        }

    }
}