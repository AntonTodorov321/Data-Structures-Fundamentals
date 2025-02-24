namespace Exam.ViTube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ViTubeRepository : IViTubeRepository
    {
        private List<User> users;
        private List<Video> videos;

        public ViTubeRepository()
        {
            this.users = new List<User>();
            this.videos = new List<Video>();
        }

        public bool Contains(User user)
        {
            return this.users.Contains(user);
        }

        public bool Contains(Video video)
        {
            return this.videos.Contains(video);
        }

        public void DislikeVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Dislikes++;
            user.DislikedVideos++;
        }

        public IEnumerable<User> GetPassiveUsers()
        {
            return this.users.Where(
                u => u.WatchedVideos == 0 && u.LikedVideos == 0 && u.DislikedVideos == 0);
        }

        public IEnumerable<User> GetUsersByActivityThenByName()
        {
            return this.users.OrderByDescending(u => u.WatchedVideos)
                             .ThenByDescending(u => u.LikedVideos)
                             .ThenByDescending(u => u.DislikedVideos)
                             .ThenBy(u => u.Username);
        }

        public IEnumerable<Video> GetVideos()
        {
            return this.videos;
        }

        public IEnumerable<Video> GetVideosOrderedByViewsThenByLikesThenByDislikes()
        {
            return this.videos.OrderByDescending(v => v.Views)
                              .ThenByDescending(v => v.Likes)
                              .ThenBy(v => v.Dislikes);
        }

        public void LikeVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Likes++;
            user.LikedVideos++;
        }

        public void PostVideo(Video video)
        {
            this.videos.Add(video);
        }

        public void RegisterUser(User user)
        {
            this.users.Add(user);
        }

        public void WatchVideo(User user, Video video)
        {
            if (!this.users.Contains(user) || !this.videos.Contains(video))
            {
                throw new ArgumentException();
            }

            video.Views++;
            user.WatchedVideos++;
        }
    }
}
