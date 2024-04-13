using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class UserCreditService : IDisposable
    {
        /// <summary>
        /// Simulating database
        /// </summary>
        private readonly Dictionary<string, int> _database =
            new Dictionary<string, int>()
            {
                {"Kowalski", 200},
                {"Malewski", 20000},
                {"Smith", 10000},
                {"Doe", 3000},
                {"Kwiatkowski", 1000}
            };
        
        public void Dispose()
        {
            //Simulating disposing of resources
        }

        /// <summary>
        /// This method is simulating contact with remote service which is used to get info about someone's credit limit
        /// </summary>
        /// <returns>Client's credit limit</returns>
        internal int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            int randomWaitingTime = new Random().Next(3000);
            Thread.Sleep(randomWaitingTime);

            if (_database.ContainsKey(lastName))
                return _database[lastName];

            throw new ArgumentException($"Client {lastName} does not exist");
        }
    }
    public class CreditLimitProvider
    {
        private readonly Dictionary<string, int> _cache;
        private readonly UserCreditService _userCreditService;

        public CreditLimitProvider(UserCreditService userCreditService)
        {
            _userCreditService = userCreditService;
            _cache = new Dictionary<string, int>();
        }

        public int GetCreditLimit(string lastName, DateTime dateOfBirth)
        {
            var key = $"{lastName}-{dateOfBirth.ToShortDateString()}";

            if (_cache.ContainsKey(key))
                return _cache[key];

            var creditLimit = _userCreditService.GetCreditLimit(lastName, dateOfBirth);
            _cache.Add(key, creditLimit);
            return creditLimit;
        }
    }
}