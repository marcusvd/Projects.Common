
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.StaticFiles;
using Projects.Common.BuiltInTypesTasks.DateTimeTasks;
using Projects.Common.Models;
using Projects.Common.Validations;
using Projects.Common.Validations.Exceptions.Global;


namespace Projects.Common.Directories;

public class DirectoriesFilesWorker
{
    public static async Task<List<string>> CopyFilesNewNameForExistingFile(string fullpath, IFormFileCollection files, bool overrideFile = false)
    {
        var saved = new List<string>();

        foreach (var file in files)
        {
            var filePath = PathCombine(fullpath, file.FileName);

            // filePath = NewNameForExistingFile(filePath);


            if (!overrideFile)
                filePath = NewNameForExistingFile($@"{fullpath}\{file.FileName}");
            else
                filePath = $@"{fullpath}\{file.FileName}";

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            saved.Add(filePath);
        }

        return saved;
    }
    public static async Task<string> CopySingleFileNewNameForExistingFile(string fullpath, FormFile file, bool overrideFile = false)
    {
        string filePath;

        if (!overrideFile)
            filePath = NewNameForExistingFile($@"{fullpath}\{file.FileName}");
        else
            filePath = $@"{fullpath}\{file.FileName}";

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return filePath;
    }
    public static DirectoryInfo CreateFolderUpload(string newFolder)
    {
        var currentFolderPath = Directory.GetCurrentDirectory();
        var uploadFolder = "external";

        if (!string.IsNullOrEmpty(newFolder))
            uploadFolder = PathCombine(uploadFolder, newFolder);

        var fullPath = PathCombine(currentFolderPath, uploadFolder);

        return CreateFolder(fullPath);
    }
    public static async Task<List<string>> GetAllFilesFromPath(string path)
    {
        AssertionConcern.AssertArgumentNotEmpty(path, Errors.ArgumentWasEmpty);
        return await Task.FromResult(Directory.GetFiles(path).ToList());
    }
    private static DirectoryInfo CreateFolder(string fullPath) => Directory.CreateDirectory(fullPath);
    private static string PathCombine(string baseFolder, string subFolder) => Path.Combine(baseFolder, subFolder);
    private static string NewNameForExistingFile(string oldName)
    {
        string result = oldName;

        AssertionConcern.AssertArgumentNotEmpty(oldName, Errors.ArgumentWasEmpty);

        if (File.Exists(oldName))
        {
            string directory = Path.GetDirectoryName(oldName) ?? string.Empty;
            string timeToName = DateTimeTasks.BasedDateTimeFileName();
            // string timeToName = $@"{DateTimeTasksManagement.BasedDateTimeFileName_DD_MM_YYYY()}.{DateTimeTasksManagement.BasedDateTimeFileName()}";
            string extension = Path.GetExtension(oldName);
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(oldName);
            return PathCombine(directory, $"{fileNameWithoutExtension}_{timeToName}_{extension}");

        }

        return result;
    }
    private static bool IsFileExist(string filePath) => File.Exists(filePath);
    public static async Task<List<MemoryStreamModel>> CopyMultFIlesToMemory(string filesPath)
    {
        var memoryStreams = new List<MemoryStreamModel>();

        AssertionConcern.AssertArgumentNotNull(memoryStreams, Errors.ObjectWasNull);

        try
        {
            AssertionConcern.AssertArgumentNotEmpty(filesPath, Errors.ObjectWasNull);

            var files = await GetAllFilesFromPath(filesPath);

            foreach (var file in files)
            {
                // var memory = new MemoryStream();

                // if (IsFileExist(file))
                // {
                //     await using (var fileStream = File.OpenRead(file))
                //     {
                //         fileStream.CopyTo(memory);
                //     }
                //     memory.Position = 0;
                // }
                memoryStreams.AddRange(await CopySingleFileToMemory(file));

                // var name = Path.GetFileName(file);

                // memoryStreams.Add(new MemoryStreamModel(name, memory));
            }

        }

        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidDataException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return memoryStreams;
    }
    public async static Task<MemoryStreamModel> CopySingleFileToMemory(string file)
    {
        var memory = new MemoryStream();

        if (IsFileExist(file))
        {
            await using (var fileStream = File.OpenRead(file))
            {
                fileStream.CopyTo(memory);
            }
            memory.Position = 0;
        }

        var name = Path.GetFileName(file);


        return new MemoryStreamModel(name, memory);
    }

}

