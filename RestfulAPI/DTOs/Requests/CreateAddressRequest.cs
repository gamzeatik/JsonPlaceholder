using RestfulAPI.Model;

namespace RestfulAPI.DTOs.Requests
{
    public class CreateAddressRequest
    {
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public CreateGeoRequest Geo { get; set; }
    }
}
