using Newtonsoft.Json;
using System.Net;

namespace CarAuction_Backend.Models
{  //Api keys:
   //Ben - VkwhRpw3NMXt2hIR4MqUS5jGihrO8HWV9YXptR3tlLvX8HDSphRG4WBkS2c5aevx
   //Chetan -  xodwKNADIFotBlhPrkhvUSUYSMQSiQdQCH2QNtyACI9OKlRAVMEWvH5YSsr5G9xI
   //Pedro - dXLulsao6DovQ4T2XPnlTOWrbikL4BfvUbdE3u4Y2E6v1g2wyYrBKoRLeVlZK7g4



	public class ZipCodeDAL
	{
		public static Distance getDistance(int zip1, int zip2)
		{
			//API URL
			string url = $"https://www.zipcodeapi.com/rest/VkwhRpw3NMXt2hIR4MqUS5jGihrO8HWV9YXptR3tlLvX8HDSphRG4WBkS2c5aevx/distance.json/{zip1}/{zip2}/miles";
			HttpWebRequest request = WebRequest.CreateHttp(url);
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

			StreamReader reader = new StreamReader(response.GetResponseStream());
			string JSON = reader.ReadToEnd();
			Console.WriteLine(JSON);

			Distance result = JsonConvert.DeserializeObject<Distance>(JSON);
			return result;

		}


	}
}