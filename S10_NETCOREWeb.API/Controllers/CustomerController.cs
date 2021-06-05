using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using S10_NETCOREWeb.Domain.Core.DTOs;
using S10_NETCOREWeb.Domain.Core.Entities;
using S10_NETCOREWeb.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace S10_NETCOREWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;


        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetCustomer")]
        public async Task<IActionResult> GetCustomer()
        {
            var customers = await _customerRepository.GetCustomers();

            var customerList = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

            //var customerList = new List<CustomerDTO>();
            //foreach (var item in customers)
            //{
            //    var customerDTO = new CustomerDTO()
            //    {
            //        Id = item.Id,
            //        FirstName = item.FirstName,
            //        LastName = item.LastName,
            //        Country = item.Country,
            //        City = item.City,
            //        Phone = item.Phone
            //    };
            //    customerList.Add(customerDTO);
            //}


            return Ok(customerList);
        }

        [HttpGet]
        [Route("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _customerRepository.GetCustomerById(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        [Route("PostCustomer")]
        public async Task<IActionResult> PostCustomer(CustomerPostDTO customerPostDTO)
        {
            var customer = _mapper.Map<Customer>(customerPostDTO);

            //var customer = new Customer()
            //{
            //    FirstName = customerPostDTO.FirstName,
            //    LastName = customerPostDTO.LastName,
            //    Country = customerPostDTO.Country,
            //    City = customerPostDTO.City,
            //    Phone = customerPostDTO.Phone
            //};

            await _customerRepository.InsertCustomer(customer);
            return Ok(customer);
        }


        [HttpPut]
        [Route("PutCustomer")]
        public async Task<IActionResult> PutCustomer(Customer customer)
        {
            await _customerRepository.UpdateCustomer(customer);
            return Ok(customer);
        }


        [HttpDelete]
        [Route("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var result = await _customerRepository.DeleteCustomer(id);
            if (!result)
                return NotFound();

            return NoContent();
        }


    }
}
