﻿using PizzaOrderingAPI.Models;

namespace PizzaOrderingAPI.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
