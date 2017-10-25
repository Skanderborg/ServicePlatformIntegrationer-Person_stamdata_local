using CPRBasicInformation.Web.CPRBasicInformationService;
using CPRBasicInformation.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CPRBasicInformation.Web.Services
{
    public class CPRExtendedService
    {

        public Person GetPersonDataFromCpr(string cpr)
        {
            if (cpr.Contains("-"))
                cpr = cpr.Replace("-", "");

            if (!IsValidCpr(cpr))
                throw new Exception("Invalid CPR");

            using (CPRBasicInformationWebServicePortTypeClient client = new CPRBasicInformationWebServicePortTypeClient())
            {
                var request = new CPRBasicInformationRequestType();
                request.InvocationContext = GetInvocationContextType();
                request.PNR = cpr;
                var response = client.callCPRBasicInformationServiceExtended(request);

                Person result = new Person()
                {
                    Pmr = response.pnr,
                    Koen = response.koen.ToString(),
                    Foedselsdato = response.foedselsdato,
                    FoedselsdatoUsikkerhedsmarkering = response.foedselsdatoUsikkerhedsmarkering,
                    Status = response.status,
                    Civilstand = response.civilstand.ToString(),
                    NavneOgAdressebeskyttelse = response.navneOgAdressebeskyttelse,
                    Adresseringsnavn = response.adresseringsnavn,
                    Standardadresse = response.standardadresse,
                    Postnummer = response.postnummer,
                    Postdistrikt = response.postdistrikt,
                    Vejadresseringsnavn = response.vejadresseringsnavn,
                    Husnummer = response.husnummer,
                    Etage = response.etage,
                    Sidedoer = response.sidedoer,
                    Kommunekode = response.kommunekode,
                    Vejkode = response.vejkode,
                    Tilflytningsdato = response.tilflytningsdato,
                    Fornavn = response.fornavn,
                    Efternavn = response.efternavn
                };

                return result;
            };
        }

        private InvocationContextType GetInvocationContextType()
        {
            return new InvocationContextType()
            {
                ServiceAgreementUUID = "",  //hedder: Serviceaftale UUID på serviceplatformen
                UserSystemUUID = "",        //hedder: System UUID på serviceplatofmren
                UserUUID = "",              //hedder: Kommune UUID på serviceplatformen
                ServiceUUID = ""            //hedder: Servicenavn på serviceplatformen (den services der benyttes)
            };
        }

        private bool IsValidCpr(string cpr)
        {
            Regex cprRegEx_IngenBindestreg = new Regex("^(?:(?:31(?:0[13578]|1[02])|(?:30|29)(?:0[13-9]|1[0-2])|(?:0[1-9]|1[0-9]|2[0-8])(?:0[1-9]|1[0-2]))[0-9]{3}|290200[4-9]|2902(?:(?!00)[02468][048]|[13579][26])[0-3])[0-9]{3}|0000000000$");
            return cprRegEx_IngenBindestreg.IsMatch(cpr);
        }
    }
}
