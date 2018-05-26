using CongDoan.Service;
using CongDoan.Web.Infrastructure.Core;
using System.Net.Http;

namespace CongDoan.Web.Api
{
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        public HttpResponseMessage Get(HttpRequestMessage httpRequestMessage)
        {
            return CreateHttpRequest(httpRequestMessage, () =>
            {

                return httpRequestMessage.CreateResponse();
            });
        }


    }
}