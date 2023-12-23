using AutoMapper;
using BasicMicroserviceApp.Author.Service.Dtos;
using BasicMicroserviceApp.BuildingBlock.Base.Abstractions;
using MediatR;

namespace BasicMicroserviceApp.Author.Service.Features.Queries.GetAllAuthors
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQueryRequest, GetAllAuthorsQueryResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAuthorsQueryHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<GetAllAuthorsQueryResponse> Handle(GetAllAuthorsQueryRequest request, CancellationToken cancellationToken)
        {
            var articles = await _unitOfWork.GetReadRepository<BasicMicroserviceApp.Author.Service.Author.Models.Author>().GetAllAsync();

            return new() { GetAllAuthorsDtos = _mapper.Map<List<GetAllAuthorsDto>>(articles) };
        }
    }
}
