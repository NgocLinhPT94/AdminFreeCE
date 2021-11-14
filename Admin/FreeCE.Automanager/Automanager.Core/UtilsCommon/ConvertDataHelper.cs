using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;

namespace Automanager.Core.UtilsCommon
{
    public static class ConvertDataHelper
    {
        //Lấy ra kiểu chuyển đổi. Mục đích kiểm tra kiểu dữ liệu truyền vào có nằm
        //trong list<int>, list<decima>, list<string>
        //// <summary>
        ///     Lấy ra kiểu chuyển đổi
        /// </summary>
        /// <param name="type">Kiểu</param>
        public static TypeConverter GetTypeConverter(Type type)
        {
            TypeConverter result;

            if (type == typeof(List<int>))
                result = new GenericListTypeConvert<int>();
            else if (type == typeof(List<decimal>))
                result = new GenericListTypeConvert<decimal>();
            else if (type == typeof(List<string>))
                result = new GenericListTypeConvert<string>();
            else
                result = TypeDescriptor.GetConverter(type);

            return result;
        }

        /// <summary>
        ///     Chuyển đổi 1 giá trị thành 1 kiểu khác
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <param name="destinationType">Kiểu dữ liệu mới cần chuyển đổi</param>
        /// <returns>Giá trị đã chuyển đổi</returns>
        public static object To(this object value, Type destinationType)
        {
            return To(value, destinationType, CultureInfo.InvariantCulture);
        }
        /// <summary>
        ///     Chuyển đổi 1 giá trị thành 1 kiểu khác
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <param name="destinationType">Kiểu dữ liệu mới cần chuyển đổi</param>
        /// <param name="culture">Culture</param>
        /// <returns>Giá trị đã chuyển đổi</returns>
        public static object To(this object value, Type destinationType, CultureInfo culture)
        {
            object result = null;
            if (value != null)
            {
                var sourceType = value.GetType();
                var destinationConverter = GetTypeConverter(destinationType);
                var sourceConverter = GetTypeConverter(sourceType);

                if (destinationConverter != null && destinationConverter.CanConvertFrom(value.GetType()))
                    result = destinationConverter.ConvertFrom(null, culture, value);
                else if (sourceConverter != null && sourceConverter.CanConvertTo(destinationType))
                    result = sourceConverter.ConvertTo(null, culture, value, destinationType);
                else if (destinationType.IsEnum && value is int)
                    result = Enum.ToObject(destinationType, (int)value);
                else if (!destinationType.IsInstanceOfType(value))
                    result = Convert.ChangeType(value, destinationType, culture);
                else
                    result = value;
            }
            return result;
        }

        /// <summary>
        ///     Chuyển đổi 1 giá trị thành 1 kiểu khác
        /// </summary>
        /// <param name="value">Giá trị cần chuyển đổi</param>
        /// <typeparam name="T">Kiểu dữ liệu mới cần chuyển đổi</typeparam>
        /// <returns>Giá trị đã chuyển đổi</returns>
        public static T To<T>(this object value)
        {
            return (T)To(value, typeof(T));
        }
    }

}
