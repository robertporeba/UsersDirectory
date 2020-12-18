﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UsersDirectoryMVC.Application.Interfaces;
using UsersDirectoryMVC.Application.ViewModels.Customer;
using UsersDirectoryMVC.Domain.Interfaces;

namespace UsersDirectoryMVC.Application.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public int AddCustomer(NewCustomerVm customer)
        {
            throw new NotImplementedException();
        }

        public ListCustomerForListVm GetAllActiveCustomersForList()
        {
            var customers = _customerRepository.GetAllActiveCustomers()
                .ProjectTo<CustomerForListVm>(_mapper.ConfigurationProvider).ToList();
            var customerList = new ListCustomerForListVm()
            {
                Customers = customers,
                Count = customers.Count
            };
            return customerList;
        }

        public CustomerDetailsVm GetCustomerDetails(int customerId)
        {
            var customer = _customerRepository.GetCustomer(customerId);
            var customerVm = _mapper.Map<CustomerDetailsVm>(customer);

            customerVm.Addresses = new List<AddressForListVm>();
            customerVm.PhoneNumbers = new List<ContactDetailListVm>();
            customerVm.Emails = new List<ContactDetailListVm>();

            foreach (var address in customer.Addresses)
            {
                var add = new AddressForListVm
                {
                    Id = address.Id,
                    Country = address.Country,
                    City = address.City
                };
                customerVm.Addresses.Add(add);
            }
            return customerVm;
        }
    }
}
