using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Core.Models;


namespace Tensech.CarApi.Store
{
    public static class ResponseTranslator
    {
       public static Car ToCarModel(this Dictionary<string, AttributeValue> item)
        {
            
            var car = new Car()
            {
                Id = item["Id"].S,
                Name = item["Name"].S,
                Manufacturer = item["Manufacturer"].S,
                Type = (CarType)Enum.Parse(typeof(CarType), item["Type"].S),
                Price = new Price(Int32.Parse(item["Price"].S)),
                Mileage = Double.Parse(item["Mileage"].S)
            };
            return car;
        }

       public static GetAllCarsResponse ToGetAllCarsResponse(this List<Dictionary<string, AttributeValue>> items, Paging paging)
        {
            paging.TotalRecords = items.Count;
            return new GetAllCarsResponse
            {
                Cars = items.Select(x => x.ToCarModel()).ToList(),
                Paging = paging
            };
        }

    }
}
