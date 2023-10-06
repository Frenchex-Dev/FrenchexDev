#region Licensing

// Licensing please read LICENSE.md

#endregion

#region Usings

#endregion

namespace Frenchex.Dev.DotnetCore.DotnetCore.Template.Generator.Lib.Domain.Abstractions
{
    public class TemplateGenerator(
        IProjectTemplateGenerator projectTemplateGenerator
    ) : ITemplateGenerator
    {
        public async Task<ITemplateGenerationResult> GenerateAsync(
            ITemplateDefinition definition
          , IGenerationContext  generationContext
          , CancellationToken   cancellationToken = default
        )
        {
            switch (definition)
            {
                case IProjectTemplateDefinition projectTemplateDefinition:
                    var okResult    = new TemplateGenerationOkResult();
                    var errorResult = new TemplateGenerationErrorResult();
                    await projectTemplateGenerator.GenerateProjectTemplateAsync(
                                                                                projectTemplateDefinition
                                                                              , generationContext
                                                                              , okResult
                                                                              , errorResult
                                                                              , cancellationToken);

                    if (errorResult.Errors.Count > 0)
                    {
                        return errorResult;
                    }

                    return okResult;
                default:
                    throw new NotImplementedException(
                                                      definition.GetType()
                                                                .FullName);
            }
        }
    }
}
