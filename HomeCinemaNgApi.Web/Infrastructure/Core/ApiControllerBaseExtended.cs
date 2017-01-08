using HomeCinemaNgApi.Data.Infrastructure;
using HomeCinemaNgApi.Data.Repositories;
using HomeCinemaNgApi.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace HomeCinemaNgApi.Web.Infrastructure.Core
{
    public class ApiControllerBaseExtended : ApiController
    {
        protected List<Type> _requiredRepositories;

        protected readonly IDataRepositoryFactory _dataRepositoryFactory;
        protected IEntityBaseRepository<Error> _errorsRepository;
        protected IEntityBaseRepository<Movie> _moviesRepository;
        protected IEntityBaseRepository<Rental> _rentalsRepository;
        protected IEntityBaseRepository<Stock> _stocksRepository;
        protected IEntityBaseRepository<Customer> _customersRepository;
        protected IUnitOfWork _unitOfWork;

        private HttpRequestMessage RequestMessage;

        public ApiControllerBaseExtended(IDataRepositoryFactory dataRepositoryFactory, IUnitOfWork unitOfWork)
        {
            _dataRepositoryFactory = dataRepositoryFactory;
            _unitOfWork = unitOfWork;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage request, List<Type> repos, Func<HttpResponseMessage> function)
        {
            HttpResponseMessage response = null;

            try
            {
                RequestMessage = request;
                InitRepositories(repos);
                response = function.Invoke();
            }
            catch (DbUpdateException ex)
            {
                LogError(ex);
                response = request.CreateResponse(System.Net.HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = request.CreateResponse(System.Net.HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }

        private void LogError(Exception ex)
        {
            try
            {
                Error _error = new Error()
                {
                    Message = ex.Message,
                    StackTrace = ex.StackTrace,
                    DateCreated = DateTime.Now
                };

                _errorsRepository.Add(_error);
                _unitOfWork.Commit();
            }
            catch { }
        }

        private void InitRepositories(List<Type> entities)
        {
            _errorsRepository = _dataRepositoryFactory.GetDataRepository<Error>(RequestMessage);

            if (entities.Any(e => e.FullName == typeof(Movie).FullName))
            {
                _moviesRepository = _dataRepositoryFactory.GetDataRepository<Movie>(RequestMessage);
            }

            if (entities.Any(e => e.FullName == typeof(Rental).FullName))
            {
                _rentalsRepository = _dataRepositoryFactory.GetDataRepository<Rental>(RequestMessage);
            }
        }
    }
}