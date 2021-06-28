﻿using OnlineShop.Domain.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Interfaces
{
    public interface ICartRepository
    {
        IQueryable GetAllCarts();
        Task<bool> AddCart(Cart cart);
        Task<bool> GetCart(int id);
        void UpdateCart(Cart cart);
        void RemoveCart(Cart cart);
        Task<bool> SaveChanges();
    }
}
