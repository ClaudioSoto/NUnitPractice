using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IVideoRepository
    {
        List<Video> getVideos();
    }

    public class VideoRepository : IVideoRepository
    {

        public List<Video> getVideos()
        {
            using (var context = new VideoContext())
            {
                var videos =
               (from video in context.Videos
                where !video.IsProcessed
                select video).ToList();

                return videos;
            }

        }
    }
}
