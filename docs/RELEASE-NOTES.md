# Release Notes

## 2.0.0 - 05 August 2021

Breaking changes:
- All Unix time based properties on the contract now use a custom DateTime JSON converter on deserialization.
- Removed `GetStatusResponse.HealthStatusType` property.
- Changed `GetStatusResponse.HealthStatus` property from `string` to `HealthStatusType` enum.

New features:
- (None)

Bug fixes / internal changes:
- Added package dependency `ByteDev.Json.SystemTextJson`.

## 1.0.0 - 29 July 2021

Initial version.
