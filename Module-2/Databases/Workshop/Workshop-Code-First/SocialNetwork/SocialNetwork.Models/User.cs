namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        private ICollection<Post> posts;
        private ICollection<Message> messages;
        private ICollection<Image> images;

        public User()
        {
            this.posts = new HashSet<Post>();
            this.messages = new HashSet<Message>();
            this.images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        [MinLength(2)]
        public string LastName { get; set; }

        public DateTime RegisteredOn { get; set; }

        public ICollection<Post> Posts
        {
            get { return this.posts; }

            set { this.posts = value; }
        }

        public ICollection<Message> Messages
        {
            get { return this.messages; }

            set { this.messages = value; }
        }

        public ICollection<Image> Images
        {
            get { return this.images; }

            set { this.images = value; }
        }
    }
}
