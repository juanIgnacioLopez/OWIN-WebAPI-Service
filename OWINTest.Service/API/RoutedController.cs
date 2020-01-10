using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OWINTest.Service.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.ServiceProcess;
using System.Text;
using System.Web.Http;
using System.Web.Script.Serialization;
//using System.Management.Automation; //PowerShell assembly


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
        [HttpGet]
        public healthCheck GetHealthCheck() {
            var data = Data();
            healthCheck result = new healthCheck(data [0],data [1]);
            //return ToJSON(result);
            return result;
        }
        [Route("data")]
        public HttpResponseMessage GetExecute() {
            return dataHTTP();
        }
        /*
        [Route("execute")]
        [HttpPost]
        public object PostExecute([FromBody]object request) {
            JObject y = JObject.FromObject(request);
            var x = y.ChildrenTokens();
            //string aux = x.First();
            return x.ToString();
            object aux = request;
            object x = ToJSON(aux);

            return request;
        } */

        [Route("execute")]
        [HttpPost]
        public List<string> PostExecute([FromBody]psscript request) {

            List<string> result = new List<string>();
            for (int i = 0; i < request.PsScript.Length; i++) {
                var x = request.getCommand(i);
                result.Add(x);
            }
            return result;
        }

        public static object ToJSON(object obj) {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string aux = JsonConvert.SerializeObject(obj);
            //return JsonConvert.SerializeObject(obj);
            object x = serializer.DeserializeObject(aux);
            return x;

        }

        private string [] Data() {
            ServiceController sc = new ServiceController("OWINServiceTest");
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Accepted);
            string [] result = { sc.Status.ToString(),response.StatusCode.ToString() };
            return result;
        }
        private HttpResponseMessage dataHTTP() {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK);
            var statusCode = response.StatusCode;
            response.Content = new StringContent(Data() [0] + " :=: " + statusCode,Encoding.Unicode);


            return response;
        }

        /* -Ejecuta el comando powershell
        private string psCommand(string command) {
            using (PowerShell PSI = PowerShell.Create()) {
                PSI.AddScript(command);
                PSI.Invoke();
            }
            return "0";
        }*/
    }
}
