using System;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using N8T.Infrastructure.App.Dtos;
using N8T.Infrastructure.Auth;

namespace ProductCatalogService.Application.GetDetailOfSpecificProduct
{
    public class GetDetailOfSpecificProductQuery : IRequest<FlatProductDto>, IAuthRequest
    {
        public Guid Id { get; set; }
    }

    public class GetDetailOfSpecificProductValidator : AbstractValidator<GetDetailOfSpecificProductQuery>
    {
        public GetDetailOfSpecificProductValidator()
        {
        }
    }

    public class GetCategoriesAuthzHandler : AuthorizationHandler<GetDetailOfSpecificProductQuery>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, GetDetailOfSpecificProductQuery requirement)
        {
            if (context.User.HasClaim("user_role", "sys_admin") is true)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}
