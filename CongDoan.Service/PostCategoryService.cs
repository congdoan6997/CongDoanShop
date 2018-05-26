using CongDoan.Data.Infacstructure;
using CongDoan.Data.Repositories;
using CongDoan.Model.Models;
using System.Collections.Generic;

namespace CongDoan.Service
{
    public interface IPostCategoryService
    {
        PostCategory Add(PostCategory postCategory);

        PostCategory Delete(int id);

        void Update(PostCategory postCategory);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public PostCategory Add(PostCategory postCategory)
        {
            return this._postCategoryRepository.Add(postCategory);
        }

        public PostCategory Delete(int id)
        {
            return this._postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return this._postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return this._postCategoryRepository.GetMulti(x => x.ParentID == parentId && x.Status);
        }

        public PostCategory GetById(int id)
        {
            return this._postCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            this._unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            this._postCategoryRepository.Update(postCategory);
            this._postCategoryRepository.Update(postCategory);
        }
    }
}