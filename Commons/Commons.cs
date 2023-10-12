using FileTransformationTest.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileTransformationTest.Commons
{
    static class Commons
    {
        public static string GetHeaderValue(string field, IEnumerable<Parameters> parameters, string row)
        {
            var param = parameters.FirstOrDefault(parameter => parameter.Field.ToLower() == field.ToLower());
            if (param == null) { return ""; }
            if (param.Start + param.Length > row.Length) { return row.Substring(param.Start).Trim(); }
            return row.Substring(param.Start, param.Length).Trim();
        }

        public static string FormatDate(this string date) 
        { 
            if (date.IsNullOrEmpty()) { return ""; }
            var dateArray = date.Split("/");
            return $"{dateArray[1]}{dateArray[0]}{dateArray[2]}"; 
        }

        public static string FormatTwoDecimals(this string number)
        {
            if (number.IsNullOrEmpty()) { return ""; }
            return $"{double.Parse(number):.2f}";
        }
    }
}
