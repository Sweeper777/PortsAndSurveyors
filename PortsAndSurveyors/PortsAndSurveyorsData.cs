using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using GMap.NET;

namespace PortsAndSurveyors {

    //    var portsAndASurveyorsData = PortsAndASurveyorsData.FromJson(jsonString);

    public partial class PortsAndASurveyorsData {
        [JsonProperty("ports")]
        public List<Port> Ports {
            get; set;
        }

        [JsonConverter(typeof(SurveyorsConverter))]
        [JsonProperty("surveyors")]
        public Dictionary<long, Surveyor> Surveyors {
            get; set;
        }
    }

    public partial class Port {
        [JsonProperty("name")]
        public string Name {
            get; set;
        }

        [JsonProperty("latitude")]
        public double Latitude {
            get; set;
        }

        [JsonProperty("longitude")]
        public double Longitude {
            get; set;
        }

        [JsonProperty("surveyors")]
        public List<long> Surveyors {
            get; set;
        }

        public PointLatLng Location {
            get {
                return new PointLatLng(Latitude, Longitude);
            }
        }

        public override string ToString() {
            return Name;
        }
    }

    public partial class Surveyor {
        [JsonProperty("id")]
        public long Id {
            get; set;
        }

        [JsonProperty("name")]
        public string Name {
            get; set;
        }

        [JsonConverter(typeof(StringArrayConverter))]
        [JsonProperty("contacts")]
        public string Contacts {
            get; set;
        }

        [JsonConverter(typeof(StringArrayConverter))]
        [JsonProperty("prices")]
        public string Prices {
            get; set;
        }

        public override string ToString() {
            return Name;
        }
    }

    public partial class PortsAndASurveyorsData {
        public static PortsAndASurveyorsData FromJson(string json) => JsonConvert.DeserializeObject<PortsAndASurveyorsData>(json, Converter.Settings);
    }

    public static class Serialize {
        public static string ToJson(this PortsAndASurveyorsData self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    public class SurveyorsConverter : JsonConverter<Dictionary<long, Surveyor>> {
        public override Dictionary<long, Surveyor> ReadJson(JsonReader reader, Type objectType, Dictionary<long, Surveyor> existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var surveyors = serializer.Deserialize<Surveyor[]>(reader);
            if (!surveyors.All(new HashSet<Surveyor>().Add)) {
                throw new JsonSerializationException("Surveyor IDs contain duplicates!");
            }
            return surveyors.ToDictionary(x => x.Id, x => x);
        }

        public override void WriteJson(JsonWriter writer, Dictionary<long, Surveyor> value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }

    public class StringArrayConverter : JsonConverter<string> {
        public override string ReadJson(JsonReader reader, Type objectType, string existingValue, bool hasExistingValue, JsonSerializer serializer) {
            var lines = serializer.Deserialize<string[]>(reader);
            return string.Join(Environment.NewLine, lines);
        }

        public override void WriteJson(JsonWriter writer, string value, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }
}
