﻿using System.ComponentModel.DataAnnotations;

namespace RestfulAPI.Model
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string Street { get; set; }
        public string Suite { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public Geo Geo { get; set; }
    }
}
