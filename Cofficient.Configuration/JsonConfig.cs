using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Cofficient.Configuration
{
    /// <summary>
    /// Json根节点
    /// </summary>
    public class JsonConfig
    {
        /// <summary>
        /// Config配置节点
        /// </summary>
        [JsonProperty(PropertyName = "config")]
        public Config Config { get; set; }
    }
}
