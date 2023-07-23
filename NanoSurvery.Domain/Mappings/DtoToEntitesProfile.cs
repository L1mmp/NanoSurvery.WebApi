using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NanoSurvery.Domain.Dtos;
using NanoSurvery.Domain.Entities;

namespace NanoSurvery.Domain.Mappings
{
	public class DtoToEntitesProfile : Profile
	{
		public DtoToEntitesProfile()
		{
			CreateMap<User, UserDto>().ReverseMap();
			CreateMap<Answer, AnswerDto>().ReverseMap();
			CreateMap<Question, QuestionDto >().ForMember(dest => dest.Answers, opt => opt.MapFrom(src => src.Answers));

			CreateMap<Survey, SurveyDto>().ReverseMap();
		}
	}
}
