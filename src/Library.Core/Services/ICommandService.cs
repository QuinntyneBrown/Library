// Copyright (c) Quinntyne Brown. All Rights Reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace Library.Core
{
    public interface ICommandService
    {
        void Start(string command, string workingDirectory = null, bool waitForExit = true);
    }
}

