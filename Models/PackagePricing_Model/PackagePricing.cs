using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoldenPet.Models.PackagePricing_Model
{
    public class PackagePricing
    {
        public string PackageName { get; set; }
        public decimal? PackagePrice { get; set; }
        public List<FeatureModel> Features { get; set; }
        public string Imglink {  get; set; }

        public class FeatureModel
        {
            public string FeatureName { get; set; }
            public bool IsIncluded { get; set; }
        }
    }
}