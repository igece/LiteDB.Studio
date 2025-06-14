// <file>
//     <copyright see="prj:///doc/copyright.txt"/>
//     <license see="prj:///doc/license.txt"/>
//     <owner name="Mike Krüger" email="mike@icsharpcode.net"/>
//     <version>$Revision$</version>
// </file>

using System;

using ICSharpCode.TextEditor.Document;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ICSharpCode.TextEditor.Util
{
	public class TextUtility
	{
		
		public static bool RegionMatches(IDocument document, int offset, int length, string word)
		{
			if (length != word.Length || document.TextLength < offset + length) {
				return false;
			}
			
			for (int i = 0; i < length; ++i) {
				if (document.GetCharAt(offset + i) != word[i]) {
					return false;
				}
			}
			return true;
		}
		
		public static bool RegionMatches(IDocument document, bool casesensitive, int offset, int length, string word)
		{
			if (casesensitive) {
				return RegionMatches(document, offset, length, word);
			}
			
			if (length != word.Length || document.TextLength < offset + length) {
				return false;
			}
			
			for (int i = 0; i < length; ++i) {
				if (Char.ToUpper(document.GetCharAt(offset + i)) != Char.ToUpper(word[i])) {
					return false;
				}
			}
			return true;
		}
		
		public static bool RegionMatches(IDocument document, int offset, int length, char[] word)
		{
			if (length != word.Length || document.TextLength < offset + length) {
				return false;
			}
			
			for (int i = 0; i < length; ++i) {
				if (document.GetCharAt(offset + i) != word[i]) {
					return false;
				}
			}
			return true;
		}
		
		public static bool RegionMatches(IDocument document, bool casesensitive, int offset, int length, char[] word)
		{
			if (casesensitive) {
				return RegionMatches(document, offset, length, word);
			}
			
			if (length != word.Length || document.TextLength < offset + length) {
				return false;
			}
			
			for (int i = 0; i < length; ++i) {
				if (Char.ToUpper(document.GetCharAt(offset + i)) != Char.ToUpper(word[i])) {
					return false;
				}
			}
			return true;
		}

        public static string ConvertStringToJson(string inputString)
        {
            if (string.IsNullOrWhiteSpace(inputString))
            {
                return JsonConvert.SerializeObject(inputString);
            }

            try
            {
                JToken.Parse(inputString);
                return inputString;
            }
            catch (JsonReaderException)
            {
                return JsonConvert.SerializeObject(inputString);
            }
        }
    }
}
