// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using DotLiquid;
using Microsoft.Extensions.Logging;
using System.Collections.Immutable;


namespace Library.Core;

public class LiquidTemplateProcessor : ITemplateProcessor
{
    private readonly ILogger<LiquidTemplateProcessor> _logger;
    public LiquidTemplateProcessor(ILogger<LiquidTemplateProcessor> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string[] Process(string[] template, IDictionary<string, object> tokens, string[] ignoreTokens = null)
    {
        Hash hash = default;

        try
        {
            if (ignoreTokens != null)
            {
                var dictionary = ImmutableDictionary.CreateBuilder<string, object>();

                foreach (var entry in tokens)
                {
                    if (!ignoreTokens.Contains(entry.Key))
                    {
                        dictionary.Add(entry.Key, entry.Value);
                    }
                }

                hash = Hash.FromDictionary(dictionary);

            }
            else
            {
                hash = Hash.FromDictionary(tokens);
            }

            var liquidTemplate = Template.Parse(string.Join(Environment.NewLine, template));

            return liquidTemplate.Render(hash).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        }
        catch (Exception e)
        {
            _logger.LogError(nameof(LiquidTemplateProcessor));

            throw;
        }
    }

    public string Process(string template, IDictionary<string, object> tokens)
    {
        try
        {
            var hash = Hash.FromDictionary(tokens);

            var liquidTemplate = Template.Parse(template);

            return liquidTemplate.Render(hash);
        }
        catch (Exception e)
        {
            _logger.LogError(nameof(LiquidTemplateProcessor));

            throw;
        }
    }
}

