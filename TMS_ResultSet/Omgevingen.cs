using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TMS_ResultSet
{
    internal class Omgevingen
    {
        private Omgeving _omgeving;
        internal string _usedURL;

        internal Omgevingen(string input)
        {
            SetOmgeving(input);
        }

        private enum Omgeving
        {
            NotDefined,
            Intern,
            Johanknegt,
            BSB,
            Connect,
            CVB,
            OneUnderwriting,
            DeLeeuw,
            Cascade,
            Diverz,
            Eijgendaal,
            Mandaat,
            Guijt,
            Helviass,
            LukassenEnBoer,
            Kroezen,
            Nedvol,
            Noorderlinge,
            Risk,
            Rivez,
            VanDerRoest,
            Veldhuis,
            VMD,
            Vrieling,
            Westenburg,
            Zuiderhuis
        }

        internal void SetOmgeving(string input)
        {
            string regX = @"(http(s*)\:)(.{2})((awi\.)*)(((test|development|stable|demo)(\.awi))|(testbsb|(awi\.bsbportaal))|(testconnect|awi\.connect\-assuradeuren)|(testcvb|cvb)|(testumg|umg|aon)|(testdeleeuw|portaal\.deleeuw)|(testdewitte|cascadeverzekeringsgroep)|(testict4finance|offerte\.sluit\.ict4finance)|(testdiverz|diverz)|(testeijgendaal|eijgendaal)|(testmandaat|mandaat)|(testguijt|guijt)|(testhelviass|helviass)|(testjohanknegt|johanknegt)|(testlukassenenboer|lukassenenboer)|(testkroezen|extranet\.plusdiensten)|(testnoorderlinge|noorderlinge)|(test\.mijnrisk|mijnrisk)|(testrivez|rivez)|(testvanderroest|vdrd)|(testveldhuis|veldhuis)|(testgha|gha)|(testvrieling|vrieling)|(testwestenburg|westenburg)|(testzuiderhuis|zuiderhuis))((\.awisoftware)*)((\.(nl|net))*)";

            if (Regex.IsMatch(input, regX))
            {
                var value = Regex.Match(input, regX).Value;

                switch (value)
                {
                    case @"https://testjohanknegt.awisoftware.nl":
                    case @"https://awi.johanknegt.nl":
                        _omgeving = Omgeving.Johanknegt;
                        _usedURL = value;
                        break;
                    case @"https://testbsb.awisoftware.nl":
                    case @"https://awi.bsbportaal.nl":
                        _omgeving = Omgeving.BSB;
                        _usedURL = value;
                        break;
                    case @"https://testconnect.awisoftware.nl":
                    case @"https://awi.connect-assuradeuren.nl":
                        _omgeving = Omgeving.Connect;
                        _usedURL = value;
                        break;
                    case @"https://testcvb.awisoftware.nl":
                    case @"https://cvb.awisoftware.nl":
                        _omgeving = Omgeving.CVB;
                        _usedURL = value;
                        break;
                    case @"https://testumg.awisoftware.nl":
                    case @"https://awi.umg.nl":
                    case @"https://aon.awisoftware.nl":
                        _omgeving = Omgeving.OneUnderwriting;
                        _usedURL = value;
                        break;
                    case @"https://testdeleeuw.awisoftware.nl":
                    case @"https://portaal.deleeuw.nl":
                        _omgeving = Omgeving.DeLeeuw;
                        _usedURL = value;
                        break;
                    case @"https://testdewitte.awisoftware.nl":
                    case @"https://awi.cascadeverzekeringsgroep.nl":
                        _omgeving = Omgeving.Cascade;
                        _usedURL = value;
                        break;
                    case @"https://testdiverz.awisoftware.nl":
                    case @"https://awi.diverz.nl":
                        _omgeving = Omgeving.Diverz;
                        _usedURL = value;
                        break;
                    case @"https://testeijgendaal.awisoftware.nl":
                    case @"https://eijgendaal.awisoftware.nl":
                        _omgeving = Omgeving.Eijgendaal;
                        _usedURL = value;
                        break;
                    case @"https://testmandaat.awisoftware.nl":
                    case @"https://awi.mandaat.net":
                        _omgeving = Omgeving.Mandaat;
                        _usedURL = value;
                        break;
                    case @"https://testguijt.awisoftware.nl":
                    case @"https://awi.guijt.nl":
                        _omgeving = Omgeving.Guijt;
                        _usedURL = value;
                        break;
                    case @"https://testhelviass.awisoftware.nl":
                    case @"https://awi.helviass.nl":
                        _omgeving = Omgeving.Helviass;
                        _usedURL = value;
                        break;
                    case @"http://testlukassenenboer.awisoftware.nl":
                    case @"http://lukassenenboer.awisoftware.nl":
                        _omgeving = Omgeving.LukassenEnBoer;
                        _usedURL = value;
                        break;
                    case @"http://testkroezen.awisoftware.nl":
                    case @"https://extranet.plusdiensten.nl":
                        _omgeving = Omgeving.Kroezen;
                        _usedURL = value;
                        break;
                    case @"https://testict4finance.awisoftware.nl":
                    case @"https://offerte.sluit.ict4finance.nl":
                        _omgeving = Omgeving.Nedvol;
                        _usedURL = value;
                        break;
                    case @"https://testnoorderlinge.awisoftware.nl":
                    case @"https://awi.noorderlinge.nl":
                        _omgeving = Omgeving.Noorderlinge;
                        _usedURL = value;
                        break;
                    case @"https://test.mijnrisk.nl":
                    case @"https://mijnrisk.nl":
                        _omgeving = Omgeving.Risk;
                        _usedURL = value;
                        break;
                    case @"http://testrivez.awisoftware.nl":
                    case @"https://rivez.awisoftware.nl":
                        _omgeving = Omgeving.Rivez;
                        _usedURL = value;
                        break;
                    case @"https://testvanderroest.awisoftware.nl":
                    case @"http://awi.vdrd.nl":
                        _omgeving = Omgeving.VanDerRoest;
                        _usedURL = value;
                        break;
                    case @"https://testveldhuis.awisoftware.nl":
                    case @"https://veldhuis.awisoftware.nl":
                        _omgeving = Omgeving.Veldhuis;
                        _usedURL = value;
                        break;
                    case @"https://testgha.awisoftware.nl":
                    case @"https://gha.awisoftware.nl":
                        _omgeving = Omgeving.VMD;
                        _usedURL = value;
                        break;
                    case @"http://testvrieling.awisoftware.nl":
                    case @"https://vrieling.awisoftware.nl":
                        _omgeving = Omgeving.Vrieling;
                        _usedURL = value;
                        break;
                    case @"https://testwestenburg.awisoftware.nl":
                    case @"https://westenburg.awisoftware.nl":
                        _omgeving = Omgeving.Westenburg;
                        _usedURL = value;
                        break;
                    case @"https://testzuiderhuis.awisoftware.nl":
                    case @"https://awi.zuiderhuis.nl":
                        _omgeving = Omgeving.Zuiderhuis;
                        _usedURL = value;
                        break;
                    case @"http://development.awi":
                    case @"http://test.awi":
                    case @"http://stable.awi":
                    case @"https://demo.awisoftware.nl":
                        _omgeving = Omgeving.Intern;
                        _usedURL = value;
                        break;
                }
            }
        }

        internal string GetOmgeving()
        {
            switch(_omgeving)
            {
                case Omgeving.Intern:
                    return "AWI intern";
                case Omgeving.LukassenEnBoer:
                    return "Lukassen & Boer";
                case Omgeving.OneUnderwriting:
                    return "One Underwriting";
                case Omgeving.VanDerRoest:
                    return "Van der Roest";
                case Omgeving.Johanknegt:
                case Omgeving.BSB:
                case Omgeving.Connect:
                case Omgeving.CVB:
                case Omgeving.Cascade:
                case Omgeving.Diverz:
                case Omgeving.Eijgendaal:
                case Omgeving.Mandaat:
                case Omgeving.Guijt:
                case Omgeving.Helviass:
                case Omgeving.Kroezen:
                case Omgeving.Noorderlinge:
                case Omgeving.Risk:
                case Omgeving.Rivez:
                case Omgeving.Veldhuis:
                case Omgeving.VMD:
                case Omgeving.Vrieling:
                case Omgeving.Westenburg:
                case Omgeving.Zuiderhuis:
                    return _omgeving.ToString();
            }
            return "URL not defined or recognized ...";
        }
    }
}
