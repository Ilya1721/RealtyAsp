using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Realty.Models;
using System.Drawing;
using Realty.Infrastructure;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Realty.DB
{
    public class RealtyInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RealtyContext>
    {
        protected override void Seed(RealtyContext context)
        {
            Debug.WriteLine("seeding");

            List<Currency> Currencies = new List<Currency>
            {
                new Currency { Name = "$" },
                new Currency { Name = "грн" },
            };

            Currencies.ForEach(g => context.Currencies.Add(g));

            List<HeaterType> HeaterTypes = new List<HeaterType>
            {
                new HeaterType { Name = "Индивидуальное" },
                new HeaterType { Name = "Централизованное" }
            };

            HeaterTypes.ForEach(g => context.HeaterTypes.Add(g));
            context.SaveChanges();

            List<Flat> Flats = new List<Flat>
            {
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
                new Flat
                {
                    Street = "Гастелло",
                    District = "Дубово",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceArr = new int[] {27000, 737705},
                    CurrencyID = 0,
                    ApplicationUserID = 0,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false
                },
            };
            Flats.ForEach(g => context.Flats.Add(g));
            context.SaveChanges();

            List<Photo> Photos = new List<Photo>
            {
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo-gastello-ulitsa__98151584fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo-gastello-ulitsa__98151586fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo-gastello-ulitsa__98151588fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
            };

            Photos.ForEach(g => context.Photos.Add(g));
            context.SaveChanges();

            List<PhotoFlatPivot> PhotoFlatPivots = new List<PhotoFlatPivot>
            {
                new PhotoFlatPivot { FlatID = 0, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 0, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 0, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 1, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 1, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 1, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 2, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 2, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 2, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 3, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 3, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 3, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 5, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 5, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 5, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 7, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 7, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 7, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 0 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 2 }
            };

            PhotoFlatPivots.ForEach(g => context.PhotoFlatPivots.Add(g));
            context.SaveChanges();
        }
    }
}