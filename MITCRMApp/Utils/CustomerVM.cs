using System;

namespace MITCRMApp
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public string NameSort => Name[0].ToString();
    }
}
