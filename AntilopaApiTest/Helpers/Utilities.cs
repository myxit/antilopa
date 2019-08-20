using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AntilopaApi.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AntilopaApiTest.Helpers
{
    public static class DtoTestExtension
    {
        private static object MapCarToApiResponse(Car car) => new
        {
            // WARN: order maters! check AntilopaApi.Models.CarViewModel
            car.Id,
            car.Nickname,
            car.Model,
            car.RegistrationNr,
            car.PicUrl,
            car.CreatedAt,
            car.UpdatedAt,
            car.OwnerId,
        };
        
        public static string AsJsonResponse(this Car car)
        {
            var jsonObj = MapCarToApiResponse(car);
            return Utilities.ToJson(jsonObj);
        }

        public static string AsJsonResponse(this Car[] cars)
        {
            return Utilities.ToJson(cars.Select(MapCarToApiResponse));
        }
    }

    public static class Utilities
    {
        #region snippet1
        public static void InitializeDbForTests(ApplicationDbContext db)
        {            
            db.Owners.AddRange(new Owner[] {
                testOwner1
            });
            
            db.SaveChanges();
            var testId = testOwner1.Id;
            var carId = testCar1.Id;
        }
        public static Car testCar1 = new Car {
            Model = "Volvo S60",
            RegistrationNr = "AZK193",
            Nickname = "Orange insane",
            PicUrl = "https://volvo.se/pic/s60.png",
        };
        public static Car testCar2 = new Car {
            Model = "VAZ 2106",
            RegistrationNr = "OE102",
            Nickname = "Silver fury",
            PicUrl = "https://vaz.ru/pic/2106.png",
        };

        public static Owner testOwner1 = new Owner {
            Name = "Glukoza Inc.",
            Address = "11717, Stockholm, Kungsgatan 1",
            Cars = new Car[] {testCar1, testCar2},
        };
    
        public static Car car3Data = new Car {
            Model = "Tesla Model X",
            RegistrationNr = "LPN889",
            Nickname = "Silent assassin",
            PicUrl = "https://tesla.com/pic/modelx.png",
        };

        internal static HttpContent ToJsonBody(object carDataPost)
        {
            return new StringContent(JsonConvert.SerializeObject(carDataPost), Encoding.UTF8, "application/json");
        }

        internal static async Task<Car> FromJsonAsync(this HttpContent httpContent) {
            var json = await httpContent.ReadAsStringAsync();
            var res = new Car();
            JsonConvert.PopulateObject(json, res);
            return res;
        }

        #endregion

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() }
        };

        internal static string ToJson(object value)
        {
            return JsonConvert.SerializeObject(value, Formatting.None, _jsonSerializerSettings);
        }
    }
}
