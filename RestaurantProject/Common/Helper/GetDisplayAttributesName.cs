using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helper
{
  public static  class GetDisplayAttributesName
    {
        //public static string Display<TProperty>(Expression<Func<TProperty>> f)

        //{
        //    var exp = f.Body as MemberExpression;
        //    var property = exp.Expression.Type.GetProperty(exp.Member.Name);
        //    var attr = property?.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
        //    //attr.DisplayName
        //    return attr.DisplayName;
        //}

        public static string Display(PropertyInfo property)
        {
            var attr = property?.GetCustomAttributes(typeof(DisplayNameAttribute), false).FirstOrDefault() as DisplayNameAttribute;
            if (attr !=null) 
            return attr.DisplayName;
            else
                return null;
        }
  
    }
}
