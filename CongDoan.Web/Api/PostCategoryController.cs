using AutoMapper;
using CongDoan.Model.Models;
using CongDoan.Service;
using CongDoan.Web.Infrastructure.Core;
using CongDoan.Web.Infrastructure.Extensions;
using CongDoan.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CongDoan.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage requestMessage)
        {
            return CreateHttpRequest(requestMessage, () =>
            {
                var categories = this._postCategoryService.GetAll();
                var listPostCategoryVM = Mapper.Map<List<PostCategoryViewModel>>(categories);
                return requestMessage.CreateResponse(HttpStatusCode.OK, listPostCategoryVM);
            });
        }
        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpRequest(requestMessage, () =>
             {
                 if (ModelState.IsValid)
                 {
                     return requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }

                 PostCategory postCategory = new PostCategory();
                 postCategory.UpdatePostCategory(postCategoryViewModel);

                 var result = this._postCategoryService.Add(postCategory);
                 this._postCategoryService.SaveChanges();

                 return requestMessage.CreateResponse(HttpStatusCode.OK, result);
             });
        }
        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage requestMessage, PostCategoryViewModel postCategoryViewModel)
        {
            return CreateHttpRequest(requestMessage, () =>
            {
                if (ModelState.IsValid)
                {
                    return requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }

                PostCategory postCategory = new PostCategory();
                postCategory.UpdatePostCategory(postCategoryViewModel);
                this._postCategoryService.Update(postCategory);
                this._postCategoryService.SaveChanges();

                return requestMessage.CreateResponse(HttpStatusCode.OK);
            });
        }
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage requestMessage, int id)
        {
            return CreateHttpRequest(requestMessage, () =>
             {
                 if (ModelState.IsValid)
                 {
                     return requestMessage.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 var result = this._postCategoryService.Delete(id);
                 this._postCategoryService.SaveChanges();

                 return requestMessage.CreateResponse(HttpStatusCode.OK, result);
             });
        }
    }
}