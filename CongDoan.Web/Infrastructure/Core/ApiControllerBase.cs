using CongDoan.Model.Models;
using CongDoan.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CongDoan.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        IErrorService _errorService;
        public ApiControllerBase(IErrorService errorService)
        {
            this._errorService = errorService;
        }
        protected HttpResponseMessage CreateHttpRequest(HttpRequestMessage httpRequestMessage, Func<HttpResponseMessage> func)
        {
            HttpResponseMessage httpResponseMessage = null;
            try
            {
                httpResponseMessage = func.Invoke();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{ eve.Entry.State}\" has the following validation errors:");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"");
                    }
                }
                LogError(e);
                httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest, e.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                httpResponseMessage = httpRequestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return httpResponseMessage;
        }
        private void LogError(Exception ex)
        {
            try
            {
                var error = new Error()
                {
                    CreateDate = DateTime.Now,
                    Message = ex.Message,
                    StackTrace = ex.StackTrace
                };
                this._errorService.Create(error);
                this._errorService.SaveChanges();


            }
            catch 
            {

                //throw;
            }
        }

    }
}
