using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelExpertsData.Models;

namespace TravelExpertsData
{
    public class SupplierList : List<Supplier>
    {
        //// Modify the behavior of the Add method of the List<> class
        //public new void Add(Supplier s) => base.Insert(0, s);

        //// Provide two additional methods
        //public void Fill()
        //{
        //    List<Supplier> suppliers = SupplierDB.GetSuppliers();
        //    foreach (SupplierDTO supplier in suppliers)
        //        base.Add(supplier);
        //}

        //public void Save() => SupplierDB.SaveSuppliers(this);
    }
}
