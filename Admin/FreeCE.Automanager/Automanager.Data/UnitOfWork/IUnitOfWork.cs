using System;


namespace Automanager.Data
{
    /// <summary>
    /// Unit Of Work được sử dụng để đảm bảo nhiều hành động như insert, update, delete..
    /// .được thực thi trong cùng một transaction thống nhất.
    /// UnitOfWork đứng ra quản lý toàn bộ các Repository và các transaction trong 1 phiên làm việc
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        //Khai bao cac repository
    }
}
