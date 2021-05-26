namespace BluePrism.Core.Extensions
{
    /// <summary>
    /// A set of string extensions.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Returns true if both strings are equal in length.
        /// </summary>
        /// <param name="stringOne">The first string.</param>
        /// <param name="stringTwo">The second string.</param>
        /// <returns>True if equal, False otherwise.</returns>
        public static bool IsOfEqualLength(this string stringOne, string stringTwo)
        {
            if(stringTwo == null)
            {
                return false;
            }

            return stringOne.Length == stringTwo.Length;
        }
    }
}
