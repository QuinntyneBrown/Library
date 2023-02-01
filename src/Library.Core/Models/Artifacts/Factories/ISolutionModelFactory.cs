// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core.Models.Artifacts.Factories;

public interface ISolutionModelFactory
{
    SolutionModel CreateWebApi(WebApiProjectReferenceModel webApiProjectReferenceModel);
    SolutionModel CreateLibrary(SolutionReferenceModel solutionReferenceModel);
    SolutionModel CreateWebApi(SolutionReferenceModel solutionReferenceModel);
    SolutionModel ReHydrate(string path);
}

