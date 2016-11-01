namespace SocialNetwork.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Models;

    public class SocialNetowkrDbContext : DbContext
    {
        public SocialNetowkrDbContext()
            : base("SocialNetwork")
        {
        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Post> Posts { get; set; }
        public IDbSet<Message> Messages { get; set; }
        public IDbSet<Image> Images { get; set; }
        public IDbSet<Friendship> Friendships { get; set; }
    }
}
