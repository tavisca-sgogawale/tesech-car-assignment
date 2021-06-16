using Tensech.CarApi.Common;
using Tensech.CarApi.Services.Contract;

namespace Tensech.CarApi.Store
{
    public static class CarStoreFactory
    {
        public static ICarStore GetStore(string key)
        {
            if (key.Equals(KeyStore.Store.DynamoDbStoreName))
            {
                return new CarDynamoDBStore();
            }
            else
            {
                return new CarMockStore();
            }
        }
    }
}
