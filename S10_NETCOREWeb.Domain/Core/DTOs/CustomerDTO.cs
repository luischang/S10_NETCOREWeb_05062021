using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_NETCOREWeb.Domain.Core.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }

    public class CustomerPostDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
    }


    public class CustomerCountryCityDTO
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }

    public class CustomerFullNameDTO {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }


}
