using Microsoft.AspNetCore.Http;
using Projects.Common.Validations;
using Projects.Common.Validations.Exceptions.Global;
using Microsoft.AspNetCore.StaticFiles;
using Projects.Common.Directories;

namespace Projects.Common.Models;

public class MemoryStreamModel
{
    public MemoryStreamModel(string fileName, MemoryStream memoryStream)
    {
        this.FileName = fileName;
        this.MemoryStream = memoryStream;
    }
    public string FileName { get; private set; } = string.Empty;
    public MemoryStream MemoryStream { get; private set; }
}

