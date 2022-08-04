using ATours.Entities.Exceptions;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ATours.WebExceptionPresenter
{
    public class Filters
    {
        public static void Register(MvcOptions opcion)
        {
            opcion.Filters.Add(new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    {typeof(GeneralException), new GeneralExceptionHandler() },
                    {typeof(ValidationException), new ValidationExceptionHandler() }
                }));
        }
    }
}
