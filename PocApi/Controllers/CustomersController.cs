using Microsoft.AspNetCore.Mvc;
using PocApi.Models;
using System;

namespace PocApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public DefaultResponse Get()
        {
            try
            {
                var customers = _customerRepository.GetAll();
                return new DefaultResponse(true, customers);
            }catch(Exception ex)
            {
                return new DefaultResponse(false, "Falha ao obter Lista de Clientes: "+ex.Message);
            }
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public DefaultResponse Get(int id)
        {
            try{
                var customer = _customerRepository.Find(id);
                return new DefaultResponse(true, customer);
            }catch(Exception ex)
            {
                return new DefaultResponse(false, "Falha ao obter Cliente: "+ex.Message);
            }

        }
        [HttpPost]
        public DefaultResponse Post([FromBody] Customer item)
        {
            if (item == null)
            {
                return new DefaultResponse(false, "Objeto da requisição inválido");
            }

            try
            {
                _customerRepository.Add(item);
                return new DefaultResponse(true, item);
            }catch(Exception ex)
            {
                return new DefaultResponse(false, "Falha ao obter Cliente: "+ex.Message);
            }
        }

        [HttpPut("{id}")]
        public DefaultResponse Put(int id, [FromBody] Customer item)
        {
            if (item == null || id == 0)
            {
                return new DefaultResponse(false, "Objeto da requisição inválido!");
            }

            try
            {
                var customer = _customerRepository.Find(id);
                if (customer == null)
                    return new DefaultResponse(false, "Cliente não encontrado!");
                customer.Name = item.Name != null ? item.Name : customer.Name;
                customer.Cpf = item.Cpf != null ? item.Cpf : customer.Cpf;
                customer.Address = item.Address != null ? item.Address : customer.Address;
                _customerRepository.Update(customer);
                return new DefaultResponse(true, customer);
            }catch(Exception ex)
            {
                return new DefaultResponse(false, "Falha ao atualizar Cliente: "+ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public DefaultResponse Delete(int id)
        {
            try
            {
                var customer = _customerRepository.Find(id);
                if (customer == null)
                {
                    return new DefaultResponse(false, "Cliente não encontrado!");
                }
                _customerRepository.Remove(id);
                return new DefaultResponse(true, customer);
            }catch(Exception ex)
            {
                return new DefaultResponse(false, "Falha ao remover Cliente: "+ex.Message);
            }
        }
    }
}