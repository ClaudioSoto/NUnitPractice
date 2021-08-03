using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {
        //la segunda forma de realizar una dependency injection es por propiedades
        //declaramos un objeto de tipo IfileReader y su constructor para usarser
        
        public IFileReader FileReader;

        public VideoService(IFileReader fileReader = null)
        {
            FileReader = fileReader ?? new FileReader();
        }

        /*
//segunda forma, una vez inicializado el objeto ya no se pasan parametros al metodo
public string ReadVideoTitle()
{
   //se utiliza el objeto de la iterfaz que ya tiene su constructor
   var str = fileReader.Read("video.txt");

   var video = JsonConvert.DeserializeObject<Video>(str);
   if (video == null)
       return "Error parsing the video.";
   return video.Title;
}
*/

        /*
        //Primera forma de dependency injection por method parametersse pasa como parametro la interfaz
        public string ReadVideoTitle(IFileReader fileReader)
        {
            //var str = File.ReadAllText("video.txt");

            //se crea una clase falsa para retornar un file vacio o un string
            // la clase se llama FileReader e implementa una interface y esa 
            //iterface es llamada por FakeFileReader que retorna un string vacio para emular un archivo de texto

            //var str = new FileReader().Read("video.txt");

            //se utiliza el objeto de la iterfaz
            var str = fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }
        */

        //LA TERCERA FORMA ES USAR moq FRAMEWORK
        public string ReadVideoTitle()
        {
            var str = FileReader.Read("video.txt");
            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv()
        {
            var videoIds = new List<int>();
            
            using (var context = new VideoContext())
            {
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
                
                foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            }
        }
    }

    public class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsProcessed { get; set; }
    }

    public class VideoContext : DbContext
    {
        public DbSet<Video> Videos { get; set; }
    }
}