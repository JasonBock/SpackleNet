# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [13.0.0] - 2024.11.27

### Changed
- Updated to .NET 9. Some types have breaking changes: (issue [#48](https://github.com/JasonBock/SpackleNet/issues/48))
	- `RangeExtensions` is removed
	- `SecureRandom` no longer derives from `Random`

## [12.0.0] - 2023.2.11

### Added
- Put in the `changelog.md` file (issue [#40](https://github.com/JasonBock/SpackleNet/issues/40))
- Added the `AddPairs()` extension method for `IDictionary<,>` (issue [#39](https://github.com/JasonBock/SpackleNet/issues/39))
- Added `Partition()` and `Contains()` to `Range<T>` (issue [#41](https://github.com/JasonBock/SpackleNet/issues/41))
- Added a `Create()` extension method for `Range` (issue [#41](https://github.com/JasonBock/SpackleNet/issues/41))

### Removed
- Obsoleted a number of `Range` extension methods (issue [#41](https://github.com/JasonBock/SpackleNet/issues/41))