﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Application.Interfaces;

public interface IUserContextService
{
	long? GetCurrentUserId();
}