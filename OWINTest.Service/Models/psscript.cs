using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OWINTest.Service.Models {
    public class psscript {
        public execute [] PsScript {
            get; set;
        }
        /*
        public psscript(var PsScript) {
            this.PsScript = PsScript;
        }*/

        public string getCommand(int indx) {

            return PsScript [indx].getValue();
        }

    }
}
