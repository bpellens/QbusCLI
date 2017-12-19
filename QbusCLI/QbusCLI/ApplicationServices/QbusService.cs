using AutoMapper;
using QbusCLI.Domain;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace QbusCLI.ApplicationServices
{
    class QbusService : IQbusService
    {
        IMapper _mapper;
        IQbusApi _api;

        public QbusService(IQbusApi api, IMapper mapper)
        {
            _api = api;
            _mapper = mapper;
        }

        public LoginServiceResponse Login(LoginServiceRequest request)
        {
            LoginServiceResponse response = new LoginServiceResponse();
            try
            {
                var result = _api.Login(_mapper.Map<Payload<LoginRequest>>(request.Request));
                response.Response = _mapper.Map<LoginViewModel>(result);
            }
            catch(Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public SetStatusServiceResponse SetStatus(SetStatusServiceRequest request)
        {
            SetStatusServiceResponse response = new SetStatusServiceResponse();
            try
            {
                var result = _api.SetStatus(_mapper.Map<Payload<SetStatusRequest>>(request.Request));
                response.Response = _mapper.Map<StatusViewModel>(result);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }

        public GetStatusServiceResponse GetStatus(GetStatusServiceRequest request)
        {
            GetStatusServiceResponse response = new GetStatusServiceResponse();
            try
            {
                var result = _api.GetStatus(_mapper.Map<Payload<GetStatusRequest>>(request.Request));
                response.Response = _mapper.Map<StatusViewModel>(result);
            }
            catch (Exception ex)
            {
                response.Exception = ex;
            }

            return response;
        }
    }
}
