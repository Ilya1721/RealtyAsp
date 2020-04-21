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
                    Street = "",
                    District = "Озерная",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Велика, двостороння 3х кімнатна квартира у мікрорайоні Озерна. Квартира у житловому стані, частково залишаються меблі. Пластикові вікна, роздільний санвузол, великий коридор та два балкони. Є лічильники на газ, світло та воду. Будинок знаходиться у тихому та затишному місці, поряд дитячий садок, початкова та середні школи, стадіон. До зупинки 5 хвилин пішки. Можливий ТОРГ! За детальною інформацією звертайтесь по телефону (Сергій).",
                    PriceDollar = 30000,
                    PriceGrn = 821918,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 3,
                    AreaSize = 72,
                    Floor = 8,
                    MaxFloor = 9,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "",
                    District = "Центр",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Продам квартиру в самому ЦЕНТРІ міста. Хрущовка. Цегляний будинок. Квартира не кутова. Акуратна, чиста. Роздільні кімнати. М/п вікна. Добре розвинена інфраструктура, поруч школа, садочок, супермаркет, парк. Терміново!",
                    PriceDollar = 22000,
                    PriceGrn = 602740,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 2,
                    AreaSize = 45,
                    Floor = 3,
                    MaxFloor = 5,
                    KitchenSize = 5,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)

                },
                new Flat
                {
                    Street = "",
                    District = "Выставка",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Продам 2-х кімнатну квартиру м.Виставка ,оріентир Темп. Роздільні кімнати, балкон. Квартира в акуратному житловому стані, кухня і санвузол облицьовані плиткою, замінена сантехніка, балкон засклений, на підлозі лінолеум вирівняні стелі. Залишаються вмонтовані меблі. Вдале розташування, поряд зупинка, ринок, дитсадок і школа в 5-ти хвилинах.",
                    PriceDollar = 21800,
                    PriceGrn = 597260,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 2,
                    AreaSize = 46,
                    Floor = 3,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "",
                    District = "Центр",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Квартира в Центрі міста, тепла, суха, не кутова,балкон засклений, кімнати роздільні, санвузол роздільний.,лічильники, 23700 це зі всіма витратами які на себе бере продавець. Цікаве місце розташування робить це обьект цікавим, багато інфраструктури міста поручь. ТЕЛЕФОНУЙТЕ!!!",
                    PriceDollar = 23700,
                    PriceGrn = 649315,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 2,
                    AreaSize = 50,
                    Floor = 9,
                    MaxFloor = 9,
                    KitchenSize = 8,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "",
                    District = "Дубово",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Квартира тепла, суха, цегла, балкон,гарний жилий стан,м.п.вікна, стіни та стеля рівні,тех поверх великий. Поряд школа та садочок, транспортна розв`язка, тихий двір,магазини. ТЕЛЕФОНУЙТЕ!!! ХОРОШИЙ ТОРГ....",
                    PriceDollar = 15000,
                    PriceGrn = 410959,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 1,
                    AreaSize = 36,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "",
                    District = "Выставка",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Нижня Берегова,забудовник ОЗЕРНИЙ-3, м.п. вікна, розводка,шпакльовані стіни,котел, будинок зданий,заселений,лічильники,стяжка,радіатори, вхідні двері замінені. Поряд зона відпочинку,парк, пляж. ТЕЛЕФОНУЙТЕ!!!!!",
                    PriceDollar = 22500,
                    PriceGrn = 616438,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 1,
                    AreaSize = 52,
                    Floor = 3,
                    MaxFloor = 10,
                    KitchenSize = 14,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "Панаса Мирного",
                    District = "Выставка",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Просторная, светлая, теплая квартира. ЖК Панорама на выставке. На этаже есть 2 кладовки: 1 кладовка для бытовых целей, 2 кладовка 4,4 кв / м с окном. Есть выход на крышу и домофон. В доме есть консьерж, домофон и видеонаблюдение. Массажный кабинет, стоматологические клиники, боксерский клуб, парикмахерская и другие услуги. Подъезд оснащен двумя лифтами (грузовой, пассажирский). На территории дома две больших парковки, ТРЦ (сдача в 2020 г.), детская площадка. В пешей доступности стадион, множество магазинов, остановка городского транспорта, продуктовый рынок.",
                    PriceDollar = 60000,
                    PriceGrn = 1643836,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 3,
                    AreaSize = 105,
                    Floor = 14,
                    MaxFloor = 14,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "Проскуровская",
                    District = "Центр",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Центр міста! Капітальний ремонт! Залишається вбудована кухня та шафи купе! Зручне місце розташування, поруч парк Франка! Дет.інф.0974108573",
                    PriceDollar = 40000,
                    PriceGrn = 1095890,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 3,
                    AreaSize = 85.6,
                    Floor = 1,
                    MaxFloor = 9,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "Прибузька",
                    District = "Центр",
                    DistrictType = "Район",
                    House = "",
                    FlatNumber = "",
                    Description = "Зручний поверх. Друга лінія. Недалеко від Максідому. Квартира тепла, некутова. з незакінченим ремонтом. Кімнати окремі. Є вихід з лоджії в обидві кімнати. Лічильники, Для гарячої води є бойлер. Торг можливий.",
                    PriceDollar = 26000,
                    PriceGrn = 712329,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 2,
                    AreaSize = 43,
                    Floor = 3,
                    MaxFloor = 10,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
                },
                new Flat
                {
                    Street = "Прибузька",
                    District = "Центр",
                    DistrictType = "Район",
                    House = "12",
                    FlatNumber = "",
                    Description = "Продається 3 кім. квартира в хорошому" +
                    " житловому стані, не кутова. Роздільні кімнати." +
                    " Розвинена інфраструктура. Поруч садочок та школа, магазини.",
                    PriceDollar = 27000,
                    PriceGrn = 737705,
                    CurrencyID = 1,
                    ApplicationUserID = 1,
                    RoomCount = 3,
                    AreaSize = 56.1,
                    Floor = 5,
                    MaxFloor = 5,
                    KitchenSize = 7,
                    HeaterTypeID = 1,
                    BuildYear = null,
                    IsExhange = false,
                    IsBarter = false,
                    Date = new DateTime(2020, 12, 21, 2, 0, 0)
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
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-ozernaya__110988788fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr__83051186fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr__83051187fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vyistavka__56356217fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vyistavka__56356227fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vyistavka__56356257fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr__107637660fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr__107637665fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo__109489944fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo__109489945fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-dubovo__109489946fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vystavka__103371615fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vystavka__108659404fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vystavka__108659405fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-vystavka__108659406fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr-pribuzka__109649269fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr-pribuzka__109649270fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy-tsentr-pribuzka__109649271fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy__109800466fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy__109800469fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
                new Photo {
                    Image = ImageLoader.
                    ImageToByteArray(Image.
                    FromFile(@"D:\VisualStudio Projects\Realty\Realty\Content\img\realty-prodaja-kvartira-hmelnitskiy__109800471fl.jpg"),
                    ImageFormat.Jpeg),
                    ImageMimeType = "image/jpeg"
                },
            };

            Photos.ForEach(g => context.Photos.Add(g));
            context.SaveChanges();

            List<PhotoFlatPivot> PhotoFlatPivots = new List<PhotoFlatPivot>
            {
                new PhotoFlatPivot { FlatID = 1, PhotoID = 1 },
                new PhotoFlatPivot { FlatID = 1, PhotoID = 2 },
                new PhotoFlatPivot { FlatID = 1, PhotoID = 3 },
                new PhotoFlatPivot { FlatID = 2, PhotoID = 4 },
                new PhotoFlatPivot { FlatID = 3, PhotoID = 5 },
                new PhotoFlatPivot { FlatID = 3, PhotoID = 6 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 7 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 8 },
                new PhotoFlatPivot { FlatID = 4, PhotoID = 9 },
                new PhotoFlatPivot { FlatID = 5, PhotoID = 10 },
                new PhotoFlatPivot { FlatID = 5, PhotoID = 11 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 12 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 13 },
                new PhotoFlatPivot { FlatID = 6, PhotoID = 14 },
                new PhotoFlatPivot { FlatID = 7, PhotoID = 15 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 16 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 17 },
                new PhotoFlatPivot { FlatID = 8, PhotoID = 18 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 19 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 20 },
                new PhotoFlatPivot { FlatID = 9, PhotoID = 21 },
                new PhotoFlatPivot { FlatID = 10, PhotoID = 22 },
                new PhotoFlatPivot { FlatID = 10, PhotoID = 23 },
                new PhotoFlatPivot { FlatID = 10, PhotoID = 24 }
            };

            PhotoFlatPivots.ForEach(g => context.PhotoFlatPivots.Add(g));
            context.SaveChanges();
        }
    }
}