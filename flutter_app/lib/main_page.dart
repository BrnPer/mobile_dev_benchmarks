import 'package:flutter/material.dart';
import 'package:flutter_app/main.dart';
import 'package:flutter_app/main_controller.dart';
import 'package:rx_notifier/rx_notifier.dart';

class MainPage extends StatelessWidget {
  final controller = getIt<MainController>();
  MainPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: AppBar(
          backgroundColor: Theme.of(context).colorScheme.inversePrimary,
          title: const Text("Main Page"),
        ),
        body: RxBuilder(
          builder: (_) => Column(
            mainAxisAlignment: MainAxisAlignment.start,
            crossAxisAlignment: CrossAxisAlignment.center,
            children: [
              const SizedBox(
                height: 50,
              ),
              const Text(
                "Benchmarks",
                style: TextStyle(fontSize: 30),
              ),
              const SizedBox(
                height: 50,
              ),
              Center(
                child: GridView.count(
                  shrinkWrap: true,
                  childAspectRatio: 5,
                  crossAxisCount: 3,
                  mainAxisSpacing: 10,
                  crossAxisSpacing: 10,
                  children: [
                    const Text(
                      "Benchmark JSON parsing",
                      style: TextStyle(fontSize: 15),
                    ),
                    FilledButton.tonal(
                      onPressed: () => controller.parseJson(),
                      child: Text(
                        controller.isParsingBenchmarkLoading.value
                            ? "Loading..."
                            : "Click to benchmark",
                        style: const TextStyle(fontSize: 15),
                      ),
                    ),
                    Text(
                      controller.timeTakenToParseString.value,
                      style: const TextStyle(fontSize: 15),
                    ),
                    Text(
                      controller.isPrimeNumberBenchmarkLoading.value
                          ? "Loading..."
                          : "Benchmark prime numbers",
                      style: const TextStyle(fontSize: 15),
                    ),
                    FilledButton.tonal(
                      onPressed: () => controller.calculatePrimes(),
                      child: const Text(
                        "Click to benchmark",
                        style: TextStyle(fontSize: 15),
                      ),
                    ),
                    Text(
                      controller.timeTakenToPrimeCalculations.value,
                      style: const TextStyle(fontSize: 15),
                    )
                  ],
                ),
              )
            ],
          ),
        ));
  }
}
