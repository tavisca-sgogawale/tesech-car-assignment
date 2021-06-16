using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tensech.CarApi.Common
{
    public class KeyStore
    {
        public static class Store
        {
            public const string StoreName = "DynamoDb";
            public const string MockStoreName = "Mock";
            public const string DynamoDbStoreName = "DynamoDb";

        }
        public static class DynamoDbConfig
        {
            public const string TableName = "CarTable";
            public const string Region = "us-east-2";
            public const string PrimaryAttributeName = "Id";

        }
        public static class Headers
        {
            public const string Authorization = "Authorization";
        }

        public static class Paging
        {
            public const int PageSize = 10;
            public const int PageNo = 1;
            
        }

    }
}
