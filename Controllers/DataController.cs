using GroceryShopAPI.Data;
using GroceryShopAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace GroceryShopAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class DataController : ControllerBase
{
    private readonly JsonDataService _jsonDataService;

public DataController(JsonDataService jsonDataService)
{
    _jsonDataService = jsonDataService;
}

[HttpGet("getData")]
public IEnumerable<DailyData> GetDailyData(DateTime fromDate, DateTime toDate)
{
    var allData = _jsonDataService.GetDailyData();

    var filteredData = allData.Where(d => d.Date >= fromDate && d.Date <= toDate);

    return filteredData;
}

}