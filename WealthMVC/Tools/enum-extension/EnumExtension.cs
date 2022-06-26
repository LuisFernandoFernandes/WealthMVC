//using Microsoft.AspNetCore.Mvc.Rendering;
//using System.ComponentModel;
//using System.Reflection;

//namespace WealthMVC.Tools.enum_extension
//{
//    public static class EnumExtension
//    {
//        public static string GetEnumDescription<T>(string value)
//        {
//            Type type = typeof(T);
//            var name = Enum.GetNames(type).Where(f => f.Equals(value, StringComparison.CurrentCultureIgnoreCase)).Select(d => d).FirstOrDefault();

//            if (name == null)
//            {
//                return string.Empty;
//            }

//            var field = type.GetField(name);
//            var customAttribute = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
//            return customAttribute.Length > 0 ? ((DescriptionAttribute)customAttribute[0]).Description : name;
//        }

//        public static IEnumerable<SelectListItem> EnumToSelectList<T>(string tipoCase = null)
//        {
//            return (Enum.GetValues(typeof(T)).Cast<T>().Select(
//                e => new SelectListItem()
//                {
//                    Text = (tipoCase == null ? GetEnumDescription<T>(e.ToString()) : (tipoCase.ToUpper() == "U" ? GetEnumDescription<T>(e.ToString()).ToUpper() : GetEnumDescription<T>(e.ToString()).ToLower())),
//                    Value = e.ToString()
//                })).ToList();
//        }

//        public static string GetDescription(this Enum GenericEnum)
//        {
//            Type genericEnumType = GenericEnum.GetType();
//            MemberInfo[] memberInfo = genericEnumType.GetMember(GenericEnum.ToString());
//            if ((memberInfo != null && memberInfo.Length > 0))
//            {
//                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
//                if ((_Attribs != null && _Attribs.Count() > 0))
//                {
//                    return ((System.ComponentModel.DescriptionAttribute)_Attribs.ElementAt(0)).Description;
//                }
//            }
//            return GenericEnum.ToString();
//        }
//    }
//}
