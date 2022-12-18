using AutoMapper;
using Global.Etik.Application.Common.Contracts.Presentences;
using Global.Etik.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Commands.CreateUsers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            user = await _repository.AddAsync(user);
            return user.Id;
        }
    }
}
