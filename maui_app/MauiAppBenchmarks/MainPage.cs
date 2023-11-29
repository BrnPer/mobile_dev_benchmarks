using CommunityToolkit.Maui.Markup;
using MauiAppBenchmarks.Helpers;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MauiAppBenchmarks;

public class MainPage : BasePage<MainPageViewModel>
{
    public MainPage(MainPageViewModel viewModel) : base(viewModel)
    {

    }
    public override void Build()
    {
        Content = new VerticalStackLayout
        {
            BackgroundColor = Color.FromRgb(255, 255, 255),
            Children = {
                new Label()
                .Text("Benchmarks")
                .Font(size:30)
                .Center()
                .Margin(30)
                .TextColor(Color.FromRgb(0,0,0)),

                new Grid()
                {
                    ColumnDefinitions = Columns.Define(Stars(2), Star, Star),
                    ColumnSpacing = 30,
                    RowSpacing = 30,
                    RowDefinitions = Rows.Define(Auto, Star),
                    Children =
                    {
                        new Label()
                            .Text("Benchmark JSON parsing")
                            .Center()
                            .Row(0)
                            .Column(0)
                            .TextColor(Color.FromRgb(0,0,0)),

                        new Button()
                            .Center()
                            .Bind(Button.TextProperty, static (MainPageViewModel vm) => vm.IsParsingBenchmarkLoading, convert: (bool loading) => loading == true ? "Loading...": "Click to benchmark")
                            .Bind(Button.IsEnabledProperty,  static (MainPageViewModel vm) => vm.IsParsingBenchmarkLoading, convert: (bool loading)=> !loading)
                            .BindCommand(static (MainPageViewModel vm)=> vm.ParseJSONCommand)
                            .Row(0)
                            .Column(1)
                            .TextColor(Color.FromRgb(0,0,0)),


                        new Label()
                            .Center()
                            .Bind(Label.TextProperty, static (MainPageViewModel vm)=> vm.TimeTakenToParseString, mode: BindingMode.OneWay)
                            .Row(0)
                            .Column(2)
                            .TextColor(Color.FromRgb(0,0,0)),

                        new Label()
                            .Text("Benchmark prime numbers")
                            .Center()
                            .Row(1)
                            .Column(0)
                            .TextColor(Color.FromRgb(0,0,0)),

                        new Button()
                            .Center()
                            .Bind(Button.TextProperty, static (MainPageViewModel vm) => vm.IsPrimeNumberBenchmarkLoading, convert: (bool loading) => loading == true ? "Loading...": "Click to benchmark")
                            .Bind(Button.IsEnabledProperty,  static (MainPageViewModel vm) => vm.IsPrimeNumberBenchmarkLoading, convert: (bool loading)=> !loading)
                            .BindCommand(static (MainPageViewModel vm)=> vm.CalculatePrimesCommand)
                            .Row(1)
                            .Column(1),

                        new Label()
                            .Center()
                            .Bind(Label.TextProperty, static (MainPageViewModel vm)=> vm.TimeTakenToPrimeCalculations, mode: BindingMode.OneWay)
                            .Row(1)
                            .Column(2)
                            .TextColor(Color.FromRgb(0,0,0)),
                    }
                }.Center(),
            }
        };
    }
}