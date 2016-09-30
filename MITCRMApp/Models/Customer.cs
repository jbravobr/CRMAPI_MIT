using System;
namespace MITCRMApp
{
    public class Customer : EntityBase
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public object address { get; set; }
        public int addressId { get; set; }
        public bool status { get; set; }
        public double lastOrderAmout { get; set; }
        public object orders { get; set; }
        public string password { get; set; }
        public string username { get; set; }
        public string dtCreation { get; set; }
        public string dtLastUpdate { get; set; }

        public string NameSort => firstName[0].ToString();
    }
}
