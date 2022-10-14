namespace Mowrer.FSWebster.Shared

module Webster =
    /// <summary>
    /// Calculates the Webster quotient for the given population and the number
    /// of seats it has been allocated.
    /// </summary>
    /// <param name="population">The population of the bloc.</param>
    /// <param name="seats">
    /// The number of seats allocated to this bloc thus far.
    /// </param>
    /// <return>The Webster quotient of the bloc.</return>
    val quotient: int -> int -> float

    /// <summary>
    /// Apportions, across a list of blocs by their population, the given number of
    /// seats according to the Webster/Saint-Lague method.
    /// </summary>
    /// <param name="populations">
    /// The list of populations of the blocs to
    /// distribute seats across.
    /// </param>
    /// <param name="totalSeats">The total number of seats to apportion.</param>
    /// <return>
    /// A list of the number of seats, in order, that each bloc receives.
    /// </return>
    val apportionSeats: int[] -> int -> int[]
