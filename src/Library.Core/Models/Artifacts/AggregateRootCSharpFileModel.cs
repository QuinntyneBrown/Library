// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Library.Core.Models.Syntax;

namespace Library.Core.Models.Artifacts
{
    public class AggregateRootCSharpFileModel : CSharpFileModel
    {
        public AggregateRootCSharpFileModel(string @namespace, AggregateRootModel model, string directory)
            : base(model.Namespace, model.Name, CSharpFileType.Implementation, directory)
        {

        }

        public AggregateRootModel AggregateRootModel { get; set; }
    }
}

