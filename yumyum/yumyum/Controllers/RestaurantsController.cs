using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using yumyum.Models;

namespace yumyum.Controllers
{
    public class RestaurantsController
    {
        public async Task<Restaurant> Post(NewRestaurantModel model)
        {
            var mongoContext = new MongoContext();

            var restaurant = new Restaurant
            {
                Address = model.Address,
                //Category = model.Category,
                City = model.City,
                Comments = new List<Comment>(),
                Country = model.Country,
                CreatedDate = DateTime.UtcNow,
                DeliveryTime = model.DeliveryTime,
                Description = model.Description,
                Estate = model.Estate,
                Lat = model.Lat,
                Logo = model.Logo,
                Long = model.Long,
                MailOwner = model.MailOwner,
                Name = model.Name,
                Phone = model.Phone,
                Rates = new List<Rate>(),
                Schedules = new List<Schedule>(),
                ServiceRange = model.ServiceRange,
                ShippingCost = model.ShippingCost,
                Tags = new List<string>()
            };

            await mongoContext.Restaurants.InsertOneAsync(restaurant);

            return restaurant;
        }
    }
}