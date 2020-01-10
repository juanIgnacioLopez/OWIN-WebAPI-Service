using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;

namespace OWINTest.Service {
    public partial class APIServiceTest : ServiceBase {
        //public string baseAddress = "http://localhost:9000/";
        public string baseAddress = ConfigurationManager.AppSettings.Get("Url") + ConfigurationManager.AppSettings.Get("Port");
        private IDisposable _server = null;

        public APIServiceTest() {
            InitializeComponent();
        }
        public void OnDebug() {
            OnStart(null);
        }

        protected override void OnStart(string [] args) {
            _server = WebApp.Start<Startup>(url: baseAddress);
        }

        protected override void OnStop() {
            if (_server != null) {
                _server.Dispose();
            }
            base.OnStop();
        }
    }
}
