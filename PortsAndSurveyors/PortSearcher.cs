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

        public List<Port> Search(string keywords) {
            var match = Regex.Match(keywords.Trim(), @"^(\S+?)([NSns])\s+(\S+?)([WEwe])$");
            if (match.Success) {
                int lat;
                var hasLat = int.TryParse(match.Groups[1].Value, out lat);
                int lng;
                var hasLng = int.TryParse(match.Groups[3].Value, out lng);
                if (hasLat && hasLng) {
                    if (match.Groups[2].Value.ToUpperInvariant() == "S") {
                        lat = -lat;
                    }
                    if (match.Groups[4].Value.ToUpperInvariant() == "W") {
                        lng = -lng;
                    }
                    return Search(new PointLatLng(lat, lng));
                }
            }
            var keywordArray = Regex.Split(keywords, @"\s+");
            return Search(keywordArray);
        }

        public List<Port> Search(params string[] keywords) {
            return keywords.SelectMany(
                x => Ports.Where(y => y.Name.Contains(x))
                )
                .GroupBy(x => x)
                .OrderBy(x => x.Key)
                .Select(x => x.Key).ToList();
        }

        public List<Port> Search(PointLatLng coordinate) {
            return Ports.OrderBy(x => x.Location.DistanceFrom(coordinate)).Take(10).ToList();
        }
    }

    static class PointLatLngHelper {
        public static double DistanceFrom(this PointLatLng p1, PointLatLng p2) {
            /*
            Credits: https://stackoverflow.com/a/27943/5133585
  var R = 6371; // Radius of the earth in km
  var dLat = deg2rad(lat2-lat1);  // deg2rad below
  var dLon = deg2rad(lon2-lon1); 
  var a = 
    Math.sin(dLat/2) * Math.sin(dLat/2) +
    Math.cos(deg2rad(lat1)) * Math.cos(deg2rad(lat2)) * 
    Math.sin(dLon/2) * Math.sin(dLon/2)
    ; 
  var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1-a)); 
  var d = R * c; // Distance in km
  return d;
            */
            var R = 6371.0;
            var dLat = (p2.Lat - p1.Lat).ToRadians();
            var dLon = (p2.Lng - p1.Lng).ToRadians();
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(p1.Lat.ToRadians()) * Math.Cos(p2.Lat.ToRadians()) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            var d = R * c;
            return d;
        }

        public static double ToRadians(this double degrees) {
            return degrees * (Math.PI / 180);
        }
    }
}
