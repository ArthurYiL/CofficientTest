using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Cofficient.Configuration
{
    /// <summary>
    /// 系数解析器
    /// </summary>
    public class CoefficientParser
    {
        public static int Level = 0;
        public static JsonConfig cfg = null;
        public CoefficientParser(string path)
        {
            Load(path,out cfg);
        }

        /// <summary>
        /// 根据具体规则解析系数
        /// </summary>
        /// <param name="province">省份</param>
        /// <param name="city">城市</param>
        /// <param name="season">季节</param>
        public decimal GetCoefficient(string province, string city, string season)
        {
            decimal coefficient = 0;
            if (province == null && city == null && season == null)
                throw new Exception("参数不合法");
            if (province == "全国" && city == null)
                Level = 0;
            if (province != null && city == null && season == null)
                Level = 1;
            if (province != null && (city == null || season == null))
                Level = 2;
            if (province != null && city != null && season != null)
                Level = 3;

            Coefficient[] coefficients = cfg.Config.Coefficient;
            var query = coefficients.AsQueryable();
            Coefficient firstCoefficient = null;

            switch (Level)
            {
                case 0:
                    if (query.Any(c => c.Province == "全国" && c.City == null && c.Season == season && Level == 0))
                        firstCoefficient = query.First(c => c.Province == "全国" && c.City == null && c.Season == season);
                    else if (query.Any(c => c.Province == "全国" && c.City == null && c.Season == null && Level == 0))
                        firstCoefficient = query.First(c => c.Province == "全国" && c.City == null && c.Season == null);
                    break;
                case 1:
                    if (query.Any(c => c.Province == province && c.City == null && c.Season == season))
                        firstCoefficient = query.First(c => c.Province == province && c.City == null && c.Season == season);
                    else if (query.Any(c => c.Province == "全国" && c.City == null && c.Season == season))
                        goto default;
                    else if (query.Any(c => c.Province == province && c.City == null && c.Season == null))
                        firstCoefficient = query.First(c => c.Province == province && c.City == null && c.Season == null);
                    else
                        goto default;
                    break;
                case 2:
                    if (query.Any(c => c.Province == province && c.City == null && c.Season == season))
                        firstCoefficient = query.First(c => c.Province == province && c.City == null && c.Season == season);
                    else
                        goto case 1;
                    break;
                case 3:
                    if (query.Any(c => c.Province == province && c.City == city && c.Season == season))
                        firstCoefficient = query.First(c => c.Province == province && c.City == city && c.Season == season);
                    else if (query.Any(c => c.Province == province))
                        goto case 2;
                    else if (query.Any(c => c.Province != province))
                        goto default;
                    break;
                default:
                    if (query.Any(c => c.Province == "全国" && c.City == null && c.Season == season))
                        firstCoefficient = query.First(c => c.Province == "全国" && c.City == null && c.Season == season);
                    else
                        firstCoefficient = query.First(c => c.Province == "全国" && c.City == null && c.Season == null);
                    break;
            }
            if (firstCoefficient != null) coefficient = Decimal.Parse(firstCoefficient.Value);
            return coefficient;
        }

        /// <summary>
        /// 加载指定的Json文件并返回序列化对象。
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="cfg">输出序列化对象</param>
        private void Load(string path,out JsonConfig cfg)
        {
            StreamReader sr = new StreamReader(path);
            string content = sr.ReadToEnd();
            cfg = JsonConvert.DeserializeObject<JsonConfig>(content);
        }
    }
}
