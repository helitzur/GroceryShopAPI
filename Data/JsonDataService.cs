using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using GroceryShopAPI.Models;
using Microsoft.AspNetCore.Hosting;

namespace GroceryShopAPI.Data;

public class JsonDataService
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    private readonly string _jsonFilePath;

    public JsonDataService(IWebHostEnvironment webHostEnvironment)
    {
        _webHostEnvironment = webHostEnvironment;
        _jsonFilePath = Path.Combine(_webHostEnvironment.ContentRootPath, "data.json");
    }

    public IEnumerable<DailyData> GetDailyData()
    {
        using (var jsonFileReader = File.OpenText(_jsonFilePath))
        {
            var jsonData = jsonFileReader.ReadToEnd();
            return JsonSerializer.Deserialize<IEnumerable<DailyData>>(jsonData);
        }
    }
}
