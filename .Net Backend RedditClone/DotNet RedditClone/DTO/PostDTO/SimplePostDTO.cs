﻿namespace DotNet_RedditClone.DTO.PostDTO
{
    public class SimplePostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
