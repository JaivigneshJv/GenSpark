using Microsoft.AspNetCore.Mvc;
using PizzaOrderingAPI.Models;
using PizzaOrderingAPI.Models.DTOs;

namespace PizzaOrderingAPI.Interfaces
{
    public interface IPizzaService
    {
        Task<IEnumerable<Pizza>> GetPizzasInStock();
        Task<Pizza> CreatePizza(Pizza pizza);
        Task<Pizza> GetPizzaById(int id);
        Task<List<Pizza>> GetAllPizzas();
        Task<Pizza> UpdatePizza(int id, Pizza updatedPizza); 
        Task DeletePizza(int id);
        Task<Pizza> GetPizzaByName(string name);
    }
}
