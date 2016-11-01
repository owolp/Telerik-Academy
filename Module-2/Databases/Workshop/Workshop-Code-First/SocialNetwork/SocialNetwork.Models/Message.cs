namespace SocialNetwork.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Message
    {
        [Key]
        public int Id { get; set; }

        public User Author { get; set; }

        [Required]
        public string Content { get; set; }

        [Index]
        public DateTime SentOn { get; set; }

        public DateTime? SeenOn { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int FriendshipId { get; set; }

        public virtual Friendship Friendship { get; set; }
    }
}