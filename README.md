# Mobile Development Frameworks Benchmarks 🚄

This project consists in some benchmarks created using cross-platform mobile app developments frameworks. Currently, the benchmarks are available for:
- Flutter
- .NET MAUI

This project is in a initial phase and doesn't pretend to be a extremely precise scientific experiment. The idea is to just give an overall example of the performance.

## Current Benchmarks

Right now the apps contains 2 benchmakrs:
- <b>JSON Parse</b> - almost every app does some type of JSON parsing for example connecting to an API or storing data in local storage. This benchmark consists in decoding and enconding 1.000.000 times a JSON object.
- <b>Calculate Primes</b> - this benchmark consists in calculating primes until 100.000.

The algorithms are simple and try to be as similar to each other as possible without any type of language optimization.

Feel free to make any PR with some suggestions to improve the code or add support to other cross-platform development framework.

## Results

The following results were executed in a OnePlus 7 📱(Android 12 | Snapdragon 855 | 8GB RAM)

|  | Flutter (3.16.1) | .NET MAUI (8) |
| --------  | -------- | ------- |
| .apk size | 17.9MB | 31.6MB |
| .aab size | 18.0MB | 31.4MB |
| JSON Parse  | 6000ms | 12000ms |
| Calculate Primes | 1900ms | 2900ms |

Date: 29/11/2023

Flutter App:
<img height="600" src="/pictures/flutter_app.jpg">

<br>
<br>
.NET MAUI App:
<img height="600" src="/pictures/maui_app.jpg">

## How to test in your devices
For the <b>Flutter</b> project you just need to have the Flutter SDK (and all the dependencies installed) and go to its directory and run the command:
> flutter build apk --release

<br>
For the <b>.NET MAUI</b> project probably the easy and best solution is to use Visual Studio to do the build.

## Roadmap

- Add support for React Native.
- Add more real-life benchmarks.

Any suggestion feel free to create an issue or make a PR.

Thank you for your time! 😊
