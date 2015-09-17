//Courtesy of www.steffeninf.ch
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quarks.StringExtensions {

    internal static partial class StringExtension {

        //Public Extension Methods

        /// <summary>Converts accented characters into non-accented ones (e.g. "é" -&gt; "e", "ä" -&gt; "ae", "Ä" -&gt; "Ae" or "AE" (depends whether the neighboring 
        /// characters are upper-case letters or not). A possible usage is to create login names or email addresses based on first- and last name. This
        /// overload includes sign conversion (e.g. "©" -&gt; "(C)"). Unknown characters are not converted and returned the same way. To remove all unsupported
        /// characters use in conjunction with extension method RemoveUnwantedChars(..).</summary>
        /// <param name="text">The text where accented characters should be normalized.</param>
        /// <returns>Returns a string without any accents, e.g. "élève" becomes "eleve".</returns>
        /// <exception cref="System.NullReferenceException">Simulates instance method behavior, if a method is called on a NULL instance, a NullReferenceException is thrown.</exception>
        public static String ConvertAccents(this String text) {
            return ConvertAccents(text, false);
        }

        /// <exception cref="System.NullReferenceException">Simulates instance method behavior, if a method is called on a NULL instance, a NullReferenceException is thrown.</exception>
        public static String ConvertAccents(this String text, Boolean noSignConversion) {
            //Throw a NullReferenceException to simulate instance-method behavior
            if (null == text) throw new NullReferenceException();
            //Return unchanged if empty
            if (String.IsNullOrEmpty(text)) return text;
            //Change all accented chars
            Char[] myCharArray = text.ToCharArray();
            StringBuilder myResult = new StringBuilder(text.Length);
            for (Int32 i = 0; i <= myCharArray.Length - 1; i++) {
                Char myChar = myCharArray[i];
                //Append normal chars directly
                if (((myChar >= 'a') && (myChar <= 'z')) || ((myChar >= 'A') && (myChar <= 'Z')) || ((myChar >= '0') && (myChar <= '9'))) {
                    myResult.Append(myChar);
                    continue;
                }
                //Append other chars through method logic
                AppendConvertedChar(myResult, myChar, i, myCharArray, !noSignConversion);
            }
            return myResult.ToString();
        }

        //Private Methods

        private static void AppendConvertedChar(StringBuilder aResult, Char aChar, Int32 anIndex, Char[] aCharArray, Boolean convertSigns) {
            switch (aChar) {
                //Append most common German substitutes
                case 'ä':
                    aResult.Append("ae");
                    return;
                case 'ö':
                    aResult.Append("oe");
                    return;
                case 'ü':
                    aResult.Append("ue");
                    return;
                case 'ß':
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("SS");
                    } else {
                        aResult.Append("ss");
                    }
                    return;
                case 'Ä':
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("AE");
                    } else {
                        aResult.Append("Ae");
                    }
                    return;
                case 'Ö':
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("OE");
                    } else {
                        aResult.Append("Oe");
                    }
                    return;
                case 'Ü':
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("UE");
                    } else {
                        aResult.Append("Ue");
                    }
                    return;
                case 'ẞ': //upper-case sharp-S 
                    aResult.Append("SS");
                    return;
                //Append one-letter substitutes
                case 'À':
                case 'Á':
                case 'Â':
                case 'Ã':
                case 'Å':
                case 'Ā':
                case 'Ă':
                case 'Ą':
                case 'Ǎ':
                case 'Ǻ':
                case 'Ạ':
                case 'Ả':
                case 'Ấ':
                case 'Ầ':
                case 'Ẩ':
                case 'Ẫ':
                case 'Ậ':
                case 'Ắ':
                case 'Ằ':
                case 'Ẳ':
                case 'Ẵ':
                case 'Ặ':
                    aResult.Append('A');
                    return;
                case 'à':
                case 'á':
                case 'â':
                case 'ã':
                case 'å':
                case 'ā':
                case 'ă':
                case 'ą':
                case 'ǎ':
                case 'ǻ':
                case 'ạ':
                case 'ả':
                case 'ấ':
                case 'ầ':
                case 'ẩ':
                case 'ẫ':
                case 'ậ':
                case 'ắ':
                case 'ằ':
                case 'ẳ':
                case 'ẵ':
                case 'ặ':
                    aResult.Append('a');
                    return;
                case 'Ç':
                case 'Ć':
                case 'Ĉ':
                case 'Ċ':
                case 'Č':
                    aResult.Append('C');
                    return;
                case 'ç':
                case 'ć':
                case 'ĉ':
                case 'ċ':
                case 'č':
                    aResult.Append('c');
                    return;
                case 'Ð':
                case 'Ď':
                case 'Đ':
                    aResult.Append('D');
                    return;
                case 'ď':
                case 'đ':
                    aResult.Append('d');
                    return;
                case 'È':
                case 'É':
                case 'Ê':
                case 'Ë':
                case 'Ē':
                case 'Ĕ':
                case 'Ė':
                case 'Ę':
                case 'Ě':
                case 'Ẹ':
                case 'Ẻ':
                case 'Ẽ':
                case 'Ế':
                case 'Ề':
                case 'Ể':
                case 'Ễ':
                case 'Ệ':
                    aResult.Append('E');
                    return;
                case 'è':
                case 'é':
                case 'ê':
                case 'ë':
                case 'ē':
                case 'ĕ':
                case 'ė':
                case 'ę':
                case 'ě':
                case 'ẹ':
                case 'ẻ':
                case 'ẽ':
                case 'ế':
                case 'ề':
                case 'ể':
                case 'ễ':
                case 'ệ':
                    aResult.Append('e');
                    return;
                case 'ƒ':
                    aResult.Append('f');
                    return;
                case 'Ĝ':
                case 'Ğ':
                case 'Ġ':
                case 'Ģ':
                    aResult.Append('G');
                    return;
                case 'ĝ':
                case 'ğ':
                case 'ġ':
                case 'ģ':
                    aResult.Append('g');
                    return;
                case 'Ĥ':
                case 'Ħ':
                    aResult.Append('H');
                    return;
                case 'ĥ':
                case 'ħ':
                    aResult.Append('h');
                    return;
                case 'Ì':
                case 'Í':
                case 'Î':
                case 'Ï':
                case 'Ĩ':
                case 'Ī':
                case 'Ĭ':
                case 'Į':
                case 'İ':
                case 'Ǐ':
                case 'Ỉ':
                case 'Ị':
                    aResult.Append('I');
                    return;
                case 'ì':
                case 'í':
                case 'î':
                case 'ï':
                case 'ĩ':
                case 'ī':
                case 'ĭ':
                case 'į':
                case 'ı':
                case 'ǐ':
                case 'ỉ':
                case 'ị':
                    aResult.Append('i');
                    return;
                case 'Ĵ':
                    aResult.Append('J');
                    return;
                case 'ĵ':
                    aResult.Append('j');
                    return;
                case 'Ķ':
                case 'ĸ':
                    aResult.Append('K');
                    return;
                case 'ķ':
                    aResult.Append('k');
                    return;
                case 'Ĺ':
                case 'Ļ':
                case 'Ŀ':
                case 'Ł':
                    aResult.Append('L');
                    return;
                case 'ĺ':
                case 'ļ':
                case 'ŀ':
                case 'ł':
                    aResult.Append('l');
                    return;
                case 'Ñ':
                case 'Ń':
                case 'Ņ':
                case 'Ň':
                    aResult.Append('N');
                    return;
                case 'ñ':
                case 'ń':
                case 'ņ':
                case 'ň':
                    aResult.Append('n');
                    return;
                case 'Ò':
                case 'Ó':
                case 'Ô':
                case 'Õ':
                case 'Ō':
                case 'Ŏ':
                case 'Ő':
                case 'Ǒ':
                case 'Ọ':
                case 'Ỏ':
                case 'Ố':
                case 'Ồ':
                case 'Ổ':
                case 'Ỗ':
                case 'Ộ':
                case 'Ớ':
                case 'Ờ':
                case 'Ở':
                case 'Ỡ':
                case 'Ợ':
                    aResult.Append('O');
                    return;
                case 'ò':
                case 'ó':
                case 'ô':
                case 'õ':
                case 'ō':
                case 'ŏ':
                case 'ő':
                case 'ǒ':
                case 'ọ':
                case 'ỏ':
                case 'ố':
                case 'ồ':
                case 'ổ':
                case 'ỗ':
                case 'ộ':
                case 'ớ':
                case 'ờ':
                case 'ở':
                case 'ỡ':
                case 'ợ':
                    aResult.Append('o');
                    return;
                case 'Þ': //Capital thorn
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("TH");
                    } else {
                        aResult.Append("Th");
                    }
                    return;
                case 'þ': //Lowercase thorn
                    aResult.Append("th"); //thorn
                    return;
                case 'Ŕ':
                case 'Ŗ':
                case 'Ř':
                    aResult.Append('R');
                    return;
                case 'ŕ':
                case 'ŗ':
                case 'ř':
                    aResult.Append('r');
                    return;
                case 'Ś':
                case 'Ŝ':
                case 'Ş':
                case 'Š':
                    aResult.Append('S');
                    return;
                case 'ś':
                case 'ŝ':
                case 'ş':
                case 'š':
                    aResult.Append('s');
                    return;
                case 'Ţ':
                case 'Ť':
                case 'Ŧ':
                    aResult.Append('T');
                    return;
                case 'ţ':
                case 'ť':
                case 'ŧ':
                    aResult.Append('t');
                    return;
                case 'Ù':
                case 'Ú':
                case 'Û':
                case 'Ů':
                case 'Ű':
                case 'Ų':
                case 'Ǔ':
                case 'Ǖ':
                case 'Ǘ':
                case 'Ǚ':
                case 'Ǜ':
                case 'Ụ':
                case 'Ủ':
                case 'Ứ':
                case 'Ừ':
                case 'Ử':
                case 'Ữ':
                case 'Ự':
                    aResult.Append('U');
                    return;
                case 'ù':
                case 'ú':
                case 'û':
                case 'ů':
                case 'ű':
                case 'ų':
                case 'ǔ':
                case 'ǖ':
                case 'ǘ':
                case 'ǚ':
                case 'ǜ':
                case 'ụ':
                case 'ủ':
                case 'ứ':
                case 'ừ':
                case 'ử':
                case 'ữ':
                case 'ự':
                    aResult.Append('u');
                    return;
                case 'Ŵ':
                case 'Ẁ':
                case 'Ẃ':
                case 'Ẅ':
                    aResult.Append('W');
                    return;
                case 'ŵ':
                case 'ẁ':
                case 'ẃ':
                case 'ẅ':
                    aResult.Append('w');
                    return;
                case 'Ý':
                case 'Ŷ':
                case 'Ÿ':
                case 'Ỳ':
                case 'Ỵ':
                case 'Ỷ':
                case 'Ỹ':
                    aResult.Append('Y');
                    return;
                case 'ý':
                case 'ÿ':
                case 'ŷ':
                case 'ỳ':
                case 'ỵ':
                case 'ỷ':
                case 'ỹ':
                    aResult.Append('y');
                    return;
                case 'Ź':
                case 'Ż':
                case 'Ž':
                    aResult.Append('Z');
                    return;
                case 'ź':
                case 'ż':
                case 'ž':
                    aResult.Append('z');
                    return;
                case 'æ':
                case 'ǽ':
                    aResult.Append("ae");
                    return;
                case 'Æ':
                case 'Ǽ':
                    aResult.Append("AE");
                    return;
                case 'Ø':
                case 'Ǿ':
                    if ((IsAllUppercase(anIndex, aCharArray))) {
                        aResult.Append("OE");
                    } else {
                        aResult.Append("Oe");
                    }
                    return;
                case 'ø':
                case 'ǿ':
                case 'œ':
                    aResult.Append("oe");
                    return;
                case 'Œ':
                    aResult.Append("OE"); //Always both remain uppercase
                    return;
                case 'Ľ':
                    aResult.Append("L'");
                    return;
                case 'ľ':
                    aResult.Append("l'");
                    return;
                case 'ŉ':
                    aResult.Append("'n");
                    return;
                case 'Ơ':
                    aResult.Append("O'");
                    return;
                case 'ơ':
                    aResult.Append("o'");
                    return;
                case 'Ư':
                    aResult.Append("U'");
                    return;
                case 'ư':
                    aResult.Append("u'");
                    return;
                case 'Ĳ': //Always both remain uppercase
                    aResult.Append("IJ");
                    return;
                case 'ĳ':
                    aResult.Append("ij");
                    return;
                case '⁰':
                    aResult.Append('0');
                    return;
                case '¹':
                    aResult.Append('1');
                    return;
                case '²':
                    aResult.Append('2');
                    return;
                case '³':
                    aResult.Append('3');
                    return;
                case '⁴':
                    aResult.Append('4');
                    return;
                case '⁵':
                    aResult.Append('5');
                    return;
                case '⁶':
                    aResult.Append('6');
                    return;
                case '⁷':
                    aResult.Append('7');
                    return;
                case '⁸':
                    aResult.Append('8');
                    return;
                case '⁹':
                    aResult.Append('9');
                    return;
                case '₀':
                    aResult.Append('0');
                    return;
                case '₁':
                    aResult.Append('1');
                    return;
                case '₂':
                    aResult.Append('2');
                    return;
                case '₃':
                    aResult.Append('3');
                    return;
                case '₄':
                    aResult.Append('4');
                    return;
                case '₅':
                    aResult.Append('5');
                    return;
                case '₆':
                    aResult.Append('6');
                    return;
                case '₇':
                    aResult.Append('7');
                    return;
                case '₈':
                    aResult.Append('8');
                    return;
                case '₉':
                    aResult.Append('9');
                    return;
            }
            //If signs should also be converted
            if (convertSigns) {
                switch (aChar) {
                    case ' ':
                        aResult.Append(' ');
                        return;
                    case ' ':
                        aResult.Append(' ');
                        return;
                    case ' ':
                        aResult.Append(' ');
                        return;
                    case ' ':
                        aResult.Append(' ');
                        return;
                    case '¢':
                        aResult.Append("c");
                        return;
                    case '©':
                        aResult.Append("(C)");
                        return;
                    case '®':
                        aResult.Append("(R)");
                        return;
                    case '™':
                        aResult.Append("TM");
                        return;
                    case 'ª':
                        aResult.Append('a');
                        return;
                    case 'º':
                        aResult.Append('o');
                        return;
                    case '·':
                        aResult.Append('*');
                        return;
                    case '«':
                        aResult.Append('\"');
                        return;
                    case '»':
                        aResult.Append('\"');
                        return;
                    case '¯':
                        aResult.Append('-');
                        return;
                    case '±':
                        aResult.Append("+/-");
                        return;
                    case '´':
                        aResult.Append('\'');
                        return;
                    case '‘':
                        aResult.Append('\'');
                        return;
                    case '’':
                        aResult.Append('\'');
                        return;
                    case '‚':
                        aResult.Append('\'');
                        return;
                    case '“':
                        aResult.Append('\"');
                        return;
                    case '”':
                        aResult.Append('\"');
                        return;
                    case '„':
                        aResult.Append('\"');
                        return;
                    case '¼':
                        aResult.Append("1/4");
                        return;
                    case '½':
                        aResult.Append("1/2");
                        return;
                    case '¾':
                        aResult.Append("3/4");
                        return;
                    case '×':
                        aResult.Append('*');
                        return;
                    case '÷':
                        aResult.Append('/');
                        return;
                    case '−':
                        aResult.Append('-');
                        return;
                    case '–':
                        aResult.Append('-');
                        return;
                    case '—':
                        aResult.Append('-');
                        return;
                    case '∗':
                        aResult.Append('*');
                        return;
                    case '≠':
                        aResult.Append("<>");
                        return;
                    case '≤':
                        aResult.Append("<=");
                        return;
                    case '≥':
                        aResult.Append(">=");
                        return;
                    case '⋅':
                        aResult.Append('*');
                        return;
                    case '〈':
                        aResult.Append(" <");
                        return;
                    case '〉':
                        aResult.Append("> ");
                        return;
                    case '←':
                        aResult.Append("<-");
                        return;
                    case '→':
                        aResult.Append("->");
                        return;
                    case '↔':
                        aResult.Append("<->");
                        return;
                    case '⇐':
                        aResult.Append("<=");
                        return;
                    case '⇒':
                        aResult.Append("=>");
                        return;
                    case '⇔':
                        aResult.Append("<=>");
                        return;
                    case '•':
                        aResult.Append('-');
                        return;
                    case '′':
                        aResult.Append('\'');
                        return;
                    case '″':
                        aResult.Append('\"');
                        return;
                    case '‾':
                        aResult.Append('-');
                        return;
                    case '⁄':
                        aResult.Append('/');
                        return;
                    case '℘':
                        aResult.Append('p');
                        return;
                    case 'ℑ':
                        aResult.Append('J');
                        return;
                    case 'ℜ':
                        aResult.Append('R');
                        return;
                    case '…':
                        aResult.Append("...");
                        return;
                    case '‹':
                        aResult.Append('<');
                        return;
                    case '›':
                        aResult.Append('>');
                        return;
                }
            }
            //Otherwise simply add the Char
            aResult.Append(aChar);
        }

        private static Boolean IsAllUppercase(Int32 anIndex, Char[] aCharArray) {
            //Simple implementation that respects only the next/previous Char
            Char? myNeighbor = GetChar(anIndex + 1, aCharArray);
            if ((myNeighbor == null) || (myNeighbor == 'ß') || ((!Char.IsUpper(myNeighbor.Value)) && (!Char.IsLower(myNeighbor.Value)))) {
                myNeighbor = GetChar(anIndex - 1, aCharArray);
            }
            if ((myNeighbor == null) || (!Char.IsUpper(myNeighbor.Value))) {
                return false;
            }
            return true;
        }

        private static Char? GetChar(Int32 index, Char[] charArray) {
            if (index < 0) return null;
            if (index >= charArray.Length) return null;
            return charArray[index];
        }

    }

}
