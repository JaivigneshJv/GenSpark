using RequestTrackerDALLibrary;
using RequestTrackerModelLibrary;

namespace RequestTrackerBLLibrary
{
    public interface IRequestBL
    {
        Task<Request> AddRequest(Request request);
        Task<Request> UpdateRequest(Request request, String requestStatus);
        Task<Request> GetRequest(int requestNumber);
        Task<IList<Request>> GetAllRequests();
    }

    public class RequestBL : IRequestBL
    {
        private readonly IRepository<int, Request> _requestRepository;

        public RequestBL()
        {
            _requestRepository = new RequestRepository(new RequestTrackerContext());
        }

        public async Task<Request> AddRequest(Request request)
        {
            return await _requestRepository.Add(request);
        }

        public async Task<Request> UpdateRequest(Request request, String requestStatus)
        {
            request.RequestStatus = requestStatus;
            return await _requestRepository.Update(request);
        }

        public async Task<Request> GetRequest(int requestNumber)
        {
            return await _requestRepository.Get(requestNumber);
        }

        public async Task<IList<Request>> GetAllRequests()
        {
            return await _requestRepository.GetAll();
        }
    }
}
