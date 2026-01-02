using Spackle.Extensions;

namespace Spackle;

/// <summary>
/// Used by <see cref="RandomNumberGeneratorExtensions"/> when generating arrays of random numbers.
/// </summary>
public enum ValueGeneration
{
	/// <summary>
	/// Generate only unique random numbers.
	/// </summary>
	UniqueValuesOnly,
	/// <summary>
	/// Generate random numbers - duplicates are allowed.
	/// </summary>
	DuplicatesAllowed
}