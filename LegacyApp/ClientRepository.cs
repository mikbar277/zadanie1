﻿using System;
using System.Collections.Generic;
using System.Threading;

namespace LegacyApp
{
    public class ClientRepository
    {
        private readonly Dictionary<int, Client> _database;

        public ClientRepository()
        {
            // Simulating fetching data from a remote database
            _database = new Dictionary<int, Client>()
            {
                {1, new Client{ClientId = 1, Name = "Kowalski", Address = "Warszawa, Złota 12", Email = "kowalski@wp.pl", Type = "NormalClient"}},
                {2, new Client{ClientId = 2, Name = "Malewski", Address = "Warszawa, Koszykowa 86", Email = "malewski@gmail.pl", Type = "VeryImportantClient"}},
                {3, new Client{ClientId = 3, Name = "Smith", Address = "Warszawa, Kolorowa 22", Email = "smith@gmail.pl", Type = "ImportantClient"}},
                {4, new Client{ClientId = 4, Name = "Doe", Address = "Warszawa, Koszykowa 32", Email = "doe@gmail.pl", Type = "ImportantClient"}},
                {5, new Client{ClientId = 5, Name = "Kwiatkowski", Address = "Warszawa, Złota 52", Email = "kwiatkowski@wp.pl", Type = "NormalClient"}},
                {6, new Client{ClientId = 6, Name = "Andrzejewicz", Address = "Warszawa, Koszykowa 52", Email = "andrzejewicz@wp.pl", Type = "NormalClient"}}
            };
        }

        public Client GetById(int clientId)
        {
            int randomWaitTime = new Random().Next(2000);
            Thread.Sleep(randomWaitTime);

            if (_database.ContainsKey(clientId))
                return _database[clientId];

            throw new ArgumentException($"User with id {clientId} does not exist in database");
        }
    }

    public class ClientCache
    {
        private readonly Dictionary<int, Client> _cache;
        private readonly ClientRepository _repository;

        public ClientCache(ClientRepository repository)
        {
            _repository = repository;
            _cache = new Dictionary<int, Client>();
        }

        public Client GetById(int clientId)
        {
            if (_cache.ContainsKey(clientId))
                return _cache[clientId];

            var client = _repository.GetById(clientId);
            _cache.Add(clientId, client);
            return client;
        }
    }
}
