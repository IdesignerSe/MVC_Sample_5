using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Sample_1.Models
{
        /// <summary>
        /// Classes originate from weatherapi.com
        /// See www.weatherapi.com for documention
        /// Used jsonutil.com to generate classes with PascalCase property
        /// names and JsonProperty to map property names from api response
        /// with class properites
        /// </summary>
        public class Location
        {

            [JsonProperty("name")]
            public string Name { get; set; }

            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("country")]
            public string Country { get; set; }

            [JsonProperty("lat")]
            public double? Lat { get; set; }

            [JsonProperty("lon")]
            public double? Lon { get; set; }

            [JsonProperty("tz_id")]
            public string TzId { get; set; }

            [JsonProperty("localtime_epoch")]
            public int? LocaltimeEpoch { get; set; }

            [JsonProperty("localtime")]
            public string Localtime { get; set; }
        }

        public class Condition
        {

            [JsonProperty("text")]
            public string Text { get; set; }

            [JsonProperty("icon")]
            public string Icon { get; set; }

            [JsonProperty("code")]
            public int? Code { get; set; }
        }

        public class Current
        {

            [JsonProperty("last_updated_epoch")]
            public int? LastUpdatedEpoch { get; set; }

            [JsonProperty("last_updated")]
            public string LastUpdated { get; set; }

            [JsonProperty("temp_c")]
            public double? TempC { get; set; }

            [JsonProperty("temp_f")]
            public double? TempF { get; set; }

            [JsonProperty("is_day")]
            public int? IsDay { get; set; }

            [JsonProperty("condition")]
            public Condition Condition { get; set; }

            [JsonProperty("wind_mph")]
            public double? WindMph { get; set; }

            [JsonProperty("wind_kph")]
            public double? WindKph { get; set; }

            [JsonProperty("wind_degree")]
            public int? WindDegree { get; set; }

            [JsonProperty("wind_dir")]
            public string WindDir { get; set; }

            [JsonProperty("pressure_mb")]
            public double? PressureMb { get; set; }

            [JsonProperty("pressure_in")]
            public double? PressureIn { get; set; }

            [JsonProperty("precip_mm")]
            public double? PrecipMm { get; set; }

            [JsonProperty("precip_in")]
            public double? PrecipIn { get; set; }

            [JsonProperty("humidity")]
            public double? Humidity { get; set; }

            [JsonProperty("cloud")]
            public double? Cloud { get; set; }

            [JsonProperty("feelslike_c")]
            public double? FeelslikeC { get; set; }

            [JsonProperty("feelslike_f")]
            public double? FeelslikeF { get; set; }

            [JsonProperty("vis_km")]
            public double? VisKm { get; set; }

            [JsonProperty("vis_miles")]
            public double? VisMiles { get; set; }

            [JsonProperty("uv")]
            public double? Uv { get; set; }

            [JsonProperty("gust_mph")]
            public double? GustMph { get; set; }

            [JsonProperty("gust_kph")]
            public double? GustKph { get; set; }
        }

        public class Weather
        {

            [JsonProperty("location")]
            public Location Location { get; set; }

            [JsonProperty("current")]
            public Current Current { get; set; }
        }


    }
