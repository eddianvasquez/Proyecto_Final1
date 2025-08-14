
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proyecto_Final1.Services
{
    public class CartService
    {
        
        private Dictionary<int, CartItem> _cartItems = new Dictionary<int, CartItem>();

        
        public event Action? OnChange;

        
        public void AddItem(CartItem item)
        {
            if (_cartItems.TryGetValue(item.ProductId, out var existingItem))
            {
                existingItem.Quantity += item.Quantity; 
            }
            else
            {
                _cartItems.Add(item.ProductId, item); 
            }
            NotifyChange();
        }

        
        public List<CartItem> GetCartItems()
        {
            return _cartItems.Values.ToList();
        }

       
        public int GetCartCount()
        {
            return _cartItems.Values.Sum(item => item.Quantity);
        }

        
        public void IncreaseQuantity(int productId)
        {
            if (_cartItems.TryGetValue(productId, out var item))
            {
                item.Quantity++;
                NotifyChange();
            }
        }

        
        public void DecreaseQuantity(int productId)
        {
            if (_cartItems.TryGetValue(productId, out var item) && item.Quantity > 1)
            {
                item.Quantity--;
                NotifyChange();
            }
            else if (item != null && item.Quantity == 1)
            {
                RemoveItem(productId);
            }
        }

        
        public void RemoveItem(int productId)
        {
            _cartItems.Remove(productId);
            NotifyChange();
        }

        
        public void ClearCart()
        {
            _cartItems.Clear();
            NotifyChange();
        }

        
        private void NotifyChange() => OnChange?.Invoke();
    }

   
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}