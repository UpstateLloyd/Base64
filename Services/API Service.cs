using CsvHelper;
using B64.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace B64
{
    class APIService
    {
        //returns bearer token for prod environment
        public string getToken()
        {
            ////Reuse of this value will be necessary among all your calls
            ////Use this method first because none of the other calls can work without your access token

            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/auth/wts/token");
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8571/wts/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "UpstateDoor");
            request.AddParameter("client_secret", "UpstateDoorSecret");
            IRestResponse response = client.Execute(request);
            Dictionary<string, string> dictResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            string auth_token = "Bearer" + " " + dictResponse["access_token"];
            return auth_token;
        }

        // return bearer token for test environment
        public string getTestToken()
        {
            var client = new RestClient("https://upstatedoor-webcp-test.wtsparadigm.com/upstatedoor-test/api/auth/wts/token");
            //var client = new RestClient("https://webcp-services-dev.wtsparadigm.com:8791/wts/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "client_credentials");
            request.AddParameter("client_id", "UpstateTest");
            request.AddParameter("client_secret", "up94riwTest");
            IRestResponse response = client.Execute(request);
            Dictionary<string, string> dictResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
            string auth_token = "Bearer" + " " + dictResponse["access_token"];
            return auth_token;
        }
        //used to list client details in console
        public Dictionary<string,string> ListClientByID(string auth_token, string intID)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clients?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/clients?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            List<Root> DeserializedClient = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return PrettyListOfClient(DeserializedClient, 0);
        }

        //used to return deserialized production client
        public Root GetClientByID(string auth_token, string intID)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clients?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/clients?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            List<Root> DeserializedClient = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            if (DeserializedClient.Count > 0)
            {
                return DeserializedClient[0];
            }
            else
            {
                return null;
            }
        }

        //used to return deserialized test client
        public Root GetTestClientByID(string auth_token, string intID)
        {
            var client = new RestClient("https://upstatedoor-webcp-test.wtsparadigm.com/upstatedoor-test/api/mdi/wts/v1/clients?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services-dev.wtsparadigm.com:8793/wts/v1/clients?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            List<Root> DeserializedClient = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            if (DeserializedClient.Count > 0)
            {
                return DeserializedClient[0];
            }
            else
            {
                return null;
            }
        }

        //Put production client using integrationID
        public void PutClientByID(string auth_token, string intID, string jsonstring)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/client?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/client?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", auth_token);
            request.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        //Post production client using integrationID
        public void PostClientByID(string auth_token, string intID, string jsonstring)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/client?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/client?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", auth_token);
            request.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }

        //Put test client using integration id 
        public void PutTestClientByID(string auth_token, string intID, string jsonstring)
        {
            var client = new RestClient("https://upstatedoor-webcp-test.wtsparadigm.com/upstatedoor-test/api/mdi/wts/v1/client?integrationId=" + intID);
            //var client = new RestClient("https://webcp-services-dev.wtsparadigm.com:8793/wts/v1/client?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", auth_token);
            request.AddParameter("application/json", jsonstring, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
        }

        //api is capped at 25 responses this function needs to be modified to submit multiple requests in order to actually get all clients
        // make incremental requests to Getclientbypage and stop when reply has less than 25
        public void GetAllClients(string auth_token)
        {
            List<Root> fullList = new List<Root>();
            List<Root> response = new List<Root>();
            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetClientByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 25)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            string user = Environment.UserName;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\Export.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fullList);
            }
        }

        public List<Root> ReturnAllClients(string auth_token)
        {
            List<Root> fullList = new List<Root>();
            List<Root> response = new List<Root>();
            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetClientByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 25)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            return fullList;
        }

        public List<Root> GetClientByPage(string auth_token, string page_number)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clients?page=" + page_number);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/clients?page=" + page_number);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<Root> myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(response.Content);
            return myDeserializedClass;
        }

        public void GetAllShipAddresses(string auth_token)
        {
            List<Roots> fullList = new List<Roots>();
            List<Roots> response = new List<Roots>();
            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetShipAddressesByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 20)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            string user = Environment.UserName;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\ShipAddresses.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fullList);
            }
        }

        public List<Roots> GetShipAddressesByPage(string auth_token, string page_number)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clientsshipaddresses?page=" + page_number);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/clientsshipaddresses?page=" + page_number);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<Roots> myDeserializedClass = JsonConvert.DeserializeObject<List<Roots>>(response.Content);
            return myDeserializedClass;
        }

        public void GetAllUsers(string auth_token)
        {
            List<Users.Users> fullList = new List<Users.Users>();
            List<Users.Users> response = new List<Users.Users>();
            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetUsersByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 20)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\Export.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fullList);
            }
        }

        public List<Users.Users> GetUsersByPage(string auth_token, string page_number)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/users?page=" + page_number);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/users?page=" + page_number);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<Users.Users> myDeserializedClass = JsonConvert.DeserializeObject<List<Users.Users>>(response.Content);
            return myDeserializedClass;
        }

        public List<ClientsTaxCodes> GetClientsTaxCodes(string auth_token)
        {
            List<ClientsTaxCodes> fullList = new List<ClientsTaxCodes>();
            List<ClientsTaxCodes> response = new List<ClientsTaxCodes>();

            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetClientsTaxCodesByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 20)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\Export.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fullList);
            }
            return fullList;
        }

        public List<DefaultSalesRepstring> GetSalesReps(string auth_token)
        {
            List<DefaultSalesRepstring> fullList = new List<DefaultSalesRepstring>();
            List<DefaultSalesRepstring> response = new List<DefaultSalesRepstring>();

            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetSalesRepsByPage(auth_token, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 20)
                {
                    lastPage = true;
                }
                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\SalesReps.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(fullList);
            }
            return fullList;
        }

        public List<ClientsTaxCodes> GetClientsTaxCodesByPage(string auth_token, string page_number)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clientstaxcodes?page=" + page_number);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/clientstaxcodes?page=" + page_number);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<ClientsTaxCodes> myDeserializedClass = JsonConvert.DeserializeObject<List<ClientsTaxCodes>>(response.Content);
            return myDeserializedClass;
        }
        public List<DefaultSalesRepstring> GetSalesRepsByPage(string auth_token, string page_number)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/salesreps?Page=" + page_number);
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/salesreps?Page=" + page_number);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<DefaultSalesRepstring> myDeserializedClass = JsonConvert.DeserializeObject<List<DefaultSalesRepstring>>(response.Content);
            return myDeserializedClass;
        }
        public void GetPayTerms(string auth_token)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/payterms");
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/payterms");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            List<PayTerms> myDeserializedClass = JsonConvert.DeserializeObject<List<PayTerms>>(response.Content);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var writer = new StreamWriter(path + "\\Export.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(myDeserializedClass);
            }
        }
        public Dictionary<string, string> PrettyListOfClient(List<Root> DeserializedClient, int index)
        {
            Dictionary<string, string> ReturnDictionary = new Dictionary<string, string>();
            Type RootType = typeof(Root);
            Type vendorType = typeof(Vendor);
            Type ClientTaxCodeType = typeof(ClientTaxCode);
            Type DefaultShipAddressType = typeof(DefaultShipAddresses);
            Type DefaultSalesRepstringType = typeof(DefaultSalesRepstring);
            PropertyInfo[] RootProperties = RootType.GetProperties();
            PropertyInfo[] ClientTaxCodeProperties = ClientTaxCodeType.GetProperties();
            PropertyInfo[] VendorProperties = vendorType.GetProperties();
            PropertyInfo[] DefaultShipAddressProperties = DefaultShipAddressType.GetProperties();
            PropertyInfo[] DefaultSalesRepstringProperties = DefaultSalesRepstringType.GetProperties();

            foreach (PropertyInfo property in RootProperties)
            {
                if (!(property.Name == "ClientTaxCode" || property.Name == "DefaultShipAddress" || property.Name == "Vendor" || property.Name == "DefaultSalesRepstring"))
                {
                    if (!(property.GetValue(DeserializedClient[index]) is null) && !(ReturnDictionary.ContainsKey(property.Name)))
                    {

                        ReturnDictionary.Add(property.Name, property.GetValue(DeserializedClient[index]).ToString());
                        //Console.WriteLine("{0}:{1}", property.Name, property.GetValue(DeserializedClient[index]));
                    }
                    else
                    {
                        //Console.WriteLine("{0}:Null", property.Name);
                    }
                }
                else if (property.Name == "ClientTaxCode")
                {
                    foreach (var ClientTaxCodeProperty in ClientTaxCodeProperties)
                    {
                        if (!(DeserializedClient[index].ClientTaxCode is null))
                        {
                            if (!(ClientTaxCodeProperty.GetValue(DeserializedClient[index].ClientTaxCode) is null))
                            {
                                ReturnDictionary.Add(ClientTaxCodeProperty.Name, ClientTaxCodeProperty.GetValue(DeserializedClient[index].ClientTaxCode).ToString());
                                //Console.WriteLine("{0}:{1}", ClientTaxCodeProperty.Name, ClientTaxCodeProperty.GetValue(DeserializedClient[index].ClientTaxCode));
                            }
                        }
                    }
                }
                else if (property.Name == "DefaultShipAddress")
                {
                    foreach (var DefaultShipAddressProperty in DefaultShipAddressProperties)
                    {
                        if (!(DeserializedClient[index].DefaultShipAddress is null))
                        {
                            if (!(DefaultShipAddressProperty.GetValue(DeserializedClient[index].DefaultShipAddress) is null))
                            {

                                if (!(ReturnDictionary.ContainsKey(DefaultShipAddressProperty.Name)))
                                {
                                    ReturnDictionary.Add(DefaultShipAddressProperty.Name, DefaultShipAddressProperty.GetValue(DeserializedClient[index].DefaultShipAddress).ToString());
                                    //Console.WriteLine("{0}:{1}", DefaultShipAddressProperty.Name, DefaultShipAddressProperty.GetValue(DeserializedClient[index].DefaultShipAddress));
                                }
                            }
                        }
                    }
                }
                else if (property.Name == "Vendor")
                {
                    foreach (var VendorProperty in VendorProperties)
                    {
                        if (!(DeserializedClient[index].Vendor is null))
                        {
                            if (!(VendorProperty.GetValue(DeserializedClient[index].Vendor) is null))
                            {
                                ReturnDictionary.Add(VendorProperty.Name, VendorProperty.GetValue(DeserializedClient[index].Vendor).ToString());
                                //Console.WriteLine("{0}:{1}", VendorProperty.Name, VendorProperty.GetValue(DeserializedClient[index].Vendor));
                            }
                        }
                    }
                }
                else if (property.Name == "DefaultSalesRepstring")
                {
                    foreach (var DefaultSalesRepstringProperty in DefaultSalesRepstringProperties)
                    {
                        if (!(DeserializedClient[index].DefaultSalesRepstring is null))
                        {
                            if (!(DefaultSalesRepstringProperty.GetValue(DeserializedClient[index].DefaultSalesRepstring) is null))
                            {
                                ReturnDictionary.Add(DefaultSalesRepstringProperty.Name, DefaultSalesRepstringProperty.GetValue(DeserializedClient[index].DefaultSalesRepstring).ToString());
                                //Console.WriteLine("{0}:{1}", DefaultSalesRepstringProperty.Name, DefaultSalesRepstringProperty.GetValue(DeserializedClient[index].DefaultSalesRepstring));
                            }
                        }
                    }
                }
            }
            //Console.WriteLine("Press enter to continue");
            //Console.ReadLine();
            return ReturnDictionary;
        }

        public List<Root> GetAllClientsSecond(string AuthToken)
        {
            List<Root> fullList = new List<Root>();
            List<Root> response = new List<Root>();
            bool lastPage = false;
            var pageNumber = 0;

            while (!lastPage)
            {
                response = GetClientByPage(AuthToken, Convert.ToString(pageNumber));
                pageNumber += 1;
                if (response.Count < 20)
                {
                    lastPage = true;
                }

                foreach (var client in response)
                {
                    fullList.Add(client);
                }
            }
            return fullList;
        }

        //// Build a list of existing integration ID's
        public List<string> GetExistingIntegrationIDs(string AuthToken)
        {
            var AllClients = GetAllClientsSecond(AuthToken);
            List<string> ExistingIDs = new List<string>();
            foreach (var item in AllClients)
            {
                if (!(string.IsNullOrEmpty(item.IntegrationID)))
                {
                    ExistingIDs.Add(item.IntegrationID);
                }
            }
            return ExistingIDs;
        }

        public string CleanString(string word)
        {
            Regex Reg = new Regex("[^a-zA-Z']");
            return Reg.Replace(word, string.Empty).ToUpper();
        }

        // Format Unique Integration ID 
        public string FormatIntegrationID(string AuthToken, string CustomerName)
        {
            // First three letters of Customer Name with 3 digit
            StringBuilder CustomerInitials = new StringBuilder();
            StringBuilder BuildIntegrationID = new StringBuilder();
            StringBuilder IDValue = new StringBuilder();
            IDValue.Append("001");

            string trimmed = CleanString(CustomerName);

            if (!(String.IsNullOrEmpty(trimmed)))
            {
                CustomerInitials.Append(trimmed.Substring(0, 3));
                BuildIntegrationID.Append(CustomerInitials.ToString());
                BuildIntegrationID.Append(IDValue.ToString());
            };

            List<String> ExistingIntegrationIDs = GetExistingIntegrationIDs(AuthToken);

            while (ExistingIntegrationIDs.Contains(BuildIntegrationID.ToString()))
            {
                int IDFloatValue = int.Parse(IDValue.ToString());
                IDFloatValue += 1;
                if (IDFloatValue > 9)
                {
                    IDValue.Clear();
                    IDValue.Append("0");
                    IDValue.Append(IDFloatValue.ToString());
                }
                else
                {
                    IDValue.Clear();
                    IDValue.Append("00");
                    IDValue.Append(IDFloatValue.ToString());
                }
                BuildIntegrationID.Clear();
                BuildIntegrationID.Append(CustomerInitials.ToString());
                BuildIntegrationID.Append(IDValue.ToString());
            }
            return BuildIntegrationID.ToString();

        }        
        public Quotes GetQuotes()
        {
            Quotes quotes = new Quotes();
            //var options = new RestClientOptions("https://upstatedoor.wtsparadigm.com")
            //{
            //    MaxTimeout = -1,
            //};
            //var client = new RestClient(options);
            //var request = new RestRequest("/upstatedoor-prod/api/app/webcp/v1/quotes?$count=true", Method.Get);
            string auth_token;
            auth_token = "Bearer _0DEPoJaXoS7iaV4NtJw4iezyJddLf93HOxKq2kNLAveIIuTmYVsDfYmIbR0t9pmA2h4bUsn7B_0_oK22bE3XVdgUKFTdllH8r5vaCDopKu8NQb5m6Fjsp0j9P_V9ap5TDMfk28oG7se7y1XUzSkzFy5lJrQIc7kW1hZQI667r-mNMg8UzrD8CHVoD_HVacnRoQ7yxIMCTWw6SfNFp66K0eHCtixaHgHyr0PncSylNcjfP4-PrZwvxGeIyCvZYv2lEGiP2oTlTnDsWjZ86C9FW5w9sp5JZnF22yP0WhsdmhjNlRAD2EKWnFhpmgFOW7N4zGq70fqo8eW9Tm44tvSjzLyHCMpIZvHDocUPMaLLVCQD0zD-HLX44g3hPw6fcEtLbAdXOSPY-QeJgg1_ndpvPkT3tPhDJ3XydjrorhV3KGlSQTXp0nr34GkH4puFhDcD7l9I1vAWZifT5it4dNs25EPybgoIWUazqIJDnovcDl4ASUaWxIXfso1T9KR4PhFuDOFS5aeox4esp1xlIVoBA";
            var base64EncodedPassword = Base64Encode(auth_token);
            //RestResponse response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/app/webcp/v1/quotes?");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", base64EncodedPassword);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AlwaysMultipartFormData = true;
            IRestResponse response = client.Execute(request);
            List<Quotes> DeserializedClient = JsonConvert.DeserializeObject<List<Quotes>>(response.Content);
            return DeserializedClient[0];
        }
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public ClientsToSalesReps GetClientToSalesReps(string auth_token, string clientID, string salesRepID)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi//wts/v1/clienttosalesrep?clientid=" + clientID + "&salesrepid=" + salesRepID);
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", auth_token);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");
            IRestResponse response = client.Execute(request);
            ClientsToSalesReps myDeserializedClass = JsonConvert.DeserializeObject<ClientsToSalesReps>(response.Content);
            return myDeserializedClass;
        }

        //Put ClientToSalesRep
        public void PutClientToSalesRep(string auth_token, string jsonString)
        {
            var client = new RestClient("https://upstatedoor.wtsparadigm.com/upstatedoor-prod/api/mdi/wts/v1/clienttosalesrep");
            //var client = new RestClient("https://webcp-services.wtsparadigm.com:8573/wts/v1/client?integrationId=" + intID);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", auth_token);
            request.AddParameter("application/json", jsonString, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            //Console.WriteLine(response.Content);
        }
    }
}