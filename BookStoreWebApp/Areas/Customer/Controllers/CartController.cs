using BookStoreWebApp.DataAccess.Repository.IRepository;
using BookStoreWebApp.Models;
using BookStoreWebApp.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookStoreWebApp.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartVM ShoppingCartVM { get; set; }
        public CartController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            ShoppingCartVM = new ShoppingCartVM()
            {
                CartList = _unitOfWork.ShoppingCart.GetAll(u=>u.ApplicationUserId == claim.Value, includeProperties: "Product")
            };

            foreach (var cart in ShoppingCartVM.CartList)
            {
                cart.Price = GetPriceByQuantity(cart.Count, cart.Product.Price, cart.Product.Price50, cart.Product.Price100);
                ShoppingCartVM.CartTotalPrice += cart.Price * cart.Count;
            }

            return View(ShoppingCartVM);
        }

        public IActionResult Summary()
        {
            return View();
        }

        public IActionResult IncrementCount (int cartId)
        {
            var cartFromDatabase = _unitOfWork.ShoppingCart.GetFirstOrDefault(u=>u.Id==cartId);
            _unitOfWork.ShoppingCart.IncrementCount(cartFromDatabase, 1);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult DecrementCount (int cartId)
        {
            var cartFromDatabase = _unitOfWork.ShoppingCart.GetFirstOrDefault(u=>u.Id==cartId);
            if(cartFromDatabase.Count < 1)
            {
                _unitOfWork.ShoppingCart.Delete(cartFromDatabase);
            }
            else
            {
                _unitOfWork.ShoppingCart.DecrementCount(cartFromDatabase, 1);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete (int cartId)
        {
            var cartFromDatabase = _unitOfWork.ShoppingCart.GetFirstOrDefault(u=>u.Id==cartId);
            _unitOfWork.ShoppingCart.Delete(cartFromDatabase);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private double GetPriceByQuantity(double quantity, double price, double price50, double price100)
        {
            if(quantity <= 50)
            {
                return price;
            }
            else
            {
                if (quantity <=100)
                {
                    return price50;
                }
                return price100;
            }
        }
    }
}
