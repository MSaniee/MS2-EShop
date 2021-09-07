﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MS2EShop.Application.Dtos;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace MS2EShop.WebFramework.API.StartupClassConfigurations.Swagger
{
    public static class SwaggerConfigurationExtensions
    {
        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerExamples();
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });

                options.TagActionsBy(api => new[] { api.GroupName });
                options.EnableAnnotations();
                options.ExampleFilters();

                //کد مربوط به اضافه کردن داکیومنت
                var xmlDocPath = Path.Combine(AppContext.BaseDirectory, "TakSizeAPI.xml");
                //show controller XML comments like summary
                options.IncludeXmlComments(xmlDocPath, true);

                //options.DescribeAllEnumsAsStrings();

                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "TakSizeApi-v1", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo() { Title = "TakSizeApi-v2", Version = "v2" });

                #region Versioning

                // Remove version parameter from all Operations
                options.OperationFilter<RemoveVersionParameters>();

                //set version "api/v{version}/[controller]" from current swagger doc verion
                options.DocumentFilter<SetVersionInPaths>();

                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    if (!apiDesc.TryGetMethodInfo(out MethodInfo methodInfo)) return false;

                    var versions = methodInfo.DeclaringType
                        .GetCustomAttributes<ApiVersionAttribute>(true)
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });

                #endregion Versioning
            });

            services.AddSwaggerExamplesFromAssemblyOf(typeof(BaseDto<,>));
        }

        public static void UseSwaggerAndUI(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.DocExpansion(DocExpansion.None);
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "TakSizeApi-v1");
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "TakSizeApi-v2");
            });
        }
    }
}
