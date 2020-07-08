using pamela_soulis_project1.DataAccess.Model;
using pamela_soulis_project1.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace pamela_soulis_project1.Domain.Repositories
{
    interface IGenericRepository<TDAL, TBLL>
        where TDAL : DataModel, new()
        where TBLL : BaseBusinessModel, new()
    {
        IEnumerable<TBLL> GetAll();
        TBLL GetById(int id);
        void Insert(TBLL obj);
        void Update(TBLL obj);
        void Delete(int id);
        void SaveToDB();
    }

}
