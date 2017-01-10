using AutoMapper;
using HomeCinemaNgApi.Data.Extensions;
using HomeCinemaNgApi.Data.Infrastructure;
using HomeCinemaNgApi.Data.Repositories;
using HomeCinemaNgApi.Entities;
using HomeCinemaNgApi.Web.Infrastructure.Core;
using HomeCinemaNgApi.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HomeCinemaNgApi.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [RoutePrefix("api/stocks")]
    public class StocksController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Stock> _stocksRepository;

        public StocksController(IEntityBaseRepository<Stock> stocksRepository, IEntityBaseRepository<Error> _errosRepository, IUnitOfWork _unitOfWork) : base(_errosRepository, _unitOfWork)
        {
            _stocksRepository = stocksRepository;
        }

        [Route("movie/{id:int}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            IEnumerable<Stock> stocks = null;

            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                stocks = _stocksRepository.GetAvailableItems(id);
                IEnumerable<StockViewModel> stockVM = Mapper.Map<IEnumerable<Stock>, IEnumerable<StockViewModel>>(stocks);

                response = request.CreateResponse<IEnumerable<StockViewModel>>(HttpStatusCode.OK, stockVM);

                return response;
            });
        }
    }
}