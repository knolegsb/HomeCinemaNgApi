using AutoMapper;
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
    [RoutePrefix("api/genres")]
    public class GenresController : ApiControllerBase
    {
        private readonly IEntityBaseRepository<Genre> _genreRepository;

        public GenresController(IEntityBaseRepository<Genre> genresRepository, IEntityBaseRepository<Error> _errorsRepository, IUnitOfWork _unitOfWork) : base(_errorsRepository, _unitOfWork)
        {
            _genreRepository = genresRepository;
        }

        [AllowAnonymous]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                var genres = _genreRepository.GetAll().ToList();

                IEnumerable<GenreViewModel> genresVM = Mapper.Map<IEnumerable<Genre>, IEnumerable<GenreViewModel>>(genres);
                response = request.CreateResponse<IEnumerable<GenreViewModel>>(HttpStatusCode.OK, genresVM);

                return response;
            });
        }
    }
}