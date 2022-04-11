using System.Collections.Generic;
using System.Linq;

namespace GEmojiSharp
{
    /// <summary>
    /// Extension methods for working with emojis.
    /// </summary>
    public static class EmojiExtensions
    {
        private const char Colon = ':';

        /// <summary>
        /// Gets the emoji associated with the alias, or <see cref="GEmoji.Empty"/> if the alias is not found.
        /// </summary>
        /// <param name="alias">The name uniquely referring to an emoji.</param>
        /// <returns>The emoji.</returns>
        public static GEmoji GetEmoji(this string alias)
        {
            return Emoji.Get(alias);
        }

        /// <summary>
        /// Gets the raw Unicode <c>string</c> of the emoji associated with the alias.
        /// </summary>
        /// <param name="alias">The name uniquely referring to an emoji.</param>
        /// <returns>The raw Unicode <c>string</c>.</returns>
        public static string RawEmoji(this string alias)
        {
            return Emoji.Raw(alias);
        }

        /// <summary>
        /// Gets the alias of the emoji represented by the raw Unicode <c>string</c>.
        /// </summary>
        /// <param name="raw">The raw Unicode <c>string</c> of the emoji.</param>
        /// <returns>The name uniquely referring to the emoji.</returns>
        public static string EmojiAlias(this string raw)
        {
            return Emoji.Alias(raw);
        }

        /// <summary>
        /// Replaces emoji aliases with raw Unicode strings.
        /// </summary>
        /// <param name="text">A text with emoji aliases.</param>
        /// <returns>The emojified text.</returns>
        /// <example>
        /// <code>
        /// "it's raining :cat:s and :dog:s!".Emojify(); // "it's raining 🐱s and 🐶s!"
        /// </code>
        /// </example>
        public static string Emojify(this string text)
        {
            return Emoji.Emojify(text);
        }

        /// <summary>
        /// Replaces raw Unicode strings with emoji aliases.
        /// </summary>
        /// <param name="text">A text with raw Unicode strings.</param>
        /// <returns>The demojified text.</returns>
        /// <example>
        /// <code>
        /// "it's raining 🐱s and 🐶s!".Demojify(); // "it's raining :cat:s and :dog:s!"
        /// </code>
        /// </example>
        public static string Demojify(this string text)
        {
            return Emoji.Demojify(text);
        }

        /// <summary>
        /// Returns emojis that match the <see cref="GEmoji.Description"/>, <see cref="GEmoji.Category"/>, <see cref="GEmoji.Aliases"/> or <see cref="GEmoji.Tags"/>.
        /// </summary>
        /// <param name="value">The value to search for.</param>
        /// <returns>A list of emojis.</returns>
        public static IEnumerable<GEmoji> FindEmojis(this string value)
        {
            return Emoji.Find(value);
        }

        /// <summary>
        /// Gets the first alias of the emoji.
        /// </summary>
        /// <param name="emoji">The emoji.</param>
        /// <returns>The first name uniquely referring to the emoji.</returns>
        public static string Alias(this GEmoji emoji)
        {
            return emoji?.Aliases.FirstOrDefault().PadAlias() ?? string.Empty;
        }

        internal static string TrimAlias(this string alias)
        {
            return alias.TrimStart(Colon).TrimEnd(Colon);
        }

        internal static string PadAlias(this string alias)
        {
            if (string.IsNullOrEmpty(alias)) return string.Empty;

            return Colon + alias.TrimAlias() + Colon;
        }
    }
}
