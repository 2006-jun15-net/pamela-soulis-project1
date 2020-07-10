using Microsoft.EntityFrameworkCore;
using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace pamela_soulis_project1.Domain.Repositories
{



    public class LocationRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.Location, pamela_soulis_project1.Domain.Model.Location>
    {

        public LocationRepository(pamelasoulisproject1Context _context) : base(_context)
        { 

        }


        /// <summary>
        /// Returns a Location Business Entity, with access to navigation properties
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public pamela_soulis_project1.Domain.Model.Location GetWithNavigations(int locationId)
        {
            var location = table
                .Include(l => l.Inventory)
                    .ThenInclude(i => i.Product)
                .FirstOrDefault();


            var businessLocation = mapper.Map<pamela_soulis_project1.Domain.Model.Location>(location);
            return businessLocation;
        }



        /// <summary>
        /// Method to get the order history of a location
        /// </summary>
        /// <param name="locationId"></param>
        /// <returns></returns>
        public pamela_soulis_project1.Domain.Model.Location GetOrderHistory(int locationId)
        {
            var location = table
                .Include(l => l.Orders)
                    .ThenInclude(o => o.OrderLine)
                        .ThenInclude(o1 => o1.Product)
                .First(i => i.LocationId == locationId);

            var businessLocation = mapper.Map<pamela_soulis_project1.Domain.Model.Location>(location);
            return businessLocation;
        }
    }
}
