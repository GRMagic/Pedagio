using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Pedagio.Cadastro.Application.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pedagio.Api
{
    class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                string result;
                switch (error)
                {
                    case FluentValidation.ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonSerializer.Serialize(new ValidationErrorViewModel
                        {
                            Message = "Falha na validação.",
                            Errors = e.Errors.Select(i => new ValidationFailure { 
                                PropertyName = i.PropertyName,
                                ErrorMessage = i.ErrorMessage 
                            })
                        });
                        break;
                    case BusinessException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        result = JsonSerializer.Serialize(new ErrorViewModel { 
                            Code = e.Code,
                            Message = e.Message
                        });
                        break;
                    default:
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        result = JsonSerializer.Serialize(new ErrorViewModel { Message = error.Message });
                        break;
                }
                await response.WriteAsync(result);
            }
        }
    }

    class ProduceResponseTypeModelProvider : IApplicationModelProvider
    {
        public int Order => 3;

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            foreach (ControllerModel controller in context.Result.Controllers)
            {
                foreach (ActionModel action in controller.Actions)
                {
                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ValidationErrorViewModel), StatusCodes.Status400BadRequest));
                    action.Filters.Add(new ProducesResponseTypeAttribute(typeof(ErrorViewModel), StatusCodes.Status500InternalServerError));
                }
            }
        }
    }

    /// <summary>
    /// Detalhes do erro
    /// </summary>
    public class ErrorViewModel
    {
        /// <summary>
        /// Código do erro
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// Mensagens de erro
        /// </summary>
        public string Message { get; set; }
    }

    /// <summary>
    /// Erro de validação de campo
    /// </summary>
    public class ValidationErrorViewModel : ErrorViewModel
    {
        /// <summary>
        /// Lista de erros de validação
        /// </summary>
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }

    /// <summary>
    /// Falha na validação de um campo
    /// </summary>
    public class ValidationFailure
    {
        /// <summary>
        /// Nome do campo
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Descrição da falha
        /// </summary>
        public string ErrorMessage { get; set; }
    }


}
