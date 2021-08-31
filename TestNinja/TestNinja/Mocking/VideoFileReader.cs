using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoFileReader
    {
        string readFile(string path);
    }

    public class VideoFileReader : IVideoFileReader
    {
        public string readFile(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
