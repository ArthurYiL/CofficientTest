using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Cofficient.Configuration
{
    /// <summary>
    /// 系数配置项
    /// </summary>
    public class Coefficient
    {
        /// <summary>
        /// 省份
        /// </summary>
        [JsonProperty(PropertyName = "province", Required = Required.Always)]
        public string Province { get; set; }
        /// <summary>
        /// 系数值
        /// </summary>
        [JsonProperty(PropertyName = "value", Required = Required.Always)]
        public string Value { get; set; }
        /// <summary>
        /// 季节
        /// </summary>
        [JsonProperty(PropertyName = "season", Required = Required.Default)]
        public string Season { get; set; }
        /// <summary>
        /// 城市
        /// </summary>
        [JsonProperty(PropertyName = "city", Required = Required.Default)]
        public string City { get; set; }
    }

}
