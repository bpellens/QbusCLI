using AutoMapper;
using QbusCLI.Domain;
using QbusCLI.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QbusCLI.Infrastructure
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<LoginInputModel, Payload<LoginRequest>>()
                .ForMember(dest => dest.Value, m => m.MapFrom(src => new LoginRequest() { Username = src.Username, Password = src.Password }))
                .ForMember(dest => dest.Type, m => m.UseValue<PayloadType>(PayloadType.Login));

            CreateMap<Payload<LoginResponse>, LoginViewModel>()
                .ForMember(dest => dest.IsAuthenticated, m => m.MapFrom(src => src.Value.Response))
                .ForMember(dest => dest.SessionId, m => m.MapFrom(src => src.Value.Id));

            CreateMap<SetStatusInputModel, Payload<SetStatusRequest>>()
                .ForMember(dest => dest.Value, m => m.MapFrom(src => new SetStatusRequest() { Channel = src.Output, Values = new List<int>() { src.Value } }))
                .ForMember(dest => dest.Type, m => m.UseValue<PayloadType>(PayloadType.SetStatus));

            CreateMap<Payload<SetStatusResponse>, StatusViewModel>()
                .ForMember(dest => dest.Output, m => m.MapFrom(src => src.Value.Channel))
                .ForMember(dest => dest.Value, m => m.MapFrom(src => src.Value.Values.FirstOrDefault()));

            CreateMap<GetStatusInputModel, Payload<SetStatusRequest>>()
                .ForMember(dest => dest.Value, m => m.MapFrom(src => new GetStatusRequest() { Channel = src.Output }))
                .ForMember(dest => dest.Type, m => m.UseValue<PayloadType>(PayloadType.GetStatus));

            CreateMap<Payload<GetStatusResponse>, StatusViewModel>()
                .ForMember(dest => dest.Output, m => m.MapFrom(src => src.Value.Channel))
                .ForMember(dest => dest.Value, m => m.MapFrom(src => src.Value.Values.FirstOrDefault()));

        }
    }
}
