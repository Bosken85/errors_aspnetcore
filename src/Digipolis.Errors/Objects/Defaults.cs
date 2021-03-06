﻿using System;

namespace Digipolis.Errors.Internal
{
    internal class Defaults
    {
        internal class ErrorMessage
        {
            internal const string Key = "";
            internal const string NullString = "null";
        }

        internal class BaseException
        {
        }

        internal class NotFoundException
        {
            internal const string Title = "Not found.";
            internal const string Code = "NFOUND001";
        }

        internal class UnauthorizedException
        {
            internal const string Title = "Access denied.";
            internal const string Code = "UNAUTH001";
        }

        internal class ValidationException
        {
            internal const string Title = "Bad request.";
            internal const string Code = "UNVALI001";
        }
    }
}
