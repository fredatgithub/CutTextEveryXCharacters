using System;
using System.Collections.Generic;

namespace CutTextToXCharacters
{
  public static class StringExtensions
  {
    public static IEnumerable<string> SplitInParts(this string theString, Int32 partLength)
    {
      if (theString == null)
      {
        throw new ArgumentNullException(nameof(theString));
      }

      if (partLength <= 0)
      {
        throw new ArgumentException("Part length has to be positive.", nameof(partLength));
      }

      for (var i = 0; i < theString.Length; i += partLength)
      {
        yield return theString.Substring(i, Math.Min(partLength, theString.Length - i));
      }
    }

    public static IEnumerable<ReadOnlyMemory<char>> SplitInPartsInMemory(this String s, Int32 partLength)
    {
      if (s == null)
        throw new ArgumentNullException(nameof(s));
      if (partLength <= 0)
        throw new ArgumentException("Part length has to be positive.", nameof(partLength));

      for (var i = 0; i < s.Length; i += partLength)
        yield return s.AsMemory().Slice(i, Math.Min(partLength, s.Length - i));
    }

    /// <summary>
    /// Get a string into chunks of small ones.
    /// </summary>
    /// <param name="theString">The source string.</param>
    /// <param name="chunkSize">A number of characters to cut the string.</param>
    /// <returns>A list of strings.</returns>
    public static List<string> GetChunks(string theString, int chunkSize)
    {
      List<string> triplets = new List<string>();
      for (int i = 0; i < theString.Length; i += chunkSize)
      {
        if (i + chunkSize > theString.Length)
        {
          triplets.Add(theString.Substring(i));
        }
        else
        {
          triplets.Add(theString.Substring(i, chunkSize));
        }
      }

      return triplets;
    }

    /// <summary>
    /// Get a string into chunks of small ones.
    /// </summary>
    /// <param name="theString">The source string.</param>
    /// <param name="chunkSize">A number of characters to cut the string.</param>
    /// <returns>A list of strings.</returns>
    public static List<string> GetCorrectChunks(string theString, int chunkSize)
    {
      List<string> result = new List<string>();
      for (int i = 0; i < theString.Length; i += chunkSize)
      {
        if (i + chunkSize > theString.Length)
        {
          result.Add(theString.Substring(i));
        }
        else
        {
          result.Add(theString.Substring(i, chunkSize));
        }
      }

      return result;
    }
  }
}
