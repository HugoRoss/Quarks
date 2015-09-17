//Courtesy of www.steffeninf.ch
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Quarks.CultureInfoExtensions {

    internal static partial class CultureInfoExtension {

        /// <summary>Temporarily changes the formats and language of the current thread to the ones of this culture info (internally Thread.CurrentThread.CurrentCulture and Thread.CurrentThread.CurrentUICulture are overwritten). 
        /// If used in a using-block, the formats and language are automatically restored the moment the using-block is left. Dispose does not necessarily have to be called by the same thread,
        /// the returned instance remembers the thread on which the culture info was adjusted and restores it again on the same thread. If dispose is called more than once, the second
        /// and following calls are ignored.</summary>
        /// <param name="culture">The culture info who's language to be temporarily used.</param>
        /// <returns>An instance of IDisposable that can be wrapped by a "using"-block and that will automatically revert the CurrentCulture and CurrentUICulture of the calling thread to the values that has been set before this method was called.</returns>
        /// <example>The Swiss-German language and formats are temporarily used to write a number as well as an error message to the console:
        /// <code lang="C#">
        /// CultureInfo deCH = new CultureInfo("de-CH", false);
        /// using (deCH.CultureOverride()) {
        ///     Console.Out.WriteLine("{0:N}", 1234.56); //Prints "1'234.56"
        ///     try {
        ///         Console.Out.WriteLine("{0:N}", 1234.56 / 0);
        ///     } catch (Exception ex) {
        ///         //Message is printed in German (if the according language pack is installed)
        ///         Console.Out.WriteLine(ex.Message); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IDisposable CultureOverride(this CultureInfo culture) {
            IDisposable myResult = new CurrentCultureOverride(culture, culture);
            return myResult;
        }


        //*****************************************************************************************
        // INNER CLASS: CultureOverrideImplementation
        //*****************************************************************************************

        /// <summary>Helper class used for temporarily override the current culture (date-, number-formats etc.) and/or UI culture (translations).</summary>
        private class CurrentCultureOverride : IDisposable {

            //Private Fields
            private Thread _OriginalThread; 
            private CultureInfo _OriginalFormatCulture;
            private CultureInfo _OriginalLanguageCulture;

            //Constructors

            public CurrentCultureOverride(CultureInfo formatOverride, CultureInfo languageOverride) {
                //Keep a reference to the thread (to allow "Dispose()" to be called from another thread)
                Thread myThread = Thread.CurrentThread;
                _OriginalThread = myThread;
                //Change format culture
                if (formatOverride != null) {
                    _OriginalFormatCulture = myThread.CurrentCulture;
                    myThread.CurrentCulture = formatOverride;
                }
                //Change language culture
                if (languageOverride != null) {
                    _OriginalLanguageCulture = myThread.CurrentUICulture;
                    myThread.CurrentUICulture = languageOverride;
                }
            }

            //Private Interface Implementation

            void IDisposable.Dispose() {
                //Load original thread
                Thread myThread = _OriginalThread;
                //Revert to original format
                if (_OriginalFormatCulture != null) {
                    try {
                        myThread.CurrentCulture = _OriginalFormatCulture;
                    } catch {
                    }
                    _OriginalFormatCulture = null;
                }
                //Revert to original language
                if (_OriginalLanguageCulture != null) {
                    try {
                        myThread.CurrentUICulture = _OriginalLanguageCulture;
                    } catch {
                    }
                    _OriginalLanguageCulture = null;
                }
            }

        }

    }

}
