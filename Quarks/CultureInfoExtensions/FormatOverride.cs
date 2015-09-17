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

        /// <summary>Temporarily changes the formats of the current thread to the ones of this culture info (internally Thread.CurrentThread.CurrentCulture is overwritten). 
        /// If used in a using-block, the formats are automatically restored the moment the using-block is left. Dispose does not necessarily have to be called by the same thread,
        /// the returned instance remembers the thread on which the culture info was adjusted and restores it again on the same thread. If dispose is called more than once, the second
        /// and following calls are ignored.</summary>
        /// <param name="culture">The culture info who's formats and language to be temporarily used.</param>
        /// <returns>An instance of IDisposable that can be wrapped by a "using"-block and that will automatically revert the CurrentCulture of the calling thread to the value that has been set before this method was called.</returns>
        /// <example>The Swiss-German language format is temporarily used to write a number to the console:
        /// <code lang="C#">
        /// CultureInfo deCH = new CultureInfo("de-CH", false);
        /// using (deCH.FormatOverride()) {
        ///     Console.Out.WriteLine("{0:N}", 1234.56); //Prints "1'234.56"
        /// }
        /// </code>
        /// </example>
        public static IDisposable FormatOverride(this CultureInfo culture) {
            IDisposable myResult = new CurrentFormatOverride(culture);
            return myResult;
        }


        //*****************************************************************************************
        // INNER CLASS: CultureOverrideImplementation
        //*****************************************************************************************

        /// <summary>Helper class used for temporarily override the current culture (date-, number-formats etc.) and/or UI culture (translations).</summary>
        private class CurrentFormatOverride : IDisposable {

            //Private Fields
            private Thread _OriginalThread; 
            private CultureInfo _OriginalFormatCulture;

            //Constructors

            public CurrentFormatOverride(CultureInfo formatOverride) {
                //Keep a reference to the thread (to allow "Dispose()" to be called from another thread)
                Thread myThread = Thread.CurrentThread;
                _OriginalThread = myThread;
                //Change format culture
                if (formatOverride != null) {
                    _OriginalFormatCulture = myThread.CurrentCulture;
                    myThread.CurrentCulture = formatOverride;
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
            }

        }

    }

}
