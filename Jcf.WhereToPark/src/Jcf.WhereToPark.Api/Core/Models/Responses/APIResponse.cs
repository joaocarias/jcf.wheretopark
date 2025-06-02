﻿using Jcf.WhereToPark.Api.Core.Constants;
using System.Net;

namespace Jcf.WhereToPark.Api.Core.Models.Responses
{
    public class APIResponse
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }

        public bool IsSuccess { get; set; } = true;
        public Object? Result { get; set; }
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        public List<string> ErrorMessages { get; set; }

        public void IsOk(Object? result)
        {
            IsSuccess = true;
            Result = result;
            StatusCode = HttpStatusCode.OK;
        }

        public void IsNotFound()
        {
            IsSuccess = false;
            Result = null;
            StatusCode = HttpStatusCode.NotFound;
            ErrorMessages.Add(APIResponseConstants.NOT_FOUND);
        }

        public void IsBadRequest(string messageError)
        {
            IsSuccess = false;
            Result = null;
            StatusCode = HttpStatusCode.BadRequest;
            ErrorMessages.Add(messageError);
        }

        public void IsCreated(Object? result)
        {
            IsSuccess = true;
            Result = result;
            StatusCode = HttpStatusCode.Created;
        }
    }
}
}
