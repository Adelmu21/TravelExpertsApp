using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TravelExpertsData
{
    public class CombinedDataModel
    {
        public int PackageId { get; set; }
        public string PkgName { get; set; }


        [Column(TypeName = "money")]
        public decimal PkgBasePrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? PkgAgencyCommission { get; set; }


        //public string ProdName { get; set; }
        //public string SupName { get; set; }
        //public string ProdName2 { get; set; }
        //public string SupName2 { get; set; }


    }
}
