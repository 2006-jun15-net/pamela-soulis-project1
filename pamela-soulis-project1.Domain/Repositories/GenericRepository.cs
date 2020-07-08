using Microsoft.EntityFrameworkCore;
using pamela_soulis_project1.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using pamela_soulis_project1.Domain;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pamela_soulis_project1.Domain.Model;

namespace pamela_soulis_project1.Domain.Repositories
{
    public class GenericRepository<TDAL, TBLL> : IGenericRepository<TDAL, TBLL>
        where TDAL : DataModel, new()
        where TBLL : BaseBusinessModel, new()
    {
        private pamelasoulisproject1Context _context = null;
        protected DbSet<TDAL> table = null;
        protected IMapper mapper;



        /// <summary>
        /// A generic repository for the database, with a Mapper for each Data Access/Business Logic Entity
        /// </summary>
        /// <param name="_context"></param>
        public GenericRepository(pamelasoulisproject1Context _context)
        {
            this._context = _context;
            table = _context.Set<TDAL>();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.Customer, pamela_soulis_project1.Domain.Model.Customer>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.Customer, pamela_soulis_project1.DataAccess.Model.Customer>();

                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.Inventory, pamela_soulis_project1.Domain.Model.Inventory>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.Inventory, pamela_soulis_project1.DataAccess.Model.Inventory>();

                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.Location, pamela_soulis_project1.Domain.Model.Location>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.Location, pamela_soulis_project1.DataAccess.Model.Location>();

                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.OrderLine, pamela_soulis_project1.Domain.Model.OrderLine>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.OrderLine, pamela_soulis_project1.DataAccess.Model.OrderLine>();

                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.Orders, pamela_soulis_project1.Domain.Model.Orders>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.Orders, pamela_soulis_project1.DataAccess.Model.Orders>();

                cfg.CreateMap<pamela_soulis_project1.DataAccess.Model.Product, pamela_soulis_project1.Domain.Model.Product>();
                cfg.CreateMap<pamela_soulis_project1.Domain.Model.Product, pamela_soulis_project1.DataAccess.Model.Product>();

            });
            mapper = config.CreateMapper();
        }
        /// <summary>
        /// Returns List of Business Logic Entity values
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TBLL> GetAll()
        {
            var dataObjects = table.ToList();
            var businessObjects = mapper.Map<List<TBLL>>(dataObjects);
            return businessObjects; 
        }


        //public TDAL Get(int itemId)
        //{
        //    _context.Customer.Include(O)
        //    var test = _context.Customer
        //        .Include(c => c.Orders)
        //        .ThenInclude(o => o.OrderLine)


        //    var query = table.AsQueryable();
        //    var navigations = _context.Model.FindEntityType(typeof(TDAL))
        //         .GetDerivedTypesInclusive()
        //         .SelectMany(type => type.GetNavigations())
        //         .Distinct();

        //    foreach (var property in navigations)
        //    {
        //        query = query.Include(property.Name);
        //        var navigations2 = property.DeclaringEntityType.GetDerivedTypesInclusive()
        //            .SelectMany(type => type.GetNavigations())
        //            .Distinct();

        //        foreach( var property2 in navigations2)
        //        {
        //            query = query.ThenInclude(property2.Name);
        //            var navigations3 = property2.DeclaringEntityType.GetDerivedTypesInclusive()
        //                .SelectMany(type => type.GetNavigations())
        //                .Distinct();

        //            foreach(var property3 in navigations3)
        //            {
        //                query = query.ThenInclude(property3.Name);

        //            }
        //        }

        //    }



        //    return query.SingleOrDefault(i => i.Id == itemId);
        //}




        /// <summary>
        /// Returns Business Logic Entity, searched for by Primary Key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TBLL GetById(int id)
        {
            var dataObjects = table.Find(id);
            var businessObjects = mapper.Map<TBLL>(dataObjects);
            return businessObjects;
        }

        /// <summary>
        /// Takes in a Business Logic Entity and inserts a Data Access entry for given Model
        /// </summary>
        /// <param name="obj"></param>
        public void Insert(TBLL obj)
        {

            var dataObjects = mapper.Map<TDAL>(obj);
            table.Add(dataObjects);


        }

        public void Update(TBLL obj)
        {
            //var businessObjects = new TBLL();
            var dataObjects = mapper.Map<TDAL>(obj);
            var updatedData = table.Attach(dataObjects);
            _context.Entry(obj).State = EntityState.Modified;

        }

        public void Delete(int id)
        {
            TDAL existing = table.Find(id);
            table.Remove(existing);
            //var businessObjects = mapper.Map<TDAL>(existing);
        }

        /// <summary>
        /// Perminent commit to the database
        /// </summary>
        public void SaveToDB()
        {
            _context.SaveChanges();
        }


    }

}
