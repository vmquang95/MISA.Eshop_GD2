using System;

namespace MISA.EShop.Core.Entities
{
    /// <summary>
    /// kế thừa class Attribute để định dạng cho thuộc tính key,unique,requiced,...
    /// key:khóa
    /// unique: không trùng lặp
    /// requiced: không null.
    /// </summary>
    internal class Unique : Attribute
    {
    }
}