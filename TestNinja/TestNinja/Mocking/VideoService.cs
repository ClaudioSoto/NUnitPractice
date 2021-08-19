﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace TestNinja.Mocking
{
    public class VideoService
    {

        //INJECTION VIA METHOD
        public string ReadVideoTitle(IFileReader fileReader)
        {
            //var str = File.ReadAllText("video.txt");

            //first way
            var str = fileReader.Read("video.txt");

            var video = JsonConvert.DeserializeObject<Video>(str);
            if (video == null)
                return "Error parsing the video.";
            return video.Title;
        }

        public string GetUnprocessedVideosAsCsv(IVideoRepository videoRepository)
        {
            var videoIds = new List<int>();

            /* 
                 * THIS GOES TO VIDEO REPOSITORY FILE BECAUSE IS AN EXTERNAL RESOURCE
            using (var context = new VideoContext())
            {
                
                var videos = 
                    (from video in context.Videos
                    where !video.IsProcessed
                    select video).ToList();
            */

            //REFACTOR AND CALL THE METHOD GetUnprocessedVideos AND 
            //STORE INSIDE A VARIABLE videos TO MANTAIN THE FUNCTIONALITY

            //var videos = new VideoRepository().GetUnprocessedVideos();

            //BUT WITH THE METHOD INJECTION IS NOT NECESARRY TO CREATE NEW VIDEO REPOSITORY
            //INSTANCE, SO YO USE THE INTERFACE OBJECT

            var videos = videoRepository.GetUnprocessedVideos();

            foreach (var v in videos)
                    videoIds.Add(v.Id);

                return String.Join(",", videoIds);
            //}
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