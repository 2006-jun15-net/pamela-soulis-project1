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



    public class ProductRepository : GenericRepository<pamela_soulis_project1.DataAccess.Model.Product, pamela_soulis_project1.Domain.Model.Product>
    {

        public ProductRepository(pamelasoulisproject1Context _context) : base(_context)
        {

        }

    }
}
