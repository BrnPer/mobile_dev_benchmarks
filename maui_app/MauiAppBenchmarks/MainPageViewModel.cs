using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppBenchmarks.Helpers;
using System.Diagnostics;
using System.Text.Json;

namespace MauiAppBenchmarks;

public partial class MainPageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string timeTakenToParseString;

    [ObservableProperty]
    private bool isParsingBenchmarkLoading;

    [ObservableProperty]
    private string timeTakenToPrimeCalculations;

    [ObservableProperty]
    private bool isPrimeNumberBenchmarkLoading;

    public MainPageViewModel()
    {
    }

    [RelayCommand]
    public async void ParseJSON()
    {
        await Dispatcher.GetForCurrentThread().DispatchAsync(() =>
        {
            IsParsingBenchmarkLoading = true;
            TimeTakenToParseString = "";
        });
        await Task.Delay(250);

        var stopwatch = Stopwatch.StartNew();

        await RunObjectToJson();
        await RunJsonToObject();

        stopwatch.Stop();

        await Dispatcher.GetForCurrentThread().DispatchAsync(() =>
        {
            TimeTakenToParseString = $"{stopwatch.ElapsedMilliseconds} ms";
            IsParsingBenchmarkLoading = false;
        });
    }

    private Task RunObjectToJson()
    {
        for (int i = 0; i <= 1000000; i++)
        {
            ExampleDTO example = new ExampleDTO()
            {
                Id = i,
                Name = "Test",
                Description = $"This is the {i} test",
                Age = i
            };

            var stringSerialized = JsonSerializer.Serialize(example);
        }

        return Task.CompletedTask;
    }

    private Task RunJsonToObject()
    {
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        for (int i = 0; i <= 1000000; i++)
        {

            var stringToDeserialize = String.Format("{{ \"id\": {0}, \"name\": \"Test\", \"description\": \"This is the {0} test\", \"age\": {0} }}", i);
            var objectDeserialized = JsonSerializer.Deserialize<ExampleDTO>(stringToDeserialize, options);
        }

        return Task.CompletedTask;
    }

    [RelayCommand]
    public async void CalculatePrimes()
    {
        await Dispatcher.GetForCurrentThread().DispatchAsync(() =>
        {
            IsPrimeNumberBenchmarkLoading = true;
            TimeTakenToPrimeCalculations = "";
        });
        await Task.Delay(250);

        var stopwatch = Stopwatch.StartNew();

        int calculatePrimesUntil = 100000;
        int maxSecondFloorIteration = (int)Math.Ceiling(calculatePrimesUntil / 2d);
        bool isPrime = true;
        int howManyPrimes = 0;
        for (int i = 0; i <= calculatePrimesUntil; i++)
        {
            for (int j = 2; j <= maxSecondFloorIteration; j++)
            {
                if (i != j && i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime == true)
            {
                howManyPrimes++;
                isPrime = true;
            }
        }

        stopwatch.Stop();

        await Dispatcher.GetForCurrentThread().DispatchAsync(() =>
        {
            TimeTakenToPrimeCalculations = $"{stopwatch.ElapsedMilliseconds} ms";
            IsPrimeNumberBenchmarkLoading = false;
        });
    }
}

public class ExampleDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Age { get; set; }
}