// ImageDisplayHelper.cs
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Gif;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Processing;

public class ImageDisplayHelper
{
    private static IWebHostEnvironment? _env;
    public static void Initialize(IWebHostEnvironment env)
    {
        _env = env;
    }

    public static ImageData GetImageData(string imagesFolder, string currentController, string imagefolder)
    {
        var currentDisplay = currentController.Replace("slide", "", StringComparison.OrdinalIgnoreCase);

        var folders = Directory.GetDirectories(Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/{imagesFolder}/{currentDisplay}"))
                               .Select(folder => Path.GetFileName(folder))
                               .ToList();

        var currentImageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagesFolder, currentDisplay, imagefolder);

        var files = Directory.GetFiles(currentImageFolder, "*.*")
                .Where(file =>
                    !Path.GetFileName(file).StartsWith("background", StringComparison.OrdinalIgnoreCase) &&
                    !Path.GetFileName(file).EndsWith("_thumb.jpg", StringComparison.OrdinalIgnoreCase) &&
                    (Path.GetExtension(file).Equals(".png", StringComparison.OrdinalIgnoreCase) ||
                     Path.GetExtension(file).Equals(".jpg", StringComparison.OrdinalIgnoreCase) ||
                     Path.GetExtension(file).Equals(".gif", StringComparison.OrdinalIgnoreCase) ||
                     Path.GetExtension(file).Equals(".svg", StringComparison.OrdinalIgnoreCase) ||
                     Path.GetExtension(file).Equals(".webp", StringComparison.OrdinalIgnoreCase)))
                .Select(file => $"~/{Path.Combine(imagesFolder, currentDisplay, imagefolder, Path.GetFileName(file)).Replace("\\", "/")}")
                .ToList();



        var thumbnailsPath = currentImageFolder;
        foreach (var file in files)
        {
            thumbnailService.CreateOrRetrieveThumbnail(file, Path.Combine(thumbnailsPath, $"{Path.GetFileNameWithoutExtension(file)}_thumb.jpg"), thumbnailsPath);
        }

        var backgroundImage = GetBackgroundImage(imagesFolder, currentDisplay, imagefolder);

        return new ImageData
        {
            Folders = folders,
            Files = files,
            CurrentDisplay = currentDisplay,
            ImageFolder = imagefolder,
            ThumbnailsPath = thumbnailsPath,
            BackgroundImage = backgroundImage
        };
    }

    private static string GetBackgroundImage(string slideshowsFolder, string currentDisplay, string imagefolder)
    {
        var backgroundImage = $"{slideshowsFolder}/{currentDisplay}/{imagefolder}/background.webp"; // default
        string[] extensions = { ".jpg", ".png", ".webp", ".svg" };
        foreach (var extension in extensions)
        {
            var bgPath = $"{slideshowsFolder}/{currentDisplay}/{imagefolder}/background{extension}";
            if (File.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", bgPath)))
            {
                backgroundImage = bgPath;
                break;
            }
        }

        return backgroundImage;
    }
}

public class ImageData
{
    public List<string> Folders { get; set; }
    public List<string> Files { get; set; }
    public string CurrentDisplay { get; set; }
    public string ImageFolder { get; set; }
    public string ThumbnailsPath { get; set; }
    public string BackgroundImage { get; set; }
}

public class ThumbnailService
{
    public void CreateOrRetrieveThumbnail(string file, string thumbnail, string thumbnailsPath)
    {
        try
        {
            if (!File.Exists(thumbnail))
            {
                CreateThumbnail(file, thumbnailsPath);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating thumbnail: {ex.Message}");
        }
    }
    private IWebHostEnvironment? _env;
    public static void CreateThumbnail(string file, string thumbnailsPath)
    {

        try
        {
            int thumbnailWidth = 800;
            int thumbnailHeight = 800;

            using (var originalImage = Image.Load(Path.Combine(_env.WebRootPath, file.TrimStart('~', '/'))))
            {
                originalImage.Mutate(x => x
                    .Resize(new ResizeOptions
                    {
                        Size = new Size(thumbnailWidth, thumbnailHeight),
                        Mode = ResizeMode.Max
                    }));

                originalImage.Save(Path.Combine(thumbnailsPath, Path.GetFileNameWithoutExtension(file) + "_thumb.jpg"), GetImageFormat(Path.GetExtension(Path.Combine(_env.WebRootPath, file.TrimStart('~')))));
            }
        }
        catch (Exception ex)
        {
            // Handle or log the exception
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    private static IImageEncoder GetImageFormat(string extension)
    {
        return extension.ToLower() switch
        {
            ".png" => new PngEncoder(),
            ".jpg" or ".jpeg" => new JpegEncoder(),
            ".gif" => new GifEncoder(),
            ".bmp" => new BmpEncoder(),
            // Add more formats as needed  
            _ => new JpegEncoder(),// Default to JPEG for unknown extensions
        };
    }
}

