using System;

namespace LegacyApp
{
    public class User
    {
        public bool HasCreditLimit;
        public int CreditLimit;
        public object Client { get; internal set; }
        public DateTime DateOfBirth { get; internal set; }
        public string EmailAddress { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
    }

    public partial class ClientService
    {
        public void SetCreditLimit(User user, int creditLimit)
        {
            user.HasCreditLimit = true;
            user.CreditLimit = creditLimit;
        }

        public void RemoveCreditLimit(User user)
        {
            user.HasCreditLimit = false;
            user.CreditLimit = 0;
        }
    }
}