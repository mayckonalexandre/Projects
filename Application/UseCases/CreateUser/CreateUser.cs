using Domain.Contracts;
using Domain.Entities;

namespace Application.UseCases.CreateUser;

public class CreateUser(IUserRepository userRepository) : ICreateUser
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task Execute(object request)
    {
        var user = new User
        {
            Id = 1,
            Name = "John Doe",
            Email = "johndoe@example.com",
            Password = "123"
        };

        await _userRepository.AddAsync(user);
    }
}
