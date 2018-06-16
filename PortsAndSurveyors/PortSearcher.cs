using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GMap.NET;

namespace PortsAndSurveyors {
    class PortSearcher {
        public List<Port> Ports {
            get;
        }

        public PortSearcher(List<Port> ports) {
            Ports = ports;
        }

    }
}
