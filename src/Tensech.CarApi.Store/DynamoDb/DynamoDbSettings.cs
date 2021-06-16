using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tensech.CarApi.Common;

namespace Tensech.CarApi.Store
{
        class DynamoDbSettings
{
        public string TableName { get; set; }
        public string Region { get; set; }
        public string PrimaryAttributeName { get; set; }
        public string PrimaryAttributeValue { get; set; }
        public string CounterAttributeName { get; set; }

        private static NameValueCollection configurations = new NameValueCollection();
            
        public static async Task<DynamoDbSettings> GetSettings()
        {
            configurations.Add("tablename", KeyStore.DynamoDbConfig.TableName);
            configurations.Add("region", KeyStore.DynamoDbConfig.Region);
            configurations.Add("primaryattributename", KeyStore.DynamoDbConfig.PrimaryAttributeName);
            var dynamodbSettings = new DynamoDbSettings()
            {
                TableName = configurations["tablename"],
                Region = configurations["region"],
                PrimaryAttributeName = configurations["primaryattributename"],            
            };

            if (string.IsNullOrWhiteSpace(dynamodbSettings.TableName))
                throw new MissingServiceConfigurationException(nameof(dynamodbSettings.TableName), KeyStore.DynamoDbConfig.TableName,System.Net.HttpStatusCode.InternalServerError);

            return dynamodbSettings;
        }
    }
}
