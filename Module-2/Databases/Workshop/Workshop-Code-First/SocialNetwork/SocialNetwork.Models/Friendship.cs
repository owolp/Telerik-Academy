namespace SocialNetwork.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Friendship
    {
        private ICollection<Message> messages;

        public Friendship()
        {
            this.messages = new HashSet<Message>();
        }

        [Key]
        public int Id { get; set; }

        public int FirstUsedId { get; set; }

        public virtual User FirstUser { get; set; }

        public int SecondUsedId { get; set; }

        public virtual User SecondUser { get; set; }

        [Index]
        public bool Approved { get; set; }

        public DateTime? FriendsSince { get; set; }

        public virtual ICollection<Message> Messages
        {
            get { return this.messages; }

            set { this.messages = value; }
        }
    }
}