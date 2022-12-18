using AutoMapper;
using Global.Etik.Application.Common.Contracts.Presentences;
using Global.Etik.Application.Exceptions;
using Global.Etik.Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Global.Etik.Application.Features.Users.Commands.DeleteUsers
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public DeleteUserHandler(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userToDelete = await _repository.GetByIdAsync(request.Id);

            if (userToDelete == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            await _repository.DeleteAsync(userToDelete);

            return Unit.Value;
        }
    }
}
