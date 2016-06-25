namespace TaskBankAccounts.Models.Customer
{
    using AbstractModels;

    public class Individual : Customer
    {
        public Individual(int clientId, string name)
            : base(clientId, name)
        {
        }
    }
}
