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

namespace Global.Etik.Application.Features.Users.Commands.UpdateUsers
{
    public class UpateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IAsyncRepository<User> _repository;
        private readonly IMapper _mapper;

        public UpateUserCommandHandler(IAsyncRepository<User> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var userToUpdate = await _repository.GetByIdAsync(request.Id);

            if (userToUpdate == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _mapper.Map(request, userToUpdate, typeof(UpdateUserCommand), typeof(User));

            await _repository.UpdateAsync(userToUpdate);

            return Unit.Value;
        }
    }
}
