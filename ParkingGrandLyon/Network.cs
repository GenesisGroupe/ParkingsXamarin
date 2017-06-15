using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ParkingGrandLyon {
public class Network
{
	HttpClient client = new HttpClient();

	static string authorization = "Basic cGF1bGluZS5tb250Y2hhdUBnbWFpbC5jb206RXBpdGVjaDQyLjIwMDc=";
	static string parkingsUrl = "https://download.data.grandlyon.com/wfs/rdata?SERVICE=WFS&VERSION=2.0.0&outputformat=GEOJSON&maxfeatures=30&request=GetFeature&typename=pvo_patrimoine_voirie.pvoparkingtr&SRSNAME=urn:ogc:def:crs:EPSG::4171";
	public Network()
	{
		//GetLocations();
	}


	public async Task<string> GetParkings(int limit)
	{
		client.DefaultRequestHeaders.Authorization = AuthenticationHeaderValue.Parse(authorization);
		var response = await client.GetStringAsync(parkingsUrl);
		return response;
	}



    }
}
