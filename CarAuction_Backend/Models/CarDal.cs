using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Net;

namespace CarAuction_Backend.Models
{
    public class CarDal
    {
        public static List<CarApi> getCars(string make,string model,short year, short? limit=1)
        {   
            //API URL
            string url = $"https://api.api-ninjas.com/v1/cars?X-Api-Key=636buJJLqIrmAVlQmCTMN9MCh9U4ValjBnLJgn5K&model={model}&make={make}&year={year}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response  = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();
            Console.WriteLine(JSON);

            List<CarApi> result = JsonConvert.DeserializeObject<List<CarApi>>(JSON);
            return result;

        }


    }
}
