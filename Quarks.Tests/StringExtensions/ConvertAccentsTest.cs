
using System;
using System.Globalization;
using System.Threading;
using Machine.Specifications;
using Quarks.StringExtensions;

namespace Quarks.Tests.StringExtensions {

    [Subject(typeof(StringExtension))]
    class When_calling_ConvertAccents {

        //German umlauts

        It should_convert_u_umlaut_to_ue = () => {
            //German: "for"
            String myTextBefore = "für";
            String myTextAfter = "fuer";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_U_umlaut_to_Ue_in_normal_writing = () => {
            //German: "exercise"
            String myTextBefore = "Übung";
            String myTextAfter = "Uebung";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_U_umlaut_to_UE_in_uppercase_writing = () => {
            //German: "exercise"
            String myTextBefore = "ÜBUNG";
            String myTextAfter = "UEBUNG";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_a_umlaut_to_ae = () => {
            //German: "offender"
            String myTextBefore = "Täter";
            String myTextAfter = "Taeter";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_A_umlaut_to_Ae_in_normal_writing = () => {
            //German: "equator"
            String myTextBefore = "Äquator";
            String myTextAfter = "Aequator";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_A_umlaut_to_AE_in_uppercase_writing = () => {
            //German: "equator"
            String myTextBefore = "ÄQUATOR";
            String myTextAfter = "AEQUATOR";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_o_umlaut_to_oe = () => {
            //German: "furniture"
            String myTextBefore = "Möbel";
            String myTextAfter = "Moebel";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_O_umlaut_to_Oe_in_normal_writing = () => {
            //German: "oil strainer"
            String myTextBefore = "Ölfilter";
            String myTextAfter = "Oelfilter";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_O_umlaut_to_OE_in_uppercase_writing = () => {
            //German: "oil strainer"
            String myTextBefore = "ÖLFILTER";
            String myTextAfter = "OELFILTER";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_sharp_s_to_ss = () => {
            //German: "foot"
            String myTextBefore = "Fuß"; //lower-case sharp S
            String myTextAfter = "Fuss";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Hint: It is common in German writing to use lowercase sharp-S even in all-uppercase-texts (although unicode does define an uppercase sharp-S)
        It should_convert_uppercase_string_with_lowercase_sharp_s_to_SS = () => {
            //German: "foot"
            String myTextBefore = "FUß"; //lower-case sharp S
            String myTextAfter = "FUSS";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Hint: Upper-case sharp-S is very uncommon in German, usually for upper- and lowercase sharp-S the lowercase letter is used!
        It should_convert_uppercase_string_with_uppercase_sharp_S = () => {
            //German: "foot"
            String myTextBefore = "FUẞ"; //upper-case sharp S
            String myTextAfter = "FUSS";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //French grapheme

        It should_convert_ae_grapheme_to_ae = () => {
            //Danish: "apple"
            String myTextBefore = "æble"; 
            String myTextAfter = "aeble";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_AE_grapheme_to_AE_in_normal_writing = () => {
            //Danish: "apple"
            String myTextBefore = "Æble";
            String myTextAfter = "AEble"; //An Æ remains "AE" and never becomes "Ae"
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_AE_grapheme_to_AE_in_uppercase_writing = () => {
            //Danish: "apple"
            String myTextBefore = "ÆBLE";
            String myTextAfter = "AEBLE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_oe_grapheme_to_oe = () => {
            //French: "eye"
            String myTextBefore = "œil"; 
            String myTextAfter = "oeil";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_OE_grapheme_to_OE_in_normal_writing = () => {
            //French: "eye"
            String myTextBefore = "Œil";
            String myTextAfter = "OEil"; //An Œ remains "OE" and never becomes "Oe"
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_OE_grapheme_to_OE_in_uppercase_writing = () => {
            //French: "eye"
            String myTextBefore = "ŒIL";
            String myTextAfter = "OEIL";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter a

        It should_convert_a_acute_to_a = () => {
            //Icelandic: "effort"
            String myTextBefore = "átak";
            String myTextAfter = "atak";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_A_acute_to_A = () => {
            //Icelandic: "effort"
            String myTextBefore = "ÁTAK";
            String myTextAfter = "ATAK";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_a_grave_to_a = () => {
            //French: "here"
            String myTextBefore = "voilà";
            String myTextAfter = "voila";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_A_grave_to_A = () => {
            //French: "here"
            String myTextBefore = "VOILÀ";
            String myTextAfter = "VOILA";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_a_circumflex_to_a = () => {
            //French: "age"
            String myTextBefore = "âge";
            String myTextAfter = "age";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_A_circumflex_to_a = () => {
            //French: "age"
            String myTextBefore = "ÂGE";
            String myTextAfter = "AGE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter c

        It should_convert_c_cedil_to_c = () => {
            //French: "waiter" or "boy"
            String myTextBefore = "garçon";
            String myTextAfter = "garcon";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_C_cedil_to_C = () => {
            //French: "waiter" or "boy"
            String myTextBefore = "GARÇON";
            String myTextAfter = "GARCON";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter e

        It should_convert_e_acute_to_e = () => {
            //French: "department"
            String myTextBefore = "département";
            String myTextAfter = "departement";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_E_acute_to_E = () => {
            //French: "department"
            String myTextBefore = "DÉPARTEMENT";
            String myTextAfter = "DEPARTEMENT";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_e_grave_to_e = () => {
            //French: "career"
            String myTextBefore = "carrière";
            String myTextAfter = "carriere";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_E_grave_to_E = () => {
            //French: "career"
            String myTextBefore = "CARRIÈRE";
            String myTextAfter = "CARRIERE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_e_circumflex_to_e = () => {
            //French: "forest"
            String myTextBefore = "forêt";
            String myTextAfter = "foret";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_E_circumflex_to_E = () => {
            //French: "forest"
            String myTextBefore = "FORÊT";
            String myTextAfter = "FORET";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_e_trema_to_e = () => {
            //French: "Christmas"
            String myTextBefore = "Noël";
            String myTextAfter = "Noel";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_E_trema_to_e = () => {
            //French: "Christmas"
            String myTextBefore = "NOËL";
            String myTextAfter = "NOEL";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter g

        It should_convert_g_breve_to_g = () => {
            //Turkish: "onion", "bulb"
            String myTextBefore = "soğan";
            String myTextAfter = "sogan";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_G_breve_to_G = () => {
            //Turkish: "onion", "bulb"
            String myTextBefore = "SOĞAN";
            String myTextAfter = "SOGAN";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter i

        It should_convert_i_acute_to_i = () => {
            //Galician: "index"
            String myTextBefore = "índice";
            String myTextAfter = "indice";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_I_acute_to_I = () => {
            //Galician: "index"
            String myTextBefore = "ÍNDICE";
            String myTextAfter = "INDICE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_i_graphe_to_i = () => {
            //Vietnamese: "river"
            String myTextBefore = "rìu";
            String myTextAfter = "riu";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_I_graphe_to_I = () => {
            //Vietnamese: "river"
            String myTextBefore = "RÌU";
            String myTextAfter = "RIU";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_i_circumflex_to_i = () => {
            //French: "island"
            String myTextBefore = "île";
            String myTextAfter = "ile";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_I_circumflex_to_I = () => {
            //French: "island"
            String myTextBefore = "ÎLE";
            String myTextAfter = "ILE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_i_trema_to_i = () => {
            //French: "paranoid"
            String myTextBefore = "paranoïde";
            String myTextAfter = "paranoide";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_I_trema_to_I = () => {
            //French: "paranoid"
            String myTextBefore = "PARANOÏDE";
            String myTextAfter = "PARANOIDE";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter n

        It should_convert_n_tilde_to_n = () => {
            //Spanish: "child"
            String myTextBefore = "Niño";
            String myTextAfter = "Nino";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_N_tilde_to_N = () => {
            //Spanish: "child"
            String myTextBefore = "NIÑO";
            String myTextAfter = "NINO";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter o

        It should_convert_o_acute_to_o = () => {
            //Hungarian: "good"
            String myTextBefore = "jó";
            String myTextAfter = "jo";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_O_acute_to_O = () => {
            //Hungarian: "good"
            String myTextBefore = "jó";
            String myTextAfter = "jo";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_o_circumflex_to_o = () => {
            //French: "hospital"
            String myTextBefore = "hôpital";
            String myTextAfter = "hopital";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_O_circumflex_to_O = () => {
            //French: "hospital"
            String myTextBefore = "HÔPITAL";
            String myTextAfter = "HOPITAL";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        //Letter s

        It should_convert_s_cedil_to_s = () => {
            //Turkish: "corpse"
            String myTextBefore = "leş";
            String myTextAfter = "les";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_S_cedil_to_S = () => {
            //Turkish: "corpse"
            String myTextBefore = "LEŞ";
            String myTextAfter = "LES";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };


        //Letter u

        It should_convert_u_acute_to_u = () => {
            //Spanish: "moist"
            String myTextBefore = "húmedo";
            String myTextAfter = "humedo";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_U_acute_to_U = () => {
            //Spanish: "moist"
            String myTextBefore = "HÚMEDO";
            String myTextAfter = "HUMEDO";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_u_grave_to_u = () => {
            //Breton: "name"
            String myTextBefore = "anvioù";
            String myTextAfter = "anviou";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_U_grave_to_U = () => {
            //Breton: "name"
            String myTextBefore = "ANVIOÙ";
            String myTextAfter = "ANVIOU";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_u_circumflex_to_u = () => {
            //French: "to cost"
            String myTextBefore = "coûter";
            String myTextAfter = "couter";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_U_circumflex_to_U = () => {
            //French: "to cost"
            String myTextBefore = "COÛTER";
            String myTextAfter = "COUTER";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };
        
        //Letter y

        It should_convert_y_acute_to_y = () => {
            //Faroese: "Swamp"
            String myTextBefore = "mýra";
            String myTextAfter = "myra";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

        It should_convert_Y_acute_to_Y = () => {
            //Faroese: "Swamp"
            String myTextBefore = "MÝRA";
            String myTextAfter = "MYRA";
            myTextBefore.ConvertAccents().ShouldBeLike(myTextAfter);
        };

    }

}
