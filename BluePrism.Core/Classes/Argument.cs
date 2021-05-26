using System;
using System.Collections.Generic;
using System.Linq;

namespace BluePrism.Core.Classes
{
    /// <summary>
    /// Static helper class to provide <see cref="Argument"/> related validations.
    /// </summary>
    public static class Argument
    {
        /// <summary>
        /// Checks whether an object is not null, throws otherwise.
        /// </summary>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="param">The actual object.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="param"/> is null.</exception>
        public static void IsNotNull(string paramName, object param)
        {
            if (param == null)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Checks whether a collection is not null or not empty, throws otherwise.
        /// </summary>
        /// <typeparam name="T">The collection type.</typeparam>
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="param">The actual object.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="param"/> is null or empty.</exception>
        public static void IsNotNullOrEmpty<T>(string paramName, IEnumerable<T> param)
        {
            Argument.IsNotNull(paramName, param);

            if (param.Count() == 0)
            {
                throw new ArgumentNullException(paramName);
            }
        }

        /// <summary>
        /// Checks whether a string is not null, not empty, and not white space, throws otherwise.
        /// </summary>        
        /// <param name="paramName">The name of the parameter.</param>
        /// <param name="param">The actual object.</param>
        /// <exception cref="ArgumentNullException">Thrown if <paramref name="param"/> is null or white space.</exception>
        public static void IsNotNullOrEmptyOrWhiteSpace(string paramName, string param)
        {
            Argument.IsNotNull(paramName, param);

            if(param.Trim() == string.Empty)
            {
                throw new ArgumentNullException(paramName);
            }
        }
    }
}
