using Application.Common;
using Domain.Contracts;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using static Application.Exceptions.Exceptions;

namespace Application.Modules.Users.UseCases.Command;

public class CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher<User> passwordHasher) : IRequestHandler<CreateUserCommand>
{
    private readonly IPasswordHasher<User> _passwordHasher = passwordHasher;

    private readonly IUserRepository _userRepository = userRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);

        if (existingUser is not null)
            throw new ConflitException("Email informado esta em uso!");

        User user = new()
        {
            Name = request.Name,
            Email = request.Email,
            Password = _passwordHasher.HashPassword(null, request.Password)
        };

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}