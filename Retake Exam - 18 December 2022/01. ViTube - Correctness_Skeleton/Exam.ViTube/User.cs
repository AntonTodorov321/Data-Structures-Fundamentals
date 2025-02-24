namespace Exam.ViTube
{
    public class User
    {
        public User(string id, string username)
        {
            Id = id;
            Username = username;
        }

        public string Id { get; set; }

        public string Username { get; set; }

        public int WatchedVideos { get; set; }

        public int LikedVideos { get; set; }

        public int DislikedVideos { get; set; }
    }
}
