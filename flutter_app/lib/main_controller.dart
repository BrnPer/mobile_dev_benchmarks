import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:rx_notifier/rx_notifier.dart';

class MainController extends ChangeNotifier {
  RxNotifier<bool> isParsingBenchmarkLoading = RxNotifier(false);
  RxNotifier<String> timeTakenToParseString = RxNotifier("");

  RxNotifier<bool> isPrimeNumberBenchmarkLoading = RxNotifier(false);
  RxNotifier<String> timeTakenToPrimeCalculations = RxNotifier("");

  void parseJson() async {
    isParsingBenchmarkLoading.value = true;
    timeTakenToParseString.value = "";

    await Future.delayed(const Duration(milliseconds: 250));

    var stopwatch = Stopwatch();
    stopwatch.start();

    _runObjectToJson();
    _runJsonToObject();

    stopwatch.stop();

    timeTakenToParseString.value = "${stopwatch.elapsedMilliseconds} ms";
    isParsingBenchmarkLoading.value = false;
  }

  void _runObjectToJson() {
    for (int i = 0; i <= 1000000; i++) {
      ExampleDTO example = ExampleDTO(
          id: i, name: "Test", description: "This is the ${i} test", age: i);
      var stringSerialized = jsonEncode(example);
    }
  }

  void _runJsonToObject() {
    for (int i = 0; i <= 1000000; i++) {
      var stringToDeserialize =
          """{ "id": ${i}, "name": "Test", "description": "This is the ${i} test", "age": ${i} }""";
      var dynamicMap = jsonDecode(stringToDeserialize);
      ExampleDTO.fromJson(dynamicMap);
    }
  }

  void calculatePrimes() async {
    isPrimeNumberBenchmarkLoading.value = true;
    timeTakenToPrimeCalculations.value = "";

    await Future.delayed(const Duration(milliseconds: 250));

    var stopwatch = Stopwatch();
    stopwatch.start();

    int calculatePrimesUntil = 100000;
    int maxSecondFloorIteration = (calculatePrimesUntil / 2).ceil();
    bool isPrime = true;
    int howManyPrimes = 0;
    for (int i = 0; i <= calculatePrimesUntil; i++) {
      for (int j = 2; j <= maxSecondFloorIteration; j++) {
        if (i != j && i % j == 0) {
          isPrime = false;
          break;
        }
      }

      if (isPrime == true) {
        howManyPrimes++;
        isPrime = true;
      }
    }

    stopwatch.stop();

    timeTakenToPrimeCalculations.value = "${stopwatch.elapsedMilliseconds} ms";
    isPrimeNumberBenchmarkLoading.value = false;
  }
}

class ExampleDTO {
  int id;
  String name;
  String description;
  int age;

  ExampleDTO(
      {required this.id,
      required this.name,
      required this.description,
      required this.age});

  factory ExampleDTO.fromJson(Map<String, dynamic> json) {
    return ExampleDTO(
        id: json["id"],
        name: json["name"],
        description: json["description"],
        age: json["age"]);
  }

  Map<String, dynamic> toJson() {
    final Map<String, dynamic> data = new Map<String, dynamic>();
    data['id'] = this.id;
    data['name'] = this.name;
    data['description'] = this.description;
    data['age'] = this.age;
    return data;
  }
}
