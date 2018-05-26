using CongDoan.Data.Infacstructure;
using CongDoan.Data.Repositories;
using CongDoan.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongDoan.Service
{
    public interface IErrorService
    {
        Error Create(Error error);
        void SaveChanges();
    }
    public class ErrorService : IErrorService
    {
        IErrorRepository _errorRepository;
        IUnitOfWork _unitOfWork;
        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }
        public Error Create(Error error)
        {
            return this._errorRepository.Add(error);
        }

        public void SaveChanges()
        {
            this._unitOfWork.Commit();
        }
    }
}
