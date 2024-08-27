using RestfulAPI.Model;

namespace RestfulAPI.DTOs.Responses
{
    public class AddressResponse
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public GeoResponse Geo { get; set; }
    }
}
