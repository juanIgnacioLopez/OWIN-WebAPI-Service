using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest.Service.Models {
    public class healthCheck {
        public string servicio;
        public string request;

        public healthCheck(string servicio,string request) {
            this.servicio = servicio;
            this.request = request;
        }
    }
}
