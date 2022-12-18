using AutoMapper;
using Global.Etik.Application.Common.Contracts.Presentences;
using Global.Etik.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Queries.ListUsers
{
    public class ListUsersHandler : IRequestHandler<ListUsersQuery, List<ListUsersMV>>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public ListUsersHandler(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<List<ListUsersMV>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.ListAllAsync();
            return _mapper.Map<List<ListUsersMV>>(users);
        }
    }
}
