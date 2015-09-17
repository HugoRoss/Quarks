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

        /// <summary>Temporarily changes the language of the current thread to the one of this culture info (internally Thread.CurrentThread.CurrentUICulture is overwritten). 
        /// If used in a using-block, the language is automatically restored the moment the using-block is left. Dispose does not necessarily have to be called by the same thread,
        /// the returned instance remembers the thread on which the culture info was adjusted and restores it again on the same thread. If dispose is called more than once, the second
        /// and following calls are ignored.</summary>
        /// <param name="culture">The culture info who's language to be temporarily used.</param>
        /// <returns>An instance of IDisposable that can be wrapped by a "using"-block and that will automatically revert the CurrentUICulture of the calling thread to the values that has been set before this method was called.</returns>
        /// <example>The Swiss-German language is temporarily used to write an error message to the console:
        /// <code lang="C#">
        /// CultureInfo deCH = new CultureInfo("de-CH", false);
        /// using (deCH.LanguageOverride()) {
        ///     try {
        ///         Console.Out.WriteLine("{0:N}", 1234.56 / 0);
        ///     } catch (Exception ex) {
        ///         //Message is printed in German (if the according language pack is installed)
        ///         Console.Out.WriteLine(ex.Message); 
        ///     }
        /// }
        /// </code>
        /// </example>
        public static IDisposable LanguageOverride(this CultureInfo culture) {
            IDisposable myResult = new CurrentLanguageOverride(culture);
            return myResult;
        }


        //*****************************************************************************************
        // INNER CLASS: CultureOverrideImplementation
        //*****************************************************************************************

        /// <summary>Helper class used for temporarily override the current culture (date-, number-formats etc.) and/or UI culture (translations).</summary>
        private class CurrentLanguageOverride : IDisposable {

            //Private Fields
            private Thread _OriginalThread; 
            private CultureInfo _OriginalLanguageCulture;

            //Constructors

            public CurrentLanguageOverride(CultureInfo languageOverride) {
                //Keep a reference to the thread (to allow "Dispose()" to be called from another thread)
                Thread myThread = Thread.CurrentThread;
                _OriginalThread = myThread;
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
