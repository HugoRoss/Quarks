using System;
using System.Globalization;
using System.Threading;
using Machine.Specifications;
using Quarks.CultureInfoExtensions;

namespace Quarks.Tests.CultureInfoExtensions {

    [Subject(typeof(CultureInfoExtension))]
    class When_overriding_format_enUS_with_deCH {

        Establish context = () => {
            Thread myCurrentThread = Thread.CurrentThread;
            myCurrentThread.CurrentCulture = enUS;
            myCurrentThread.CurrentUICulture = enUS;
        };

        Because of = () => {
            Thread myCurrentThread = Thread.CurrentThread;
            FormatCultureBeforeOverride = myCurrentThread.CurrentCulture;
            LanguageCultureBeforeOverride = myCurrentThread.CurrentUICulture;
            TestDateBeforeOverride = TestDate.ToString("d");
            TestNumberBeforeOverride = TestNumber.ToString("N");
            TestMessageBeforeOverride = GetMessage();
            using (deCH.FormatOverride()) {
                FormatCultureDuringOverride = myCurrentThread.CurrentCulture;
                LanguageCultureDuringOverride = myCurrentThread.CurrentUICulture;
                TestDateDuringOverride = TestDate.ToString("d");
                TestNumberDuringOverride = TestNumber.ToString("N");
                TestMessageDuringOverride = GetMessage();
            }
            FormatCultureAfterOverride = myCurrentThread.CurrentCulture;
            LanguageCultureAfterOverride = myCurrentThread.CurrentUICulture;
            TestDateAfterOverride = TestDate.ToString("d");
            TestNumberAfterOverride = TestNumber.ToString("N");
            TestMessageAfterOverride = GetMessage();
        };

        //Values before the call

        It should_be_format_enUS_before_the_call = () => {
            FormatCultureBeforeOverride.ShouldBeTheSameAs(enUS);
        };

        It should_be_language_enUS_before_the_call = () => {
            LanguageCultureBeforeOverride.ShouldBeTheSameAs(enUS);
        };

        It should_be_an_American_date_format_before_the_call = () => {
            TestDateBeforeOverride.ShouldBeEqualIgnoringCase("12/31/2020");
        };

        It should_be_an_American_number_format_before_the_call = () => {
            TestNumberBeforeOverride.ShouldBeEqualIgnoringCase("1,234.56");
        };

        It should_be_an_English_error_message_before_the_call = () => {
            TestMessageBeforeOverride.ShouldBeLike("Value cannot be null.");
        };

        //Values during the call

        It should_be_format_deCH_during_the_call = () => {
            FormatCultureDuringOverride.ShouldBeTheSameAs(deCH);
        };

        It should_be_language_enUS_during_the_call = () => {
            LanguageCultureDuringOverride.ShouldBeTheSameAs(enUS);
        };

        It should_be_a_Swiss_date_format_during_the_call = () => {
            TestDateDuringOverride.ShouldBeEqualIgnoringCase("31.12.2020");
        };

        It should_be_a_Swiss_number_format_during_the_call = () => {
            TestNumberDuringOverride.ShouldBeEqualIgnoringCase("1'234.56");
        };

        It should_be_an_English_error_message_during_the_call = () => {
            TestMessageDuringOverride.ShouldBeLike("Value cannot be null.");
        };

        //Values after the call

        It should_be_format_enUS_after_the_call = () => {
            FormatCultureAfterOverride.ShouldBeTheSameAs(enUS);
        };

        It should_be_language_enUS_after_the_call = () => {
            LanguageCultureAfterOverride.ShouldBeTheSameAs(enUS);
        };

        It should_be_an_American_date_format_after_the_call = () => {
            TestDateAfterOverride.ShouldBeEqualIgnoringCase("12/31/2020");
        };

        It should_be_an_American_number_format_after_the_call = () => {
            TestNumberAfterOverride.ShouldBeEqualIgnoringCase("1,234.56");
        };

        It should_be_an_English_error_message_after_the_call = () => {
            TestMessageAfterOverride.ShouldBeLike("Value cannot be null.");
        };

        //Private Functions

        private static String GetMessage() {
            //Hint: Got some inlining issues if exception was not thrown...
            try {
                throw new ArgumentNullException();
            } catch (Exception ex) {
                return ex.Message;
            }
        }

        //Private Fields
        private static CultureInfo FormatCultureBeforeOverride;
        private static CultureInfo FormatCultureDuringOverride;
        private static CultureInfo FormatCultureAfterOverride;
        private static CultureInfo LanguageCultureBeforeOverride;
        private static CultureInfo LanguageCultureDuringOverride;
        private static CultureInfo LanguageCultureAfterOverride;
        private static String TestDateBeforeOverride;
        private static String TestDateDuringOverride;
        private static String TestDateAfterOverride;
        private static String TestNumberBeforeOverride;
        private static String TestNumberDuringOverride;
        private static String TestNumberAfterOverride;
        private static String TestMessageBeforeOverride;
        private static String TestMessageDuringOverride;
        private static String TestMessageAfterOverride;
        private static CultureInfo enUS = new CultureInfo("en-US", false);
        private static CultureInfo deCH = new CultureInfo("de-CH", false);
        private static DateTime TestDate = new DateTime(2020, 12, 31);
        private static Decimal TestNumber = 1234.56M;

    }

}
