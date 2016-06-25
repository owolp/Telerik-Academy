namespace TaskBankAccounts.Models.Bank
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using AbstractModels;

    public class Bank : IEnumerable<Account>
    {
        private List<Account> accounts;

        public Bank()
        {
            this.accounts = new List<Account>();
        }

        public void AddAccount(Account account)
        {
            this.accounts.Add(account);
        }

        public IEnumerator<Account> GetEnumerator()
        {
            for (int i = 0; i < this.accounts.Count; i++)
            {
                yield return this.accounts[i];
            }
        }

        public void RemoveAccount(Account customer)
        {
            this.accounts.Remove(customer);
        }

        public override string ToString()
        {
            this.accounts = this.accounts.OrderBy(a => a.Balance).ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var account in this.accounts)
            {
                sb.AppendLine(account.ToString());
            }

            return sb.ToString();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
