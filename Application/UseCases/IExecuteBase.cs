using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases;

public interface IExecuteBase
{
    Task Execute(Object request);
}
