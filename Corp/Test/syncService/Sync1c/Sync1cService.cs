using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Test.syncService.Sync1c
{
    internal class Sync1cService
    {
        public async void Test(string xml)
        {
            try
            {

                BasicHttpBinding binding = new BasicHttpBinding();
                binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;

                using (ServiceReference1.SuperWSPortTypeClient client = new ServiceReference1.SuperWSPortTypeClient(binding,
                     new EndpointAddress("http://1c-cluster.steklodom.local/steklodom/ws/SuperWS.1cws")))
                {
                    client.ClientCredentials.UserName.UserName = "WSclient";
                    client.ClientCredentials.UserName.Password = "masterkey";

                    client.Open();

                    ServiceReference1.djinnResponse ss = await client.djinnAsync($"Get_sales_amount", xml);

                    Console.Write(ss.ToString());
                    //string res = client.djinnAsync($"create_zayvka_k3;K3;{username}", path); 

                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка в отправке: " + e);
            }
        }
    }
}
