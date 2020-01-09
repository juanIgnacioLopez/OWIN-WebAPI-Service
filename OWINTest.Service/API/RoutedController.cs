using OWINTest.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace OWINTest.Service.API {
    [RoutePrefix("api/testing")]
    public class RoutedController : ApiController {
        [Route("getall")]
        public IEnumerable<string> GetAllItems() {
            return new string [] { "value1","value2" };
        }
        [Route("check")]
        public string [] Check() {
            return Data();
        }
        [Route("healthcheck")]
        public healthCheck GetHealthCheck() {
            var data = Data();
            healthCheck result = new healthCheck(data [0],data [1]);
            //return ToJSON(result);
            return result;
        }
        public static string ToJSON(object obj) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(new {
                Estado =
                obj
            });
        }

        private string [] Data() {
            ServiceController sc = new ServiceController("OWINServiceTest");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            string [] result = { sc.Status.ToString(),response.StatusCode.ToString() };
            return result;
        }
    }
}
