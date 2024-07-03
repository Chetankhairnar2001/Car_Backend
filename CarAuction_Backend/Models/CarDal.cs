using Microsoft.EntityFrameworkCore.Storage.Json;
using Newtonsoft.Json;
using System.Net;

namespace CarAuction_Backend.Models
{
    public class CarDal
    {
        public static List<Car> getCars(string make,string model,short year)
        {   
            //API URL
            string url = $"https://api.api-ninjas.com/v1/cars?X-Api-Key=636buJJLqIrmAVlQmCTMN9MCh9U4ValjBnLJgn5K&model={model}&make={make}&year={year}";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response  = (HttpWebResponse)request.GetResponse();

            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();
            Console.WriteLine(JSON);

            List<Car> result = JsonConvert.DeserializeObject<List<Car>>(JSON);
            return result;

        }


    }
}
