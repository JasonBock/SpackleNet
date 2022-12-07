* DONE - Remove/obsolete all `RangeExtension` methods as it was a completely wrong idea to do this.
* DONE - Make `Range<T>` have `T` constrained to `INumber<T>` (maybe?)
* DONE - Is there a interface in .NET 7 that enforces equality using `==` and `!=`
* DONE - Add `Partition` to `Range<T>`
* DONE - Add `Contains(Range<T>)` to `Range<T>`. Basically, does the current range "contain" the given range? (1, 5) would contain (2, 4), but would not contain (2, 6)
* DONE - Add a conversion from `System.Range` to `Range<int>` (can that be enforced at compile time, or is that type check a runtime check? Maybe that's just a static method on `Range<T>` ... well, that stinks because we don't want the static on a generic type)