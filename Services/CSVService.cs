using System;
using System.Collections.Generic;
using System.Text;
using B64.Models;
using CsvHelper;
using System.IO;
using System.Globalization;
using CsvHelper.Configuration;

namespace B64.Services
{
    class CSVService
    {
        public List<ShipRates> GetShipRates()
        {
            List<ShipRates> _shipRates = new List<ShipRates>();

            using (var reader = new StreamReader("C:\\Users\\" + Environment.UserName + "\\Desktop\\Imports.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ShipRates>();
                foreach (var item in records)
                {
                    _shipRates.Add(item);
                }
            }

            return _shipRates;
        }
   
        public List<PlainClient> GetClients()
        {
            List<PlainClient> _clients = new List<PlainClient>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null
            };    
            using (var reader = new StreamReader("C:\\Users\\" + Environment.UserName + "\\Desktop\\Imports.csv"))
            using (var csv = new CsvReader(reader, config))
            {                
                var records = csv.GetRecords<PlainClient>();
                foreach (var item in records)
                {
                    _clients.Add(item);
                }
            }

            return _clients;
        }
    }
}
