using AutoMapper;
using Global.Etik.Application.Common.Contracts.Presentences;
using Global.Etik.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserMV>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserMV> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = (await _repository.GetByIdAsync(request.Id));
            return _mapper.Map<UserMV>(user);
        }
    }
}
