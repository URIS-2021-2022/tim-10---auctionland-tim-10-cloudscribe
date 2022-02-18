using AutoMapper;
using Korisnik.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Korisnik.Data
{
    public class TipRepository : ITipRepository
    {

        private readonly KorisnikContext context;
        private readonly IMapper mapper;
        
        public TipRepository( KorisnikContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
            //FillData();
        }
       /* private void FillData()
        {
            Tipovi.AddRange(new List<Tip>
            {

                new Tip
                {
                     TipId = Guid.Parse("5b3dbaa4-60d0-4081-b848-752d8a2ab74e"),
                    TipKorisnika = "Operater"
                },
                new Tip
                {

                    TipId = Guid.Parse("719cbcae-ba05-4bdf-b0f8-636d79b70180"),
                    TipKorisnika = "Tehnicki sekretar"
                },
                new Tip
                {

                   TipId = Guid.Parse("4915ab80-5233-45a7-a7d2-b8c636fa934d"),
                   TipKorisnika = "Superuser"
                 },
                new Tip
                {

                   TipId = Guid.Parse("f4ae8300-84cd-488f-90c7-d5b1d871bd9e"),
                   TipKorisnika = "Operator nadmetanja"
                },
                new Tip
                {


                   TipId = Guid.Parse("d2a484a7-e975-43c6-9604-21ac9459456f"),
                   TipKorisnika = "Administrator"
                  },
              new Tip
              {
                   TipId = Guid.Parse("61643c5a-da3e-4388-86f8-4e0934de0e86"),
                   TipKorisnika = "Licitant"
                   },
              new Tip
              {

                   TipId = Guid.Parse("be35e797-9946-4d9d-a"),
                   TipKorisnika = "Menadzer"
                   }
               
        

            });
        }
       */
       public bool SaveChanges()
        {
            return context.SaveChanges() > 0;
        }
      
       
        public Tip CreateTip(Tip tipModel)
        {
             var createdEntity = context.Add(tipModel);
            return mapper.Map<Tip>(createdEntity.Entity);
           /* tipModel.TipId = Guid.NewGuid();
            Tipovi.Add(tipModel);
            var tip = GetTipById(tipModel.TipId);
            return new Tip
            {
                TipId = tip.TipId,
                TipKorisnika = tip.TipKorisnika
            };*/
        }

        public List<Tip> GetTip()
        {
            return context.Tipovi.ToList();
        }

        public Tip GetTipById(Guid tipId)
        {
            return context.Tipovi.FirstOrDefault(e => e.TipId == tipId);
        }
    }
}
