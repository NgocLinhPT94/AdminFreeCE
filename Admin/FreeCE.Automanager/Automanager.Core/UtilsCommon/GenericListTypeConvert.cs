using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automanager.Core.UtilsCommon
{
    /// <summary>
    ///     <para>1 class cho phép convert dữ liệu từ 1 List thành string có dạng : abc, def, hig và ngược lại.</para>
    /// </summary>
    public class GenericListTypeConvert<T> : TypeConverter
    {
        protected readonly TypeConverter TypeConverter;

        /// <summary>
        ///     Khởi tạo
        /// </summary>
        /// <exception cref="InvalidOperationException">
        ///     Ném ra ngoại lệ khi không tìm thấy kiểu chuyển đổi tương ứng với kiểu dữ
        ///     liệu truyền vào
        /// </exception>
        public GenericListTypeConvert()
        {
            TypeConverter = TypeDescriptor.GetConverter(typeof(T));
            if (TypeConverter == null)
                throw new InvalidOperationException("No type converter exists for type " + typeof(T).FullName);
        }
    }
}
