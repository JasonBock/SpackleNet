namespace Spackle.Extensions;

/// <summary>
/// Specifies the kind of search to do in indexes search.
/// </summary>
public enum IndexesSearch
{
	/// <summary>
	/// Only find unique values
	/// </summary>
	Unique,
	/// <summary>
	/// Find all values, even if their content overlaps.
	/// </summary>
	Overlap
}