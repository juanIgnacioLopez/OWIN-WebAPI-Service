using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest.Service.Models {
    public class execute {
        public string value {
            set; get;
        }

        public execute(string value) {
            this.value = value;
        }

        public string getValue() {
            return value;
        }
    }
}
