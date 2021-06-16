using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Core.Models;
using Tensech.CarApi.Services.Contract;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Amazon;
using System.Collections.Specialized;
using Tensech.CarApi.Common;
using Amazon.SecurityToken;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Tensech.CarApi.Common;
using System.Net;
using static Tensech.CarApi.Common.DataBaseException;

namespace Tensech.CarApi.Store
{
    public class CarDynamoDBStore : ICarStore
    {
        private DynamoDbSettings settings;
        private AmazonDynamoDBConfig clientConfiguration = new AmazonDynamoDBConfig();
        private AmazonDynamoDBClient _dynamoDBClient;

        public CarDynamoDBStore()
        {
            Configure();
        }
        public async Task Configure()
        {

            DynamoDbSettings settings = await DynamoDbSettings.GetSettings();

            clientConfiguration.RegionEndpoint = RegionEndpoint.GetBySystemName(settings.Region);
            _dynamoDBClient = new AmazonDynamoDBClient(clientConfiguration);
        }

        public async Task<Car> AddCarAsync(Car car)
        {
            try
            {
                var request = CreatePutItemRequest(car);
                var response = await _dynamoDBClient.PutItemAsync(request);
                var result = await GetCarByIdAsync(car.Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(FaultCodes.DatabaseException, FaultMessages.DatabaseException, HttpStatusCode.InternalServerError);
            }

        }

        public async Task DeleteCarByIdAsync(string id)
        {
            try
            {
                var request = CreateDeleteItemRequest(id);
                var response = await _dynamoDBClient.DeleteItemAsync(request);
            }
            catch (Exception ex)
            {
                throw new DataBaseException(FaultCodes.DatabaseException, FaultMessages.DatabaseException, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Core.Models.GetAllCarsResponse> GetAllCarsAsync(Paging paging)
        {
            try
            {
                var conditions = new List<ScanCondition>();
                Dictionary<string, Condition> scanFilter = new Dictionary<string, Condition>();
                var response = await _dynamoDBClient.ScanAsync(KeyStore.DynamoDbConfig.TableName, scanFilter);
                return response.Items.ToGetAllCarsResponse(paging);
            }
            catch (Exception ex)
            {
                throw new DataBaseException(FaultCodes.DatabaseException, FaultMessages.DatabaseException, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Car> GetCarByIdAsync(string id)
        {
            try
            {
                var request = CreateGetItemRequest(id);
                var response = await _dynamoDBClient.GetItemAsync(request);
                if (response.Item.Count > 0 )
                    return response.Item.ToCarModel();
                throw new KeyNotFoundError(FaultCodes.KeyNotFound, string.Format(FaultMessages.KeyNotFound,id), HttpStatusCode.NotFound);
            }
            catch(KeyNotFoundError ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(FaultCodes.DatabaseException, FaultMessages.DatabaseException, HttpStatusCode.InternalServerError);
            }
        }

        public async Task<Car> ModifyCarAsync(Car car)
        {
            try
            {
                var request = CreatePutItemRequest(car);
                var response = await _dynamoDBClient.PutItemAsync(request);
                var result = await GetCarByIdAsync(car.Id);
                return result;
            }
            catch (Exception ex)
            {
                throw new DataBaseException(FaultCodes.DatabaseException, FaultMessages.DatabaseException, HttpStatusCode.InternalServerError);
            }
        }
        private GetItemRequest CreateGetItemRequest(string id)
        {
            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                 { "Id", new AttributeValue { S = id } }
            };
            var request = new GetItemRequest()
            {
                TableName = KeyStore.DynamoDbConfig.TableName,
                Key = key
            };
            return request;
        }

        private DeleteItemRequest CreateDeleteItemRequest(string id)
        {
            Dictionary<string, AttributeValue> key = new Dictionary<string, AttributeValue>
            {
                 { "Id", new AttributeValue { S = id } }
            };
            var request = new DeleteItemRequest()
            {
                TableName = KeyStore.DynamoDbConfig.TableName,
                Key = key
            };
            return request;
        }

        private PutItemRequest CreatePutItemRequest(Car car)
        {
            Dictionary<string, AttributeValue> attributes = new Dictionary<string, AttributeValue>();
            attributes["Id"] = new AttributeValue { S = car.Id };
            attributes["Name"] = new AttributeValue { S = car.Name };
            attributes["Manufacturer"] = new AttributeValue { S = car.Manufacturer };
            attributes["Type"] = new AttributeValue { S = car.Type.ToString() };
            attributes["Price"] = new AttributeValue { S = car.Price.Amount.ToString() };
            attributes["Mileage"] = new AttributeValue { S = car.Mileage.ToString() };
            var request = new PutItemRequest()
            {
                TableName = KeyStore.DynamoDbConfig.TableName,
                Item = attributes
            };
            return request;
        }

    }
}
