namespace SocialNetwork.ConsoleClient.Searcher
{
    using System;
    using System.Collections;
    using System.Linq;
    using Data;

    public class SocialNetworkService : ISocialNetworkService
    {
        private SocialNetowkrDbContext contex;

        public SocialNetworkService()
        {
            this.contex = new SocialNetowkrDbContext();
        }

        public IEnumerable GetUsersAfterCertainDate(int year)
        {
            return this.contex.Users
                .Where(u => u.RegisteredOn.Year <= year)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.RegisteredOn.Year
                })
                .ToList();

        }

        public IEnumerable GetPostsByUser(string username)
        {
            return this.contex.Posts
                .Where(p => p.TaggedUsers.Any(u => u.Username == username))
                .Select(p => new
                {
                    p.Content,
                    Users = p.TaggedUsers.Select(u => u.Username)
                })
                .ToList();
        }

        public IEnumerable GetFriendships(int page = 1, int pageSize = 25)
        {
            throw new NotImplementedException();
        }

        public IEnumerable GetChatUsers(string username)
        {
            throw new NotImplementedException();
        }
    }
}
