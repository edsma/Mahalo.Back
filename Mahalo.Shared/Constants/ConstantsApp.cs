using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mahalo.Shared.Constants
{
    public class ConstantsApp
    {
        public struct AppConstants
        {
            public const string ResultOk = "OK";    
            public const string ResultError = "Error";    

        }

        public struct StatusForAcceptance
        {
            public const string published = "Published";
            public const string underReview = "Under review";
        }
    }
}
