﻿using Adresa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Adresa.Data
{
    public class AdresaRepository : IAdresaRepository
    {
        public static List<AdresaModel> Adrese { get; set; } = new List<AdresaModel>();

        public AdresaRepository()
        {
            FillData();
        }

        private void FillData()
        {
            Adrese.AddRange(new List<AdresaModel>
            {
                new AdresaModel
                {
                    AdresaId = Guid.Parse("6a411c13-a195-48f7-8dbd-67596c3974c0"),
                    Ulica = "Ulica1",
                    Broj = "1",
                    Mesto = "Mesto1",
                    PostanskiBroj = 123,
                    DrzavaId = Guid.Parse("170960f3-f8e0-4614-aff2-653aadf5c720"),
                    NazivDrzave = "Drzava1"
                },
                new AdresaModel
                {
                    AdresaId = Guid.Parse("32cd906d-8bab-457c-ade2-fbc4ba523029"),
                    Ulica = "Ulica2",
                    Broj = "2",
                    Mesto = "Mesto2",
                    PostanskiBroj = 123456,
                    DrzavaId = Guid.Parse("c8a9ffbc-db56-46ff-a54a-948c91550189"),
                    NazivDrzave = "Drzava2"
                }
            }); 
        }

        public AdresaConfirmation CreateAdresa(AdresaModel adresaModel)
        {
            adresaModel.AdresaId = Guid.NewGuid();
            Adrese.Add(adresaModel);

            AdresaModel adresa = GetAdresaById(adresaModel.AdresaId);

            return new AdresaConfirmation
            {
                AdresaId = adresa.AdresaId,
                Ulica = adresa.Ulica,
                Broj = adresa.Broj,
                Mesto = adresa.Mesto,
                PostanskiBroj = adresa.PostanskiBroj,
                DrzavaId = adresa.DrzavaId,
                NazivDrzave = adresa.NazivDrzave
            };
        }

        public void DeleteAdresa(Guid adresaId)
        {
            Adrese.Remove(Adrese.FirstOrDefault(e => e.AdresaId == adresaId));
        }

        public AdresaModel GetAdresaById(Guid adresaId)
        {
            return Adrese.FirstOrDefault(e => e.AdresaId == adresaId);
        }

        public List<AdresaModel> GetAdrese()
        {
            return Adrese;
        }

        public AdresaConfirmation UpdateAdresa(AdresaModel adresaModel)
        {
            AdresaModel adresa = GetAdresaById(adresaModel.AdresaId);
            adresa.AdresaId = adresaModel.AdresaId;
            adresa.Ulica = adresaModel.Ulica;
            adresa.Broj = adresaModel.Broj;
            adresa.Mesto = adresaModel.Mesto;
            adresa.PostanskiBroj = adresaModel.PostanskiBroj;
            adresa.DrzavaId = adresaModel.DrzavaId;
            adresa.NazivDrzave = adresaModel.NazivDrzave;

            return new AdresaConfirmation {
                AdresaId = adresa.AdresaId,
                Ulica = adresa.Ulica,
                Broj = adresa.Broj,
                Mesto = adresa.Mesto,
                PostanskiBroj = adresa.PostanskiBroj,
                DrzavaId = adresa.DrzavaId,
                NazivDrzave = adresa.NazivDrzave
            };
        }
    }
}
