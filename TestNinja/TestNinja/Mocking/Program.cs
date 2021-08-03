using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public class Program
    {
        public static void Main()
        {
            VideoService service = new VideoService();

            //primera forma
            //string title = service.ReadVideoTitle(new FileReader());

            //segunda forma
            string title = service.ReadVideoTitle();
        }

    }
}
