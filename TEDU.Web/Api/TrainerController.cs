using AutoMapper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TEDU.Model.Models;
using TEDU.Service;
using TEDU.Web.App_Start;
using TEDU.Web.Infrastructure.Core;
using TEDU.Web.Infrastructure.Extensions;
using TEDU.Web.ViewModels;

namespace TEDU.Web.Api
{
    [Authorize]
    [RoutePrefix("api/trainer")]
    public class TrainerController : ApiControllerBase
    {
        private ITrainerService _trainerService;

        public TrainerController(IErrorService errorService, ITrainerService trainerService) : base(errorService)
        {
            this._trainerService = trainerService;
        }

        [HttpDelete]
        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var trainerDb = _trainerService.Get(id);
                    if (trainerDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid Id.");
                    else
                    {
                        _trainerService.Delete(trainerDb);

                        _trainerService.Save();

                        response = request.CreateResponse(HttpStatusCode.OK, true);
                    }
                }

                return response;
            });
        }

        [HttpGet]
        [Route("getlistpaging")]
        public HttpResponseMessage GetListPaging(HttpRequestMessage request, int page, int pageSize,
            string filter = null)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                int totalRow;
                var model = _trainerService.GetAll(page, pageSize, out totalRow, filter);

                var modelVm = Mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerViewModel>>(model);

                var pagedSet = new PaginationSet<TrainerViewModel>
                {
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize),
                    Items = modelVm
                };

                response = request.CreateResponse(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }

        [HttpGet]
        [Route("getlistparent")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var model = _trainerService.GetAll();
                var modelVm = Mapper.Map<IEnumerable<Trainer>, IEnumerable<TrainerViewModel>>(model);
                response = request.CreateResponse(HttpStatusCode.OK, modelVm);
                return response;
            });
        }

        [HttpGet]
        [Route("GetDetails/{id:int}")]
        public HttpResponseMessage GetDetails(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var category = _trainerService.Get(id);

                var categoryVm = Mapper.Map<Trainer, TrainerViewModel>(category);

                response = request.CreateResponse(HttpStatusCode.OK, categoryVm);

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        public HttpResponseMessage Update(HttpRequestMessage request, TrainerViewModel trainerVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var trainerDb = _trainerService.Get(trainerVm.ID);
                    if (trainerDb == null)
                        response = request.CreateErrorResponse(HttpStatusCode.NotFound, "Invalid.");
                    else
                    {
                        trainerDb.UpdateTrainer(trainerVm);
                        _trainerService.Save();
                        response = request.CreateResponse(HttpStatusCode.OK, trainerVm);
                    }
                }

                return response;
            });
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(HttpRequestMessage request, TrainerViewModel trainerVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var trainer = new Trainer();

                    trainer.UpdateTrainer(trainerVm);

                    _trainerService.Create(trainer);

                    _trainerService.Save();

                    // Update view model
                    trainerVm = Mapper.Map<Trainer, TrainerViewModel>(trainer);
                    response = request.CreateResponse(HttpStatusCode.Created, trainerVm);
                }

                return response;
            });
        }
    }
}