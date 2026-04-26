using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Dtos;

public class UserDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
