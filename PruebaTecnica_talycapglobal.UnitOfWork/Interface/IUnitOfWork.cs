using PruebaTecnica_talycapglobal.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaTecnica_talycapglobal.UnitOfWork.Interface
{
    /// <summary>
    /// interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Interface Book
        /// </summary>
        IBookRepository Book { get; }
        /// <summary>
        /// Interface Authors
        /// </summary>
        IAuthorRepository Authors { get; }
    }
}
