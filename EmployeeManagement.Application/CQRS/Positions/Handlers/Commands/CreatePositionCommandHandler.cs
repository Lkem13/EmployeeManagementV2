using AutoMapper;
using EmployeeManagement.Application.CQRS.Positions.Requests.Commands;
using EmployeeManagement.Application.DataTransferObject.Position.Validators;
using EmployeeManagement.Application.Exceptions;
using EmployeeManagement.Application.Contracts.Persistence;
using EmployeeManagement.Application.Responses;
using EmployeeManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Application.CQRS.Positions.Handlers.Commands
{
    public class CreatePositionCommandHandler : IRequestHandler<CreatePositionCommand, BaseCommandResponse>
    {
        private readonly IPositionRepository _positionRepository;
        private readonly IMapper _mapper;

        public CreatePositionCommandHandler(IPositionRepository positionRepository, IMapper mapper)
        {
            _positionRepository = positionRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreatePositionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreatePositionDTOValidator();
            var validationResult = await validator.ValidateAsync(request.PositionDTO);

            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creating Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var position = _mapper.Map<Position>(request.PositionDTO);

                position = await _positionRepository.AddAsync(position);

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = position.Id;
            }
            
            return response;
        }
    }
}
