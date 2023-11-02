using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketPlace.DataAccess.Models.CustomMarketPlaceModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MarketPlace.DataAccess.ModelConfigurations.CustomMarketPlaceConfiguration
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {

            builder.HasData(
                new District()
                {
                    Id = 1,
                    Name = "Çukurova",
                    CityId = 1
                },
                new District()
                {
                    Id = 2,
                    Name = "Sarıçam",
                    CityId = 1
                },
                new District()
                {
                    Id = 3,
                    Name = "Seyhan",
                    CityId = 1
                },
                new District()
                {
                    Id = 4,
                    Name = "Yüreğir",
                    CityId = 1
                },
                new District()
                {
                    Id = 5,
                    Name = "Aladağ",
                    CityId = 1
                },
                new District()
                {
                    Id = 6,
                    Name = "Ceyhan",
                    CityId = 1
                },
                new District()
                {
                    Id = 7,
                    Name = "Feke",
                    CityId = 1
                },
                new District()
                {
                    Id = 8,
                    Name = "İmamoğlu",
                    CityId = 1
                },
                new District()
                {
                    Id = 9,
                    Name = "Karaisalı",
                    CityId = 1
                },
                new District()
                {
                    Id = 10,
                    Name = "Karataş",
                    CityId = 1
                },
                new District()
                {
                    Id = 11,
                    Name = "Kozan",
                    CityId = 1
                },
                new District()
                {
                    Id = 12,
                    Name = "Pozantı",
                    CityId = 1
                },
                new District()
                {
                    Id = 13,
                    Name = "Saimbeyli",
                    CityId = 1
                },
                new District()
                {
                    Id = 14,
                    Name = "Tufanbeyli",
                    CityId = 1
                },
                new District()
                {
                    Id = 15,
                    Name = "Yumurtalık",
                    CityId = 1
                },
                new District()
                {
                    Id = 1,
                    Name = "Besni",
                    CityId = 2
                },
                new District()
                {
                    Id = 2,
                    Name = "Çelikhan",
                    CityId = 2
                },
                new District()
                {
                    Id = 3,
                    Name = "Gerger",
                    CityId = 2
                },
                new District()
                {
                    Id = 4,
                    Name = "Gölbaşı",
                    CityId = 2
                },
                new District()
                {
                    Id = 5,
                    Name = "Kahta",
                    CityId = 2
                },
                new District()
                {
                    Id = 6,
                    Name = "Merkez",
                    CityId = 2
                },
                new District()
                {
                    Id = 7,
                    Name = "Samsat",
                    CityId = 2
                },
                new District()
                {
                    Id = 8,
                    Name = "Sincik",
                    CityId = 2
                },
                new District()
                {
                    Id = 9,
                    Name = "Tut",
                    CityId = 2
                },
                new District()
                {
                    Id = 1,
                    Name = "Başmakçı",
                    CityId = 3
                },
                new District()
                {
                    Id = 2,
                    Name = "Bayat",
                    CityId = 3
                },
                new District()
                {
                    Id = 3,
                    Name = "Bolvadin",
                    CityId = 3
                },
                new District()
                {
                    Id = 4,
                    Name = "Çay",
                    CityId = 3
                },
                new District()
                {
                    Id = 5,
                    Name = "Çobanlar",
                    CityId = 3
                },
                new District()
                {
                    Id = 6,
                    Name = "Dazkırı",
                    CityId = 3
                },
                new District()
                {
                    Id = 7,
                    Name = "Dinar",
                    CityId = 3
                },
                new District()
                {
                    Id = 8,
                    Name = "Emirdağ",
                    CityId = 3
                },
                new District()
                {
                    Id = 9,
                    Name = "Evciler",
                    CityId = 3
                },
                new District()
                {
                    Id = 10,
                    Name = "Hocalar",
                    CityId = 3
                },
                new District()
                {
                    Id = 11,
                    Name = "İhsaniye",
                    CityId = 3
                },
                new District()
                {
                    Id = 12,
                    Name = "İscehisar",
                    CityId = 3
                },
                new District()
                {
                    Id = 13,
                    Name = "Kızılören",
                    CityId = 3
                },
                new District()
                {
                    Id = 14,
                    Name = "Merkez",
                    CityId = 3
                },
                new District()
                {
                    Id = 15,
                    Name = "Sandıklı",
                    CityId = 3
                },
                new District()
                {
                    Id = 16,
                    Name = "Sinanpaşa",
                    CityId = 3
                },
                new District()
                {
                    Id = 17,
                    Name = "Sultandağı",
                    CityId = 3
                },
                new District()
                {
                    Id = 18,
                    Name = "Şuhut",
                    CityId = 3
                },
                new District()
                {
                    Id = 1,
                    Name = "Diyadin",
                    CityId = 4
                },
                new District()
                {
                    Id = 2,
                    Name = "Doğubayazıt",
                    CityId = 4
                },
                new District()
                {
                    Id = 3,
                    Name = "Eleşkirt",
                    CityId = 4
                },
                new District()
                {
                    Id = 4,
                    Name = "Hamur",
                    CityId = 4
                },
                new District()
                {
                    Id = 5,
                    Name = "Merkez",
                    CityId = 4
                },
                new District()
                {
                    Id = 6,
                    Name = "Patnos",
                    CityId = 4
                },
                new District()
                {
                    Id = 7,
                    Name = "Taşlıçay",
                    CityId = 4
                },
                new District()
                {
                    Id = 8,
                    Name = "Tutak",
                    CityId = 4
                },
                new District()
                {
                    Id = 1,
                    Name = "Ağaçören",
                    CityId = 81
                },
                new District()
                {
                    Id = 2,
                    Name = "Eskil",
                    CityId = 81
                },
                new District()
                {
                    Id = 3,
                    Name = "Gülağaç",
                    CityId = 81
                },
                new District()
                {
                    Id = 4,
                    Name = "Güzelyurt",
                    CityId = 81
                },
                new District()
                {
                    Id = 5,
                    Name = "Merkez",
                    CityId = 81
                },
                new District()
                {
                    Id = 6,
                    Name = "Ortaköy",
                    CityId = 81
                },
                new District()
                {
                    Id = 7,
                    Name = "Sarıyahşi",
                    CityId = 81
                },
                new District()
                {
                    Id = 8,
                    Name = "Sultanhanı",
                    CityId = 81
                },
                new District()
                {
                    Id = 1,
                    Name = "Göynücek",
                    CityId = 6
                },
                new District()
                {
                    Id = 2,
                    Name = "Gümüşhacıköy",
                    CityId = 6
                },
                new District()
                {
                    Id = 3,
                    Name = "Hamamözü",
                    CityId = 6
                },
                new District()
                {
                    Id = 4,
                    Name = "Merkez",
                    CityId = 6
                },
                new District()
                {
                    Id = 5,
                    Name = "Merzifon",
                    CityId = 6
                },
                new District()
                {
                    Id = 6,
                    Name = "Suluova",
                    CityId = 6
                },
                new District()
                {
                    Id = 7,
                    Name = "Taşova",
                    CityId = 6
                },
                new District()
                {
                    Id = 1,
                    Name = "Akyurt",
                    CityId = 7
                },
                new District()
                {
                    Id = 2,
                    Name = "Altındağ",
                    CityId = 7
                },
                new District()
                {
                    Id = 3,
                    Name = "Ayaş",
                    CityId = 7
                },
                new District()
                {
                    Id = 4,
                    Name = "Bala",
                    CityId = 7
                },
                new District()
                {
                    Id = 5,
                    Name = "Beypazarı",
                    CityId = 7
                },
                new District()
                {
                    Id = 6,
                    Name = "Çamlıdere",
                    CityId = 7
                },
                new District()
                {
                    Id = 7,
                    Name = "Çankaya",
                    CityId = 7
                },
                new District()
                {
                    Id = 8,
                    Name = "Çubuk",
                    CityId = 7
                },
                new District()
                {
                    Id = 9,
                    Name = "Elmadağ",
                    CityId = 7
                },
                new District()
                {
                    Id = 10,
                    Name = "Etimesgut",
                    CityId = 7
                },
                new District()
                {
                    Id = 11,
                    Name = "Evren",
                    CityId = 7
                },
                new District()
                {
                    Id = 12,
                    Name = "Gölbaşı",
                    CityId = 7
                },
                new District()
                {
                    Id = 13,
                    Name = "Güdül",
                    CityId = 7
                },
                new District()
                {
                    Id = 14,
                    Name = "Haymana",
                    CityId = 7
                },
                new District()
                {
                    Id = 15,
                    Name = "Kahramankazan",
                    CityId = 7
                },
                new District()
                {
                    Id = 16,
                    Name = "Kalecik",
                    CityId = 7
                },
                new District()
                {
                    Id = 17,
                    Name = "Keçiören",
                    CityId = 7
                },
                new District()
                {
                    Id = 18,
                    Name = "Kızılcahamam",
                    CityId = 7
                },
                new District()
                {
                    Id = 19,
                    Name = "Mamak",
                    CityId = 7
                },
                new District()
                {
                    Id = 20,
                    Name = "Nallıhan",
                    CityId = 7
                },
                new District()
                {
                    Id = 21,
                    Name = "Polatlı",
                    CityId = 7
                },
                new District()
                {
                    Id = 22,
                    Name = "Pursaklar",
                    CityId = 7
                },
                new District()
                {
                    Id = 23,
                    Name = "Sincan",
                    CityId = 7
                },
                new District()
                {
                    Id = 24,
                    Name = "Şereflikoçhisar",
                    CityId = 7
                },
                new District()
                {
                    Id = 25,
                    Name = "Yenimahalle",
                    CityId = 7
                },
                new District()
                {
                    Id = 1,
                    Name = "Akseki",
                    CityId = 8
                },
                new District()
                {
                    Id = 2,
                    Name = "Aksu",
                    CityId = 8
                },
                new District()
                {
                    Id = 3,
                    Name = "Alanya",
                    CityId = 8
                },
                new District()
                {
                    Id = 4,
                    Name = "Demre",
                    CityId = 8
                },
                new District()
                {
                    Id = 5,
                    Name = "Döşemealtı",
                    CityId = 8
                },
                new District()
                {
                    Id = 6,
                    Name = "Elmalı",
                    CityId = 8
                },
                new District()
                {
                    Id = 7,
                    Name = "Finike",
                    CityId = 8
                },
                new District()
                {
                    Id = 8,
                    Name = "Gazipaşa",
                    CityId = 8
                },
                new District()
                {
                    Id = 9,
                    Name = "Gündoğmuş",
                    CityId = 8
                },
                new District()
                {
                    Id = 10,
                    Name = "İbradı",
                    CityId = 8
                },
                new District()
                {
                    Id = 11,
                    Name = "Kaş",
                    CityId = 8
                },
                new District()
                {
                    Id = 12,
                    Name = "Kemer",
                    CityId = 8
                },
                new District()
                {
                    Id = 13,
                    Name = "Kepez",
                    CityId = 8
                },
                new District()
                {
                    Id = 14,
                    Name = "Konyaaltı",
                    CityId = 8
                },
                new District()
                {
                    Id = 15,
                    Name = "Korkuteli",
                    CityId = 8
                },
                new District()
                {
                    Id = 16,
                    Name = "Kumluca",
                    CityId = 8
                },
                new District()
                {
                    Id = 17,
                    Name = "Manavgat",
                    CityId = 8
                },
                new District()
                {
                    Id = 18,
                    Name = "Muratpaşa",
                    CityId = 8
                },
                new District()
                {
                    Id = 19,
                    Name = "Serik",
                    CityId = 8
                },
                new District()
                {
                    Id = 1,
                    Name = "Çıldır",
                    CityId = 9
                },
                new District()
                {
                    Id = 2,
                    Name = "Damal",
                    CityId = 9
                },
                new District()
                {
                    Id = 3,
                    Name = "Göle",
                    CityId = 9
                },
                new District()
                {
                    Id = 4,
                    Name = "Hanak",
                    CityId = 9
                },
                new District()
                {
                    Id = 5,
                    Name = "Merkez",
                    CityId = 9
                },
                new District()
                {
                    Id = 6,
                    Name = "Posof",
                    CityId = 9
                },
                new District()
                {
                    Id = 1,
                    Name = "Ardanuç",
                    CityId = 10
                },
                new District()
                {
                    Id = 2,
                    Name = "Arhavi",
                    CityId = 10
                },
                new District()
                {
                    Id = 3,
                    Name = "Borçka",
                    CityId = 10
                },
                new District()
                {
                    Id = 4,
                    Name = "Hopa",
                    CityId = 10
                },
                new District()
                {
                    Id = 5,
                    Name = "Kemalpaşa",
                    CityId = 10
                },
                new District()
                {
                    Id = 6,
                    Name = "Merkez",
                    CityId = 10
                },
                new District()
                {
                    Id = 7,
                    Name = "Murgul",
                    CityId = 10
                },
                new District()
                {
                    Id = 8,
                    Name = "Şavşat",
                    CityId = 10
                },
                new District()
                {
                    Id = 9,
                    Name = "Yusufeli",
                    CityId = 10
                },
                new District()
                {
                    Id = 1,
                    Name = "Bozdoğan",
                    CityId = 11
                },
                new District()
                {
                    Id = 2,
                    Name = "Buharkent",
                    CityId = 11
                },
                new District()
                {
                    Id = 3,
                    Name = "Çine",
                    CityId = 11
                },
                new District()
                {
                    Id = 4,
                    Name = "Didim",
                    CityId = 11
                },
                new District()
                {
                    Id = 5,
                    Name = "Efeler",
                    CityId = 11
                },
                new District()
                {
                    Id = 6,
                    Name = "Germencik",
                    CityId = 11
                },
                new District()
                {
                    Id = 7,
                    Name = "İncirliova",
                    CityId = 11
                },
                new District()
                {
                    Id = 8,
                    Name = "Karacasu",
                    CityId = 11
                },
                new District()
                {
                    Id = 9,
                    Name = "Karpuzlu",
                    CityId = 11
                },
                new District()
                {
                    Id = 10,
                    Name = "Koçarlı",
                    CityId = 11
                },
                new District()
                {
                    Id = 11,
                    Name = "Köşk",
                    CityId = 11
                },
                new District()
                {
                    Id = 12,
                    Name = "Kuşadası",
                    CityId = 11
                },
                new District()
                {
                    Id = 13,
                    Name = "Kuyucak",
                    CityId = 11
                },
                new District()
                {
                    Id = 14,
                    Name = "Nazilli",
                    CityId = 11
                },
                new District()
                {
                    Id = 15,
                    Name = "Söke",
                    CityId = 11
                },
                new District()
                {
                    Id = 16,
                    Name = "Sultanhisar",
                    CityId = 11
                },
                new District()
                {
                    Id = 17,
                    Name = "Yenipazar",
                    CityId = 11
                },
                new District()
                {
                    Id = 1,
                    Name = "Altıeylül",
                    CityId = 12
                },
                new District()
                {
                    Id = 2,
                    Name = "Ayvalık",
                    CityId = 12
                },
                new District()
                {
                    Id = 3,
                    Name = "Balya",
                    CityId = 12
                },
                new District()
                {
                    Id = 4,
                    Name = "Bandırma",
                    CityId = 12
                },
                new District()
                {
                    Id = 5,
                    Name = "Bigadiç",
                    CityId = 12
                },
                new District()
                {
                    Id = 6,
                    Name = "Burhaniye",
                    CityId = 12
                },
                new District()
                {
                    Id = 7,
                    Name = "Dursunbey",
                    CityId = 12
                },
                new District()
                {
                    Id = 8,
                    Name = "Edremit",
                    CityId = 12
                },
                new District()
                {
                    Id = 9,
                    Name = "Erdek",
                    CityId = 12
                },
                new District()
                {
                    Id = 10,
                    Name = "Gömeç",
                    CityId = 12
                },
                new District()
                {
                    Id = 11,
                    Name = "Gönen",
                    CityId = 12
                },
                new District()
                {
                    Id = 12,
                    Name = "Havran",
                    CityId = 12
                },
                new District()
                {
                    Id = 13,
                    Name = "İvrindi",
                    CityId = 12
                },
                new District()
                {
                    Id = 14,
                    Name = "Karesi",
                    CityId = 12
                },
                new District()
                {
                    Id = 15,
                    Name = "Kepsut",
                    CityId = 12
                },
                new District()
                {
                    Id = 16,
                    Name = "Manyas",
                    CityId = 12
                },
                new District()
                {
                    Id = 17,
                    Name = "Marmara",
                    CityId = 12
                },
                new District()
                {
                    Id = 18,
                    Name = "Savaştepe",
                    CityId = 12
                },
                new District()
                {
                    Id = 19,
                    Name = "Sındırgı",
                    CityId = 12
                },
                new District()
                {
                    Id = 20,
                    Name = "Susurluk",
                    CityId = 12
                },
                new District()
                {
                    Id = 1,
                    Name = "Altıeylül",
                    CityId = 12
                },
                new District()
                {
                    Id = 2,
                    Name = "Ayvalık",
                    CityId = 12
                },
                new District()
                {
                    Id = 3,
                    Name = "Balya",
                    CityId = 12
                },
                new District()
                {
                    Id = 4,
                    Name = "Bandırma",
                    CityId = 12
                },
                new District()
                {
                    Id = 1,
                    Name = "Beşiri",
                    CityId = 13
                },
                new District()
                {
                    Id = 2,
                    Name = "Gercüş",
                    CityId = 13
                },
                new District()
                {
                    Id = 3,
                    Name = "Hasankeyf",
                    CityId = 13
                },
                new District()
                {
                    Id = 4,
                    Name = "Kozluk",
                    CityId = 13
                },
                new District()
                {
                    Id = 5,
                    Name = "Merkez",
                    CityId = 13
                },
                new District()
                {
                    Id = 6,
                    Name = "Sason",
                    CityId = 13
                },
                new District()
                {
                    Id = 1,
                    Name = "Merkez",
                    CityId = 14
                },
                new District()
                {
                    Id = 2,
                    Name = "Aydıntepe",
                    CityId = 14
                },
                new District()
                {
                    Id = 3,
                    Name = "Demirözü",
                    CityId = 14
                },
                new District()
                {
                    Id = 1,
                    Name = "Bozüyük",
                    CityId = 15
                },
                new District()
                {
                    Id = 2,
                    Name = "Gölpazarı",
                    CityId = 15
                },
                new District()
                {
                    Id = 3,
                    Name = "İnhisar",
                    CityId = 15
                },
                new District()
                {
                    Id = 4,
                    Name = "Osmaneli",
                    CityId = 15
                },
                new District()
                {
                    Id = 5,
                    Name = "Pazaryeri",
                    CityId = 15
                },
                new District()
                {
                    Id = 6,
                    Name = "Söğüt",
                    CityId = 15
                },
                new District()
                {
                    Id = 7,
                    Name = "Yenipazar",
                    CityId = 15
                },
                new District()
                {
                    Id = 8,
                    Name = "Merkez",
                    CityId = 15
                },
                new District()
                {
                    Id = 1,
                    Name = "Adaklı",
                    CityId = 16
                },
                new District()
                {
                    Id = 2,
                    Name = "Genç",
                    CityId = 16
                },
                new District()
                {
                    Id = 3,
                    Name = "Karlıova",
                    CityId = 16
                },
                new District()
                {
                    Id = 4,
                    Name = "Kiğı",
                    CityId = 16
                },
                new District()
                {
                    Id = 5,
                    Name = "Solhan",
                    CityId = 16
                },
                new District()
                {
                    Id = 6,
                    Name = "Yayladere",
                    CityId = 16
                },
                new District()
                {
                    Id = 7,
                    Name = "Yedisu",
                    CityId = 16
                },
                new District()
                {
                    Id = 8,
                    Name = "Merkez",
                    CityId = 16
                },
                new District()
                {
                    Id = 1,
                    Name = "Merkez",
                    CityId = 17
                },
                new District()
                {
                    Id = 2,
                    Name = "Adilcevaz",
                    CityId = 17
                },
                new District()
                {
                    Id = 3,
                    Name = "Ahlat",
                    CityId = 17
                },
                new District()
                {
                    Id = 4,
                    Name = "Güroymak",
                    CityId = 17
                },
                new District()
                {
                    Id = 5,
                    Name = "Hizan",
                    CityId = 17
                },
                new District()
                {
                    Id = 6,
                    Name = "Mutki",
                    CityId = 17
                },
                new District()
                {
                    Id = 7,
                    Name = "Tatvan",
                    CityId = 17
                },
                new District()
                {
                    Id = 1,
                    Name = "Dörtdivan",
                    CityId = 18
                },
                new District()
                {
                    Id = 2,
                    Name = "Gerede",
                    CityId = 18
                },
                new District()
                {
                    Id = 3,
                    Name = "Göynük",
                    CityId = 18
                },
                new District()
                {
                    Id = 4,
                    Name = "Kıbrıscık",
                    CityId = 18
                },
                new District()
                {
                    Id = 5,
                    Name = "Mengen",
                    CityId = 18
                },
                new District()
                {
                    Id = 6,
                    Name = "Mudurnu",
                    CityId = 18
                },
                new District()
                {
                    Id = 7,
                    Name = "Seben",
                    CityId = 18
                },
                new District()
                {
                    Id = 8,
                    Name = "Yeniçağa",
                    CityId = 18
                },
                new District()
                {
                    Id = 9,
                    Name = "Merkez",
                    CityId = 18
                },
                new District()
                {
                    Id = 1,
                    Name = "Ağlasun",
                    CityId = 19
                },
                new District()
                {
                    Id = 2,
                    Name = "Altınyayla",
                    CityId = 19
                },
                new District()
                {
                    Id = 3,
                    Name = "Bucak",
                    CityId = 19
                },
                new District()
                {
                    Id = 4,
                    Name = "Çavdır",
                    CityId = 19
                },
                new District()
                {
                    Id = 5,
                    Name = "Çeltikçi",
                    CityId = 19
                },
                new District()
                {
                    Id = 6,
                    Name = "Gölhisar",
                    CityId = 19
                },
                new District()
                {
                    Id = 7,
                    Name = "Karamanlı",
                    CityId = 19
                },
                new District()
                {
                    Id = 8,
                    Name = "Kemer",
                    CityId = 19
                },
                new District()
                {
                    Id = 9,
                    Name = "Tefenni",
                    CityId = 19
                },
                new District()
                {
                    Id = 10,
                    Name = "Yeşilova",
                    CityId = 19
                },
                new District()
                {
                    Id = 11,
                    Name = "Merkez",
                    CityId = 19
                },
                new District()
                {
                    Id = 1,
                    Name = "Büyükorhan",
                    CityId = 20
                },
                new District()
                {
                    Id = 2,
                    Name = "Gemlik",
                    CityId = 20
                },
                new District()
                {
                    Id = 3,
                    Name = "Gürsu",
                    CityId = 20
                },
                new District()
                {
                    Id = 4,
                    Name = "Harmancık",
                    CityId = 20
                },
                new District()
                {
                    Id = 5,
                    Name = "İnegöl",
                    CityId = 20
                },
                new District()
                {
                    Id = 6,
                    Name = "İznik",
                    CityId = 20
                },
                new District()
                {
                    Id = 7,
                    Name = "Karacabey",
                    CityId = 20
                },
                new District()
                {
                    Id = 8,
                    Name = "Keles",
                    CityId = 20
                },
                new District()
                {
                    Id = 9,
                    Name = "Kestel",
                    CityId = 20
                },
                new District()
                {
                    Id = 10,
                    Name = "Mudanya",
                    CityId = 20
                },
                new District()
                {
                    Id = 11,
                    Name = "Mustafakemalpaşa",
                    CityId = 20
                },
                new District()
                {
                    Id = 12,
                    Name = "Nilüfer",
                    CityId = 20
                },
                new District()
                {
                    Id = 13,
                    Name = "Orhaneli",
                    CityId = 20
                },
                new District()
                {
                    Id = 14,
                    Name = "Orhangazi",
                    CityId = 20
                },
                new District()
                {
                    Id = 15,
                    Name = "Osmangazi",
                    CityId = 20
                },
                new District()
                {
                    Id = 16,
                    Name = "Yenişehir",
                    CityId = 20
                },
                new District()
                {
                    Id = 17,
                    Name = "Yıldırım",
                    CityId = 20
                },
                new District()
                {
                    Id = 1,
                    Name = "Ayvacık",
                    CityId = 21
                },
                new District()
                {
                    Id = 2,
                    Name = "Bayramiç",
                    CityId = 21
                },
                new District()
                {
                    Id = 3,
                    Name = "Biga",
                    CityId = 21
                },
                new District()
                {
                    Id = 4,
                    Name = "Bozcaada",
                    CityId = 21
                },
                new District()
                {
                    Id = 5,
                    Name = "Çan",
                    CityId = 21
                },
                new District()
                {
                    Id = 6,
                    Name = "Eceabat",
                    CityId = 21
                },
                new District()
                {
                    Id = 7,
                    Name = "Ezine",
                    CityId = 21
                },
                new District()
                {
                    Id = 8,
                    Name = "Gelibolu",
                    CityId = 21
                },
                new District()
                {
                    Id = 9,
                    Name = "Gökçeada",
                    CityId = 21
                },
                new District()
                {
                    Id = 10,
                    Name = "Lapseki",
                    CityId = 21
                },
                new District()
                {
                    Id = 11,
                    Name = "Yenice",
                    CityId = 21
                },
                new District()
                {
                    Id = 12,
                    Name = "Merkez",
                    CityId = 21
                },
                new District()
                {
                    Id = 1,
                    Name = "Atkaracalar",
                    CityId = 22
                },
                new District()
                {
                    Id = 2,
                    Name = "Bayramören",
                    CityId = 22
                },
                new District()
                {
                    Id = 3,
                    Name = "Çerkeş",
                    CityId = 22
                },
                new District()
                {
                    Id = 4,
                    Name = "Eldivan",
                    CityId = 22
                },
                new District()
                {
                    Id = 5,
                    Name = "Ilgaz",
                    CityId = 22
                },
                new District()
                {
                    Id = 6,
                    Name = "Kızılırmak",
                    CityId = 22
                },
                new District()
                {
                    Id = 7,
                    Name = "Korgun",
                    CityId = 22
                },
                new District()
                {
                    Id = 8,
                    Name = "Kurşunlu",
                    CityId = 22
                },
                new District()
                {
                    Id = 9,
                    Name = "Orta",
                    CityId = 22
                },
                new District()
                {
                    Id = 10,
                    Name = "Şabanözü",
                    CityId = 22
                },
                new District()
                {
                    Id = 11,
                    Name = "Yapraklı",
                    CityId = 22
                },
                new District()
                {
                    Id = 12,
                    Name = "Merkez",
                    CityId = 22
                },
                new District()
                {
                    Id = 1,
                    Name = "Alaca",
                    CityId = 23
                },
                new District()
                {
                    Id = 2,
                    Name = "Bayat",
                    CityId = 23
                },
                new District()
                {
                    Id = 3,
                    Name = "Boğazkale",
                    CityId = 23
                },
                new District()
                {
                    Id = 4,
                    Name = "Dodurga",
                    CityId = 23
                },
                new District()
                {
                    Id = 5,
                    Name = "İskilip",
                    CityId = 23
                },
                new District()
                {
                    Id = 6,
                    Name = "Kargı",
                    CityId = 23
                },
                new District()
                {
                    Id = 7,
                    Name = "Laçin",
                    CityId = 23
                },
                new District()
                {
                    Id = 8,
                    Name = "Mecitözü",
                    CityId = 23
                },
                new District()
                {
                    Id = 9,
                    Name = "Oğuzlar",
                    CityId = 23
                },
                new District()
                {
                    Id = 10,
                    Name = "Ortaköy",
                    CityId = 23
                },
                new District()
                {
                    Id = 11,
                    Name = "Osmancık",
                    CityId = 23
                },
                new District()
                {
                    Id = 12,
                    Name = "Sungurlu",
                    CityId = 23
                },
                new District()
                {
                    Id = 13,
                    Name = "Uğurludağ",
                    CityId = 23
                },
                new District()
                {
                    Id = 14,
                    Name = "Merkez",
                    CityId = 23
                },
                new District()
                {
                    Id = 1,
                    Name = "Acıpayam",
                    CityId = 24
                },
                new District()
                {
                    Id = 2,
                    Name = "Babadağ",
                    CityId = 24
                },
                new District()
                {
                    Id = 3,
                    Name = "Baklan",
                    CityId = 24
                },
                new District()
                {
                    Id = 4,
                    Name = "Bekilli",
                    CityId = 24
                },
                new District()
                {
                    Id = 5,
                    Name = "Beyağaç",
                    CityId = 24
                },
                new District()
                {
                    Id = 6,
                    Name = "Bozkurt",
                    CityId = 24
                },
                new District()
                {
                    Id = 7,
                    Name = "Buldan",
                    CityId = 24
                },
                new District()
                {
                    Id = 8,
                    Name = "Çal",
                    CityId = 24
                },
                new District()
                {
                    Id = 9,
                    Name = "Çameli",
                    CityId = 24
                },
                new District()
                {
                    Id = 10,
                    Name = "Çardak",
                    CityId = 24
                },
                new District()
                {
                    Id = 11,
                    Name = "Çivril",
                    CityId = 24
                },
                new District()
                {
                    Id = 12,
                    Name = "Güney",
                    CityId = 24
                },
                new District()
                {
                    Id = 13,
                    Name = "Honaz",
                    CityId = 24
                },
                new District()
                {
                    Id = 14,
                    Name = "Kale",
                    CityId = 24
                },
                new District()
                {
                    Id = 15,
                    Name = "Merkezefendi",
                    CityId = 24
                },
                new District()
                {
                    Id = 16,
                    Name = "Pamukkale",
                    CityId = 24
                },
                new District()
                {
                    Id = 17,
                    Name = "Sarayköy",
                    CityId = 24
                },
                new District()
                {
                    Id = 18,
                    Name = "Serinhisar",
                    CityId = 24
                },
                new District()
                {
                    Id = 19,
                    Name = "Tavas",
                    CityId = 24
                },
                new District()
                {
                    Id = 1,
                    Name = "Bağlar",
                    CityId = 25
                },
                new District()
                {
                    Id = 2,
                    Name = "Bismil",
                    CityId = 25
                },
                new District()
                {
                    Id = 3,
                    Name = "Çermik",
                    CityId = 25
                },
                new District()
                {
                    Id = 4,
                    Name = "Çınar",
                    CityId = 25
                },
                new District()
                {
                    Id = 5,
                    Name = "Çüngüş",
                    CityId = 25
                },
                new District()
                {
                    Id = 6,
                    Name = "Dicle",
                    CityId = 25
                },
                new District()
                {
                    Id = 7,
                    Name = "Eğil",
                    CityId = 25
                },
                new District()
                {
                    Id = 8,
                    Name = "Ergani",
                    CityId = 25
                },
                new District()
                {
                    Id = 9,
                    Name = "Hani",
                    CityId = 25
                },
                new District()
                {
                    Id = 10,
                    Name = "Hazro",
                    CityId = 25
                },
                new District()
                {
                    Id = 11,
                    Name = "Kayapınar",
                    CityId = 25
                },
                new District()
                {
                    Id = 12,
                    Name = "Kocaköy",
                    CityId = 25
                },
                new District()
                {
                    Id = 13,
                    Name = "Kulp",
                    CityId = 25
                },
                new District()
                {
                    Id = 14,
                    Name = "Lice",
                    CityId = 25
                },
                new District()
                {
                    Id = 15,
                    Name = "Silvan",
                    CityId = 25
                },
                new District()
                {
                    Id = 16,
                    Name = "Sur",
                    CityId = 25
                },
                new District()
                {
                    Id = 17,
                    Name = "Yenişehir",
                    CityId = 25
                },
                new District()
                {
                    Id = 1,
                    Name = "Akçakoca",
                    CityId = 26
                },
                new District()
                {
                    Id = 2,
                    Name = "Cumayeri",
                    CityId = 26
                },
                new District()
                {
                    Id = 3,
                    Name = "Çilimli",
                    CityId = 26
                },
                new District()
                {
                    Id = 4,
                    Name = "Gölyaka",
                    CityId = 26
                },
                new District()
                {
                    Id = 5,
                    Name = "Gümüşova",
                    CityId = 26
                },
                new District()
                {
                    Id = 6,
                    Name = "Kaynaşlı",
                    CityId = 26
                },
                new District()
                {
                    Id = 7,
                    Name = "Yığılca",
                    CityId = 26
                },
                new District()
                {
                    Id = 8,
                    Name = "Merkez",
                    CityId = 26
                },
                new District()
                {
                    Id = 1,
                    Name = "Merkez",
                    CityId = 27
                },
                new District()
                {
                    Id = 2,
                    Name = "Enez",
                    CityId = 27
                },
                new District()
                {
                    Id = 3,
                    Name = "Havsa",
                    CityId = 27
                },
                new District()
                {
                    Id = 4,
                    Name = "İpsala",
                    CityId = 27
                },
                new District()
                {
                    Id = 5,
                    Name = "Keşan",
                    CityId = 27
                },
                new District()
                {
                    Id = 6,
                    Name = "Lalapaşa",
                    CityId = 27
                },
                new District()
                {
                    Id = 7,
                    Name = "Meriç",
                    CityId = 27
                },
                new District()
                {
                    Id = 8,
                    Name = "Süloğlu",
                    CityId = 27
                },
                new District()
                {
                    Id = 9,
                    Name = "Uzunköprü",
                    CityId = 27
                },
                new District()
                {
                    Id = 1,
                    Name = "Ağın",
                    CityId = 28
                },
                new District()
                {
                    Id = 2,
                    Name = "Alacakaya",
                    CityId = 28
                },
                new District()
                {
                    Id = 3,
                    Name = "Arıcak",
                    CityId = 28
                },
                new District()
                {
                    Id = 4,
                    Name = "Baskil",
                    CityId = 28
                },
                new District()
                {
                    Id = 5,
                    Name = "Karakoçan",
                    CityId = 28
                },
                new District()
                {
                    Id = 6,
                    Name = "Keban",
                    CityId = 28
                },
                new District()
                {
                    Id = 7,
                    Name = "Kovancılar",
                    CityId = 28
                },
                new District()
                {
                    Id = 8,
                    Name = "Maden",
                    CityId = 28
                },
                new District()
                {
                    Id = 9,
                    Name = "Palu",
                    CityId = 28
                },
                new District()
                {
                    Id = 10,
                    Name = "Sivrice",
                    CityId = 28
                },
                new District()
                {
                    Id = 1,
                    Name = "Çayırlı",
                    CityId = 29
                },
                new District()
                {
                    Id = 2,
                    Name = "İliç",
                    CityId = 29
                },
                new District()
                {
                    Id = 3,
                    Name = "Kemah",
                    CityId = 29
                },
                new District()
                {
                    Id = 4,
                    Name = "Kemaliye",
                    CityId = 29
                },
                new District()
                {
                    Id = 5,
                    Name = "Otlukbeli",
                    CityId = 29
                },
                new District()
                {
                    Id = 6,
                    Name = "Refahiye",
                    CityId = 29
                },
                new District()
                {
                    Id = 7,
                    Name = "Tercan",
                    CityId = 29
                },
                new District()
                {
                    Id = 8,
                    Name = "Üzümlü",
                    CityId = 29
                },
                new District()
                {
                    Id = 9,
                    Name = "Merkez",
                    CityId = 29
                },
                new District()
                {
                    Id = 1,
                    Name = "Aşkale",
                    CityId = 30
                },
                new District()
                {
                    Id = 2,
                    Name = "Aziziye",
                    CityId = 30
                },
                new District()
                {
                    Id = 3,
                    Name = "Çat",
                    CityId = 30
                },
                new District()
                {
                    Id = 4,
                    Name = "Hınıs",
                    CityId = 30
                },
                new District()
                {
                    Id = 5,
                    Name = "Horasan",
                    CityId = 30
                },
                new District()
                {
                    Id = 6,
                    Name = "İspir",
                    CityId = 30
                },
                new District()
                {
                    Id = 7,
                    Name = "Karaçoban",
                    CityId = 30
                },
                new District()
                {
                    Id = 8,
                    Name = "Karayazı",
                    CityId = 30
                },
                new District()
                {
                    Id = 9,
                    Name = "Köprüköy",
                    CityId = 30
                },
                new District()
                {
                    Id = 10,
                    Name = "Narman",
                    CityId = 30
                },
                new District()
                {
                    Id = 11,
                    Name = "Oltu",
                    CityId = 30
                },
                new District()
                {
                    Id = 12,
                    Name = "Olur",
                    CityId = 30
                },
                new District()
                {
                    Id = 13,
                    Name = "Palandöken",
                    CityId = 30
                },
                new District()
                {
                    Id = 14,
                    Name = "Pasinler",
                    CityId = 30
                },
                new District()
                {
                    Id = 15,
                    Name = "Pazaryolu",
                    CityId = 30
                },
                new District()
                {
                    Id = 16,
                    Name = "Şenkaya",
                    CityId = 30
                },
                new District()
                {
                    Id = 17,
                    Name = "Tekman",
                    CityId = 30
                },
                new District()
                {
                    Id = 18,
                    Name = "Tortum",
                    CityId = 30
                },
                new District()
                {
                    Id = 19,
                    Name = "Uzundere",
                    CityId = 30
                },
                new District()
                {
                    Id = 20,
                    Name = "Yakutiye",
                    CityId = 30
                },
                new District()
                {
                    Id = 1,
                    Name = "Alpu",
                    CityId = 31
                },
                new District()
                {
                    Id = 2,
                    Name = "Beylikova",
                    CityId = 31
                },
                new District()
                {
                    Id = 3,
                    Name = "Çifteler",
                    CityId = 31
                },
                new District()
                {
                    Id = 4,
                    Name = "Günyüzü",
                    CityId = 31
                },
                new District()
                {
                    Id = 5,
                    Name = "Han",
                    CityId = 31
                },
                new District()
                {
                    Id = 6,
                    Name = "İnönü",
                    CityId = 31
                },
                new District()
                {
                    Id = 7,
                    Name = "Mahmudiye",
                    CityId = 31
                },
                new District()
                {
                    Id = 8,
                    Name = "Mihalgazi",
                    CityId = 31
                },
                new District()
                {
                    Id = 9,
                    Name = "Mihalıççık",
                    CityId = 31
                },
                new District()
                {
                    Id = 10,
                    Name = "Odunpazarı",
                    CityId = 31
                },
                new District()
                {
                    Id = 11,
                    Name = "Sarıcakaya",
                    CityId = 31
                },
                new District()
                {
                    Id = 12,
                    Name = "Seyitgazi",
                    CityId = 31
                },
                new District()
                {
                    Id = 13,
                    Name = "Sivrihisar",
                    CityId = 31
                },
                new District()
                {
                    Id = 14,
                    Name = "Tepebaşı",
                    CityId = 31
                },
                new District()
                {
                    Id = 1,
                    Name = "Araban",
                    CityId = 32
                },
new District()
{
    Id = 2,
    Name = "İslahiye",
    CityId = 32
},
new District()
{
    Id = 3,
    Name = "Karkamış",
    CityId = 32
},
new District()
{
    Id = 4,
    Name = "Nizip",
    CityId = 32
},
new District()
{
    Id = 5,
    Name = "Nurdağı",
    CityId = 32
},
new District()
{
    Id = 6,
    Name = "Oğuzeli",
    CityId = 32
},
new District()
{
    Id = 7,
    Name = "Şahinbey",
    CityId = 32
},
new District()
{
    Id = 8,
    Name = "Şehitkamil",
    CityId = 32
},
new District()
{
    Id = 9,
    Name = "Yavuzeli",
    CityId = 32
},
new District()
{
    Id = 1,
    Name = "Alucra",
    CityId = 33
},
new District()
{
    Id = 2,
    Name = "Bulancak",
    CityId = 33
},
new District()
{
    Id = 3,
    Name = "Çamoluk",
    CityId = 33
},
new District()
{
    Id = 4,
    Name = "Çanakçı",
    CityId = 33
},
new District()
{
    Id = 5,
    Name = "Dereli",
    CityId = 33
},
new District()
{
    Id = 6,
    Name = "Doğankent",
    CityId = 33
},
new District()
{
    Id = 7,
    Name = "Espiye",
    CityId = 33
},
new District()
{
    Id = 8,
    Name = "Eynesil",
    CityId = 33
},
new District()
{
    Id = 9,
    Name = "Görele",
    CityId = 33
},
new District()
{
    Id = 10,
    Name = "Güce",
    CityId = 33
},
new District()
{
    Id = 11,
    Name = "Keşap",
    CityId = 33
},
new District()
{
    Id = 12,
    Name = "Piraziz",
    CityId = 33
},
new District()
{
    Id = 13,
    Name = "Şebinkarahisar",
    CityId = 33
},
new District()
{
    Id = 14,
    Name = "Tirebolu",
    CityId = 33
},
new District()
{
    Id = 15,
    Name = "Yağlıdere",
    CityId = 33
},
new District()
{
    Id = 16,
    Name = "Merkez",
    CityId = 33
},
new District()
{
    Id = 1,
    Name = "Kelkit",
    CityId = 34
},
new District()
{
    Id = 2,
    Name = "Köse",
    CityId = 34
},
new District()
{
    Id = 3,
    Name = "Kürtün",
    CityId = 34
},
new District()
{
    Id = 4,
    Name = "Şiran",
    CityId = 34
},
new District()
{
    Id = 5,
    Name = "Torul",
    CityId = 34
},
new District()
{
    Id = 6,
    Name = "Merkez",
    CityId = 34
},
new District()
{
    Id = 1,
    Name = "Çukurca",
    CityId = 35
},
new District()
{
    Id = 2,
    Name = "Derecik",
    CityId = 35
},
new District()
{
    Id = 3,
    Name = "Şemdinli",
    CityId = 35
},
new District()
{
    Id = 4,
    Name = "Yüksekova",
    CityId = 35
},
new District()
{
    Id = 5,
    Name = "Merkez",
    CityId = 35
},
new District()
{
    Id = 1,
    Name = "Altınözü",
    CityId = 36
},
new District()
{
    Id = 2,
    Name = "Antakya",
    CityId = 36
},
new District()
{
    Id = 3,
    Name = "Arsuz",
    CityId = 36
},
new District()
{
    Id = 4,
    Name = "Belen",
    CityId = 36
},
new District()
{
    Id = 5,
    Name = "Defne",
    CityId = 36
},
new District()
{
    Id = 6,
    Name = "Dörtyol",
    CityId = 36
},
new District()
{
    Id = 7,
    Name = "Erzin",
    CityId = 36
},
new District()
{
    Id = 8,
    Name = "Hassa",
    CityId = 36
},
new District()
{
    Id = 9,
    Name = "İskenderun",
    CityId = 36
},
new District()
{
    Id = 10,
    Name = "Kırıkhan",
    CityId = 36
},
new District()
{
    Id = 11,
    Name = "Kumlu",
    CityId = 36
},
new District()
{
    Id = 12,
    Name = "Payas",
    CityId = 36
},
new District()
{
    Id = 13,
    Name = "Reyhanlı",
    CityId = 36
},
new District()
{
    Id = 14,
    Name = "Samandağ",
    CityId = 36
},
new District()
{
    Id = 15,
    Name = "Yayladağı",
    CityId = 36
},
new District()
{
    Id = 1,
    Name = "Aralık",
    CityId = 37
},
new District()
{
    Id = 2,
    Name = "Karakoyunlu",
    CityId = 37
},
new District()
{
    Id = 3,
    Name = "Tuzluca",
    CityId = 37
},
new District()
{
    Id = 4,
    Name = "Merkez",
    CityId = 37
},
new District()
{
    Id = 1,
    Name = "Aksu",
    CityId = 38
},
new District()
{
    Id = 2,
    Name = "Atabey",
    CityId = 38
},
new District()
{
    Id = 3,
    Name = "Eğirdir",
    CityId = 38
},
new District()
{
    Id = 4,
    Name = "Gelendost",
    CityId = 38
},
new District()
{
    Id = 5,
    Name = "Gönen",
    CityId = 38
},
new District()
{
    Id = 6,
    Name = "Keçiborlu",
    CityId = 38
},
new District()
{
    Id = 7,
    Name = "Senirkent",
    CityId = 38
},
new District()
{
    Id = 8,
    Name = "Sütçüler",
    CityId = 38
},
new District()
{
    Id = 9,
    Name = "Şarkikaraağaç",
    CityId = 38
},
new District()
{
    Id = 10,
    Name = "Uluborlu",
    CityId = 38
},
new District()
{
    Id = 11,
    Name = "Yalvaç",
    CityId = 38
},
new District()
{
    Id = 12,
    Name = "Yenişarbademli",
    CityId = 38
},
new District()
{
    Id = 13,
    Name = "Merkez",
    CityId = 38
},
new District()
{
    Id = 1,
    Name = "Adalar",
    CityId = 39
},
new District()
{
    Id = 2,
    Name = "Arnavutköy",
    CityId = 39
},
new District()
{
    Id = 3,
    Name = "Ataşehir",
    CityId = 39
},
new District()
{
    Id = 4,
    Name = "Avcılar",
    CityId = 39
},
new District()
{
    Id = 5,
    Name = "Bağcılar",
    CityId = 39
},
new District()
{
    Id = 6,
    Name = "Bahçelievler",
    CityId = 39
},
new District()
{
    Id = 7,
    Name = "Bakırköy",
    CityId = 39
},
new District()
{
    Id = 8,
    Name = "Başakşehir",
    CityId = 39
},
new District()
{
    Id = 9,
    Name = "Bayrampaşa",
    CityId = 39
},
new District()
{
    Id = 10,
    Name = "Beşiktaş",
    CityId = 39
},
new District()
{
    Id = 11,
    Name = "Beykoz",
    CityId = 39
},
new District()
{
    Id = 12,
    Name = "Beylikdüzü",
    CityId = 39
},
new District()
{
    Id = 13,
    Name = "Beyoğlu",
    CityId = 39
},
new District()
{
    Id = 14,
    Name = "Büyükçekmece",
    CityId = 39
},
new District()
{
    Id = 15,
    Name = "Çatalca",
    CityId = 39
},
new District()
{
    Id = 16,
    Name = "Çekmeköy",
    CityId = 39
},
new District()
{
    Id = 17,
    Name = "Esenler",
    CityId = 39
},
new District()
{
    Id = 18,
    Name = "Esenyurt",
    CityId = 39
},
new District()
{
    Id = 19,
    Name = "Eyüpsultan",
    CityId = 39
},
new District()
{
    Id = 20,
    Name = "Fatih",
    CityId = 39
},
new District()
{
    Id = 21,
    Name = "Gaziosmanpaşa",
    CityId = 39
},
new District()
{
    Id = 22,
    Name = "Güngören",
    CityId = 39
},
new District()
{
    Id = 23,
    Name = "Kadıköy",
    CityId = 39
},
new District()
{
    Id = 24,
    Name = "Kâğıthane",
    CityId = 39
},
new District()
{
    Id = 25,
    Name = "Kartal",
    CityId = 39
},
new District()
{
    Id = 26,
    Name = "Küçükçekmece",
    CityId = 39
},
new District()
{
    Id = 27,
    Name = "Maltepe",
    CityId = 39
},
new District()
{
    Id = 28,
    Name = "Pendik",
    CityId = 39
},
new District()
{
    Id = 29,
    Name = "Sancaktepe",
    CityId = 39
},
new District()
{
    Id = 30,
    Name = "Sarıyer",
    CityId = 39
},
new District()
{
    Id = 31,
    Name = "Silivri",
    CityId = 39
},
new District()
{
    Id = 32,
    Name = "Sultanbeyli",
    CityId = 39
},
new District()
{
    Id = 33,
    Name = "Sultangazi",
    CityId = 39
},
new District()
{
    Id = 34,
    Name = "Şile",
    CityId = 39
},
new District()
{
    Id = 35,
    Name = "Şişli",
    CityId = 39
},
new District()
{
    Id = 36,
    Name = "Tuzla",
    CityId = 39
},
new District()
{
    Id = 37,
    Name = "Ümraniye",
    CityId = 39
},
new District()
{
    Id = 38,
    Name = "Üsküdar",
    CityId = 39
},
new District()
{
    Id = 39,
    Name = "Zeytinburnu",
    CityId = 39
},
new District()
{
    Id = 1,
    Name = "Aliağa",
    CityId = 40
},
new District()
{
    Id = 2,
    Name = "Balçova",
    CityId = 40
},
new District()
{
    Id = 3,
    Name = "Bayındır",
    CityId = 40
},
new District()
{
    Id = 4,
    Name = "Bayraklı",
    CityId = 40
},
new District()
{
    Id = 5,
    Name = "Bergama",
    CityId = 40
},
new District()
{
    Id = 6,
    Name = "Beydağ",
    CityId = 40
},
new District()
{
    Id = 7,
    Name = "Bornova",
    CityId = 40
},
new District()
{
    Id = 8,
    Name = "Buca",
    CityId = 40
},
new District()
{
    Id = 9,
    Name = "Çeşme",
    CityId = 40
},
new District()
{
    Id = 10,
    Name = "Çiğli",
    CityId = 40
},
new District()
{
    Id = 11,
    Name = "Dikili",
    CityId = 40
},
new District()
{
    Id = 12,
    Name = "Foça",
    CityId = 40
},
new District()
{
    Id = 13,
    Name = "Gaziemir",
    CityId = 40
},
new District()
{
    Id = 14,
    Name = "Güzelbahçe",
    CityId = 40
},
new District()
{
    Id = 15,
    Name = "Karabağlar",
    CityId = 40
},
new District()
{
    Id = 16,
    Name = "Karaburun",
    CityId = 40
},
new District()
{
    Id = 17,
    Name = "Karşıyaka",
    CityId = 40
},
new District()
{
    Id = 18,
    Name = "Kemalpaşa",
    CityId = 40
},
new District()
{
    Id = 19,
    Name = "Kınık",
    CityId = 40
},
new District()
{
    Id = 20,
    Name = "Kiraz",
    CityId = 40
},
new District()
{
    Id = 21,
    Name = "Konak",
    CityId = 40
},
new District()
{
    Id = 22,
    Name = "Menderes",
    CityId = 40
},
new District()
{
    Id = 23,
    Name = "Menemen",
    CityId = 40
},
new District()
{
    Id = 24,
    Name = "Narlıdere",
    CityId = 40
},
new District()
{
    Id = 25,
    Name = "Ödemiş",
    CityId = 40
},
new District()
{
    Id = 26,
    Name = "Seferihisar",
    CityId = 40
},
new District()
{
    Id = 27,
    Name = "Selçuk",
    CityId = 40
},
new District()
{
    Id = 28,
    Name = "Tire",
    CityId = 40
},
new District()
{
    Id = 29,
    Name = "Torbalı",
    CityId = 40
},
new District()
{
    Id = 30,
    Name = "Urla",
    CityId = 40
},
new District()
{
    Id = 1,
    Name = "Afşin",
    CityId = 41
},
new District()
{
    Id = 2,
    Name = "Andırın",
    CityId = 41
},
new District()
{
    Id = 3,
    Name = "Çağlayancerit",
    CityId = 41
},
new District()
{
    Id = 4,
    Name = "Dulkadiroğlu",
    CityId = 41
},
new District()
{
    Id = 5,
    Name = "Ekinözü",
    CityId = 41
},
new District()
{
    Id = 6,
    Name = "Elbistan",
    CityId = 41
},
new District()
{
    Id = 7,
    Name = "Göksun",
    CityId = 41
},
new District()
{
    Id = 8,
    Name = "Nurhak",
    CityId = 41
},
new District()
{
    Id = 9,
    Name = "Onikişubat",
    CityId = 41
},
new District()
{
    Id = 10,
    Name = "Pazarcık",
    CityId = 41
},
new District()
{
    Id = 11,
    Name = "Türkoğlu",
    CityId = 41
},
new District()
{
    Id = 1,
    Name = "Merkez",
    CityId = 42
},
new District()
{
    Id = 2,
    Name = "Eflani",
    CityId = 42
},
new District()
{
    Id = 3,
    Name = "Eskipazar",
    CityId = 42
},
new District()
{
    Id = 4,
    Name = "Ovacık",
    CityId = 42
},
new District()
{
    Id = 5,
    Name = "Safranbolu",
    CityId = 42
},
new District()
{
    Id = 6,
    Name = "Yenice",
    CityId = 42
},
new District()
{
    Id = 1,
    Name = "Merkez",
    CityId = 43
},
new District()
{
    Id = 2,
    Name = "Ayrancı",
    CityId = 43
},
new District()
{
    Id = 3,
    Name = "Başyayla",
    CityId = 43
},
new District()
{
    Id = 4,
    Name = "Ermenek",
    CityId = 43
},
new District()
{
    Id = 5,
    Name = "Kazımkarabekir",
    CityId = 43
},
new District()
{
    Id = 6,
    Name = "Sarıveliler",
    CityId = 43
},
new District()
{
    Id = 1,
    Name = "Merkez",
    CityId = 44
},
new District()
{
    Id = 2,
    Name = "Akyaka",
    CityId = 44
},
new District()
{
    Id = 3,
    Name = "Arpaçay",
    CityId = 44
},
new District()
{
    Id = 4,
    Name = "Digor",
    CityId = 44
},
new District()
{
    Id = 5,
    Name = "Kağızman",
    CityId = 44
},
new District()
{
    Id = 6,
    Name = "Sarıkamış",
    CityId = 44
},
new District()
{
    Id = 7,
    Name = "Selim",
    CityId = 44
},
new District()
{
    Id = 8,
    Name = "Susuz",
    CityId = 44
},
new District()
{
    Id = 1,
    Name = "Merkez",
    CityId = 45
},
new District()
{
    Id = 2,
    Name = "Abana",
    CityId = 45
},
new District()
{
    Id = 3,
    Name = "Ağlı",
    CityId = 45
},
new District()
{
    Id = 4,
    Name = "Araç",
    CityId = 45
},
new District()
{
    Id = 5,
    Name = "Azdavay",
    CityId = 45
},
new District()
{
    Id = 6,
    Name = "Bozkurt",
    CityId = 45
},
new District()
{
    Id = 7,
    Name = "Cide",
    CityId = 45
},
new District()
{
    Id = 8,
    Name = "Çatalzeytin",
    CityId = 45
},
new District()
{
    Id = 9,
    Name = "Daday",
    CityId = 45
},
new District()
{
    Id = 10,
    Name = "Devrekani",
    CityId = 45
},
new District()
{
    Id = 11,
    Name = "Doğanyurt",
    CityId = 45
},
new District()
{
    Id = 12,
    Name = "Hanönü",
    CityId = 45
},
new District()
{
    Id = 13,
    Name = "İhsangazi",
    CityId = 45
},
new District()
{
    Id = 14,
    Name = "İnebolu",
    CityId = 45
},
new District()
{
    Id = 15,
    Name = "Küre",
    CityId = 45
},
new District()
{
    Id = 16,
    Name = "Pınarbaşı",
    CityId = 45
},
new District()
{
    Id = 17,
    Name = "Seydiler",
    CityId = 45
},
new District()
{
    Id = 18,
    Name = "Şenpazar",
    CityId = 45
},
new District()
{
    Id = 19,
    Name = "Taşköprü",
    CityId = 45
},
new District()
{
    Id = 20,
    Name = "Tosya",
    CityId = 45
},
new District()
{
    Id = 1,
    Name = "Akkışla",
    CityId = 46
},
new District()
{
    Id = 2,
    Name = "Bünyan",
    CityId = 46
},
new District()
{
    Id = 3,
    Name = "Develi",
    CityId = 46
},
new District()
{
    Id = 4,
    Name = "Felahiye",
    CityId = 46
},
new District()
{
    Id = 5,
    Name = "Hacılar",
    CityId = 46
},
new District()
{
    Id = 6,
    Name = "İncesu",
    CityId = 46
},
new District()
{
    Id = 7,
    Name = "Kocasinan",
    CityId = 46
},
new District()
{
    Id = 8,
    Name = "Melikgazi",
    CityId = 46
},
new District()
{
    Id = 9,
    Name = "Özvatan",
    CityId = 46
},
new District()
{
    Id = 10,
    Name = "Pınarbaşı",
    CityId = 46
},
new District()
{
    Id = 11,
    Name = "Sarıoğlan",
    CityId = 46
},
new District()
{
    Id = 12,
    Name = "Sarız",
    CityId = 46
},
new District()
{
    Id = 13,
    Name = "Talas",
    CityId = 46
},
new District()
{
    Id = 14,
    Name = "Tomarza",
    CityId = 46
},
new District()
{
    Id = 15,
    Name = "Yahyalı",
    CityId = 46
},
new District()
{
    Id = 16,
    Name = "Yeşilhisar",
    CityId = 46
},
new District()
{
    Id = 1,
    Name = "Merkez",
    CityId = 47
},
new District()
{
    Id = 2,
    Name = "Elbeyli",
    CityId = 47
},
new District()
{
    Id = 3,
    Name = "Musabeyli",
    CityId = 47
},
new District()
{
    Id = 4,
    Name = "Polateli",
    CityId = 47
},
new District()
{
    Id = 1,
    Name = "Bahşili",
    CityId = 48
},
new District()
{
    Id = 2,
    Name = "Balışeyh",
    CityId = 48
},
new District()
{
    Id = 3,
    Name = "Çelebi",
    CityId = 48
},
new District()
{
    Id = 4,
    Name = "Delice",
    CityId = 48
},
new District()
{
    Id = 5,
    Name = "Karakeçili",
    CityId = 48
},
new District()
{
    Id = 6,
    Name = "Keskin",
    CityId = 48
},
new District()
{
    Id = 7,
    Name = "Sulakyurt",
    CityId = 48
},
new District()
{
    Id = 8,
    Name = "Yahşihan",
    CityId = 48
},
new District()
{
    Id = 1,
    Name = "Babaeski",
    CityId = 49
},
new District()
{
    Id = 2,
    Name = "Demirköy",
    CityId = 49
},
new District()
{
    Id = 3,
    Name = "Kofçaz",
    CityId = 49
},
new District()
{
    Id = 4,
    Name = "Lüleburgaz",
    CityId = 49
},
new District()
{
    Id = 5,
    Name = "Pehlivanköy",
    CityId = 49
},
new District()
{
    Id = 6,
    Name = "Pınarhisar",
    CityId = 49
},
new District()
{
    Id = 7,
    Name = "Vize",
    CityId = 49
},
new District()
{
    Id = 1,
    Name = "Akçakent",
    CityId = 50
},
new District()
{
    Id = 2,
    Name = "Akpınar",
    CityId = 50
},
new District()
{
    Id = 3,
    Name = "Boztepe",
    CityId = 50
},
new District()
{
    Id = 4,
    Name = "Çiçekdağı",
    CityId = 50
},
new District()
{
    Id = 5,
    Name = "Kaman",
    CityId = 50
},
new District()
{
    Id = 6,
    Name = "Mucur",
    CityId = 50
},
new District()
{
    Id = 1,
    Name = "Başiskele",
    CityId = 51
},
new District()
{
    Id = 2,
    Name = "Çayırova",
    CityId = 51
},
new District()
{
    Id = 3,
    Name = "Darıca",
    CityId = 51
},
new District()
{
    Id = 4,
    Name = "Derince",
    CityId = 51
},
new District()
{
    Id = 5,
    Name = "Dilovası",
    CityId = 51
},
new District()
{
    Id = 6,
    Name = "Gebze",
    CityId = 51
},
new District()
{
    Id = 7,
    Name = "Gölcük",
    CityId = 51
},
new District()
{
    Id = 8,
    Name = "İzmit",
    CityId = 51
},
new District()
{
    Id = 9,
    Name = "Kandıra",
    CityId = 51
},
new District()
{
    Id = 10,
    Name = "Karamürsel",
    CityId = 51
},
new District()
{
    Id = 11,
    Name = "Kartepe",
    CityId = 51
},
new District()
{
    Id = 12,
    Name = "Körfez",
    CityId = 51
},
new District()
{
    Id = 1,
    Name = "Ahırlı",
    CityId = 52
},
new District()
{
    Id = 2,
    Name = "Akören",
    CityId = 52
},
new District()
{
    Id = 3,
    Name = "Akşehir",
    CityId = 52
},
new District()
{
    Id = 4,
    Name = "Altınekin",
    CityId = 52
},
new District()
{
    Id = 5,
    Name = "Beyşehir",
    CityId = 52
},
new District()
{
    Id = 6,
    Name = "Bozkır",
    CityId = 52
},
new District()
{
    Id = 7,
    Name = "Cihanbeyli",
    CityId = 52
},
new District()
{
    Id = 8,
    Name = "Çeltik",
    CityId = 52
},
new District()
{
    Id = 9,
    Name = "Çumra",
    CityId = 52
},
new District()
{
    Id = 10,
    Name = "Derbent",
    CityId = 52
},
new District()
{
    Id = 11,
    Name = "Derebucak",
    CityId = 52
},
new District()
{
    Id = 12,
    Name = "Doğanhisar",
    CityId = 52
},
new District()
{
    Id = 13,
    Name = "Emirgazi",
    CityId = 52
},
new District()
{
    Id = 14,
    Name = "Ereğli",
    CityId = 52
},
new District()
{
    Id = 15,
    Name = "Güneysınır",
    CityId = 52
},
new District()
{
    Id = 16,
    Name = "Hadim",
    CityId = 52
},
new District()
{
    Id = 17,
    Name = "Halkapınar",
    CityId = 52
},
new District()
{
    Id = 18,
    Name = "Hüyük",
    CityId = 52
},
new District()
{
    Id = 19,
    Name = "Ilgın",
    CityId = 52
},
new District()
{
    Id = 20,
    Name = "Kadınhanı",
    CityId = 52
},
new District()
{
    Id = 21,
    Name = "Karapınar",
    CityId = 52
},
new District()
{
    Id = 22,
    Name = "Karatay",
    CityId = 52
},
new District()
{
    Id = 23,
    Name = "Kulu",
    CityId = 52
},
new District()
{
    Id = 24,
    Name = "Meram",
    CityId = 52
},
new District()
{
    Id = 25,
    Name = "Sarayönü",
    CityId = 52
},
new District()
{
    Id = 26,
    Name = "Selçuklu",
    CityId = 52
},
new District()
{
    Id = 27,
    Name = "Seydişehir",
    CityId = 52
},
new District()
{
    Id = 28,
    Name = "Taşkent",
    CityId = 52
},
new District()
{
    Id = 29,
    Name = "Tuzlukçu",
    CityId = 52
},
new District()
{
    Id = 30,
    Name = "Yalıhüyük",
    CityId = 52
},
new District()
{
    Id = 31,
    Name = "Yunak",
    CityId = 52
},
new District()
{
    Id = 1,
    Name = "Altıntaş",
    CityId = 53
},
new District()
{
    Id = 2,
    Name = "Aslanapa",
    CityId = 53
},
new District()
{
    Id = 3,
    Name = "Çavdarhisar",
    CityId = 53
},
new District()
{
    Id = 4,
    Name = "Domaniç",
    CityId = 53
},
new District()
{
    Id = 5,
    Name = "Dumlupınar",
    CityId = 53
},
new District()
{
    Id = 6,
    Name = "Emet",
    CityId = 53
},
new District()
{
    Id = 7,
    Name = "Gediz",
    CityId = 53
},
new District()
{
    Id = 8,
    Name = "Hisarcık",
    CityId = 53
},
new District()
{
    Id = 9,
    Name = "Pazarlar",
    CityId = 53
},
new District()
{
    Id = 10,
    Name = "Simav",
    CityId = 53
},
new District()
{
    Id = 11,
    Name = "Şaphane",
    CityId = 53
},
new District()
{
    Id = 12,
    Name = "Tavşanlı",
    CityId = 53
},
new District()
{
    Id = 1,
    Name = "Akçadağ",
    CityId = 54
},
new District()
{
    Id = 2,
    Name = "Arapgir",
    CityId = 54
},
new District()
{
    Id = 3,
    Name = "Arguvan",
    CityId = 54
},
new District()
{
    Id = 4,
    Name = "Battalgazi",
    CityId = 54
},
new District()
{
    Id = 5,
    Name = "Darende",
    CityId = 54
},
new District()
{
    Id = 6,
    Name = "Doğanşehir",
    CityId = 54
},
new District()
{
    Id = 7,
    Name = "Doğanyol",
    CityId = 54
},
new District()
{
    Id = 8,
    Name = "Hekimhan",
    CityId = 54
},
new District()
{
    Id = 9,
    Name = "Kale",
    CityId = 54
},
new District()
{
    Id = 10,
    Name = "Kuluncak",
    CityId = 54
},
new District()
{
    Id = 11,
    Name = "Pütürge",
    CityId = 54
},
new District()
{
    Id = 12,
    Name = "Yazıhan",
    CityId = 54
},
new District()
{
    Id = 13,
    Name = "Yeşilyurt",
    CityId = 54
},
new District()
{
    Id = 1,
    Name = "Ahmetli",
    CityId = 55
},
new District()
{
    Id = 2,
    Name = "Akhisar",
    CityId = 55
},
new District()
{
    Id = 3,
    Name = "Alaşehir",
    CityId = 55
},
new District()
{
    Id = 4,
    Name = "Demirci",
    CityId = 55
},
new District()
{
    Id = 5,
    Name = "Gölmarmara",
    CityId = 55
},
new District()
{
    Id = 6,
    Name = "Gördes",
    CityId = 55
},
new District()
{
    Id = 7,
    Name = "Kırkağaç",
    CityId = 55
},
new District()
{
    Id = 8,
    Name = "Köprübaşı",
    CityId = 55
},
new District()
{
    Id = 9,
    Name = "Kula",
    CityId = 55
},
new District()
{
    Id = 10,
    Name = "Salihli",
    CityId = 55
},
new District()
{
    Id = 11,
    Name = "Sarıgöl",
    CityId = 55
},
new District()
{
    Id = 12,
    Name = "Saruhanlı",
    CityId = 55
},
new District()
{
    Id = 13,
    Name = "Selendi",
    CityId = 55
},
new District()
{
    Id = 14,
    Name = "Soma",
    CityId = 55
},
new District()
{
    Id = 15,
    Name = "Şehzadeler",
    CityId = 55
},
new District()
{
    Id = 16,
    Name = "Turgutlu",
    CityId = 55
},
new District()
{
    Id = 17,
    Name = "Yunusemre",
    CityId = 55
},
new District()
{
    Id = 1,
    Name = "Artuklu",
    CityId = 56
},
new District()
{
    Id = 2,
    Name = "Dargeçit",
    CityId = 56
},
new District()
{
    Id = 3,
    Name = "Derik",
    CityId = 56
},
new District()
{
    Id = 4,
    Name = "Kızıltepe",
    CityId = 56
},
new District()
{
    Id = 5,
    Name = "Mazıdağı",
    CityId = 56
},
new District()
{
    Id = 6,
    Name = "Midyat",
    CityId = 56
},
new District()
{
    Id = 7,
    Name = "Nusaybin",
    CityId = 56
},
new District()
{
    Id = 8,
    Name = "Ömerli",
    CityId = 56
},
new District()
{
    Id = 9,
    Name = "Savur",
    CityId = 56
},
new District()
{
    Id = 10,
    Name = "Yeşilli",
    CityId = 56
},
new District()
{
    Id = 1,
    Name = "Akdeniz",
    CityId = 57
},
new District()
{
    Id = 2,
    Name = "Anamur",
    CityId = 57
},
new District()
{
    Id = 3,
    Name = "Aydıncık",
    CityId = 57
},
new District()
{
    Id = 4,
    Name = "Bozyazı",
    CityId = 57
},
new District()
{
    Id = 5,
    Name = "Çamlıyayla",
    CityId = 57
},
new District()
{
    Id = 6,
    Name = "Erdemli",
    CityId = 57
},
new District()
{
    Id = 7,
    Name = "Gülnar",
    CityId = 57
},
new District()
{
    Id = 8,
    Name = "Mezitli",
    CityId = 57
},
new District()
{
    Id = 9,
    Name = "Mut",
    CityId = 57
},
new District()
{
    Id = 10,
    Name = "Silifke",
    CityId = 57
},
new District()
{
    Id = 11,
    Name = "Tarsus",
    CityId = 57
},
new District()
{
    Id = 12,
    Name = "Toroslar",
    CityId = 57
},
new District()
{
    Id = 13,
    Name = "Yenişehir",
    CityId = 57
},
new District()
{
    Id = 1,
    Name = "Bodrum",
    CityId = 58
},
new District()
{
    Id = 2,
    Name = "Dalaman",
    CityId = 58
},
new District()
{
    Id = 3,
    Name = "Datça",
    CityId = 58
},
new District()
{
    Id = 4,
    Name = "Fethiye",
    CityId = 58
},
new District()
{
    Id = 5,
    Name = "Kavaklıdere",
    CityId = 58
},
new District()
{
    Id = 6,
    Name = "Köyceğiz",
    CityId = 58
},
new District()
{
    Id = 7,
    Name = "Marmaris",
    CityId = 58
},
new District()
{
    Id = 8,
    Name = "Menteşe",
    CityId = 58
},
new District()
{
    Id = 9,
    Name = "Milas",
    CityId = 58
},
new District()
{
    Id = 10,
    Name = "Ortaca",
    CityId = 58
},
new District()
{
    Id = 11,
    Name = "Seydikemer",
    CityId = 58
},
new District()
{
    Id = 12,
    Name = "Ula",
    CityId = 58
},
new District()
{
    Id = 13,
    Name = "Yatağan",
    CityId = 58
},
new District()
{
    Id = 1,
    Name = "Bulanık",
    CityId = 59
},
new District()
{
    Id = 2,
    Name = "Hasköy",
    CityId = 59
},
new District()
{
    Id = 3,
    Name = "Korkut",
    CityId = 59
},
new District()
{
    Id = 4,
    Name = "Malazgirt",
    CityId = 59
},
new District()
{
    Id = 5,
    Name = "Varto",
    CityId = 59
},
new District()
{
    Id = 1,
    Name = "Acıgöl",
    CityId = 60
},
new District()
{
    Id = 2,
    Name = "Avanos",
    CityId = 60
},
new District()
{
    Id = 3,
    Name = "Derinkuyu",
    CityId = 60
},
new District()
{
    Id = 4,
    Name = "Gülşehir",
    CityId = 60
},
new District()
{
    Id = 5,
    Name = "Hacıbektaş",
    CityId = 60
},
new District()
{
    Id = 6,
    Name = "Kozaklı",
    CityId = 60
},
new District()
{
    Id = 7,
    Name = "Nevşehir",
    CityId = 60
},
new District()
{
    Id = 8,
    Name = "Ürgüp",
    CityId = 60
},
new District()
{
    Id = 1,
    Name = "Altunhisar",
    CityId = 61
},
new District()
{
    Id = 2,
    Name = "Bor",
    CityId = 61
},
new District()
{
    Id = 3,
    Name = "Çamardı",
    CityId = 61
},
new District()
{
    Id = 4,
    Name = "Çiftlik",
    CityId = 61
},
new District()
{
    Id = 5,
    Name = "Ulukışla",
    CityId = 61
},
new District()
{
    Id = 1,
    Name = "Akkuş",
    CityId = 62
},
new District()
{
    Id = 2,
    Name = "Altınordu",
    CityId = 62
},
new District()
{
    Id = 3,
    Name = "Aybastı",
    CityId = 62
},
new District()
{
    Id = 4,
    Name = "Çamaş",
    CityId = 62
},
new District()
{
    Id = 5,
    Name = "Çatalpınar",
    CityId = 62
},
new District()
{
    Id = 6,
    Name = "Çaybaşı",
    CityId = 62
},
new District()
{
    Id = 7,
    Name = "Fatsa",
    CityId = 62
},
new District()
{
    Id = 8,
    Name = "Gölköy",
    CityId = 62
},
new District()
{
    Id = 9,
    Name = "Gülyalı",
    CityId = 62
},
new District()
{
    Id = 10,
    Name = "Gürgentepe",
    CityId = 62
},
new District()
{
    Id = 11,
    Name = "İkizce",
    CityId = 62
},
new District()
{
    Id = 12,
    Name = "Kabadüz",
    CityId = 62
},
new District()
{
    Id = 13,
    Name = "Kabataş",
    CityId = 62
},
new District()
{
    Id = 14,
    Name = "Korgan",
    CityId = 62
},
new District()
{
    Id = 15,
    Name = "Kumru",
    CityId = 62
},
new District()
{
    Id = 16,
    Name = "Mesudiye",
    CityId = 62
},
new District()
{
    Id = 17,
    Name = "Perşembe",
    CityId = 62
},
new District()
{
    Id = 18,
    Name = "Ulubey",
    CityId = 62
},
new District()
{
    Id = 19,
    Name = "Ünye",
    CityId = 62
},
new District()
{
    Id = 1,
    Name = "Bahçe",
    CityId = 63
},
new District()
{
    Id = 2,
    Name = "Düziçi",
    CityId = 63
},
new District()
{
    Id = 3,
    Name = "Hasanbeyli",
    CityId = 63
},
new District()
{
    Id = 4,
    Name = "Kadirli",
    CityId = 63
},
new District()
{
    Id = 5,
    Name = "Sumbas",
    CityId = 63
},
new District()
{
    Id = 6,
    Name = "Toprakkale",
    CityId = 63
},
new District()
{
    Id = 1,
    Name = "Ardeşen",
    CityId = 64
},
new District()
{
    Id = 2,
    Name = "Çamlıhemşin",
    CityId = 64
},
new District()
{
    Id = 3,
    Name = "Çayeli",
    CityId = 64
},
new District()
{
    Id = 4,
    Name = "Derepazarı",
    CityId = 64
},
new District()
{
    Id = 5,
    Name = "Fındıklı",
    CityId = 64
},
new District()
{
    Id = 6,
    Name = "Güneysu",
    CityId = 64
},
new District()
{
    Id = 7,
    Name = "Hemşin",
    CityId = 64
},
new District()
{
    Id = 8,
    Name = "İkizdere",
    CityId = 64
},
new District()
{
    Id = 9,
    Name = "İyidere",
    CityId = 64
},
new District()
{
    Id = 10,
    Name = "Kalkandere",
    CityId = 64
},
new District()
{
    Id = 11,
    Name = "Pazar",
    CityId = 64
},
new District()
{
    Id = 1,
    Name = "Adapazarı",
    CityId = 65
},
new District()
{
    Id = 2,
    Name = "Akyazı",
    CityId = 65
},
new District()
{
    Id = 3,
    Name = "Arifiye",
    CityId = 65
},
new District()
{
    Id = 4,
    Name = "Erenler",
    CityId = 65
},
new District()
{
    Id = 5,
    Name = "Ferizli",
    CityId = 65
},
new District()
{
    Id = 6,
    Name = "Geyve",
    CityId = 65
},
new District()
{
    Id = 7,
    Name = "Hendek",
    CityId = 65
},
new District()
{
    Id = 8,
    Name = "Karapürçek",
    CityId = 65
},
new District()
{
    Id = 9,
    Name = "Karasu",
    CityId = 65
},
new District()
{
    Id = 10,
    Name = "Kaynarca",
    CityId = 65
},
new District()
{
    Id = 11,
    Name = "Kocaali",
    CityId = 65
},
new District()
{
    Id = 12,
    Name = "Pamukova",
    CityId = 65
},
new District()
{
    Id = 13,
    Name = "Sapanca",
    CityId = 65
},
new District()
{
    Id = 14,
    Name = "Serdivan",
    CityId = 65
},
new District()
{
    Id = 15,
    Name = "Söğütlü",
    CityId = 65
},
new District()
{
    Id = 16,
    Name = "Taraklı",
    CityId = 65
},

new District()
{
    Id = 1,
    Name = "19 Mayıs",
    CityId = 66
},
new District()
{
    Id = 2,
    Name = "Alaçam",
    CityId = 66
},
new District()
{
    Id = 3,
    Name = "Asarcık",
    CityId = 66
},
new District()
{
    Id = 4,
    Name = "Atakum",
    CityId = 66
},
new District()
{
    Id = 5,
    Name = "Ayvacık",
    CityId = 66
},
new District()
{
    Id = 6,
    Name = "Bafra",
    CityId = 66
},
new District()
{
    Id = 7,
    Name = "Canik",
    CityId = 66
},
new District()
{
    Id = 8,
    Name = "Çarşamba",
    CityId = 66
},
new District()
{
    Id = 9,
    Name = "Havza",
    CityId = 66
},
new District()
{
    Id = 10,
    Name = "İlkadım",
    CityId = 66
},
new District()
{
    Id = 11,
    Name = "Kavak",
    CityId = 66
},
new District()
{
    Id = 12,
    Name = "Ladik",
    CityId = 66
},
new District()
{
    Id = 13,
    Name = "Ondokuzmayıs",
    CityId = 66
},
new District()
{
    Id = 14,
    Name = "Salıpazarı",
    CityId = 66
},
new District()
{
    Id = 15,
    Name = "Tekkeköy",
    CityId = 66
},
new District()
{
    Id = 16,
    Name = "Terme",
    CityId = 66
},
new District()
{
    Id = 17,
    Name = "Vezirköprü",
    CityId = 66
},
new District()
{
    Id = 18,
    Name = "Yakakent",
    CityId = 66
},
new District()
{
    Id = 1,
    Name = "Baykan",
    CityId = 67
},
new District()
{
    Id = 2,
    Name = "Eruh",
    CityId = 67
},
new District()
{
    Id = 3,
    Name = "Kurtalan",
    CityId = 67
},
new District()
{
    Id = 4,
    Name = "Pervari",
    CityId = 67
},
new District()
{
    Id = 5,
    Name = "Şirvan",
    CityId = 67
},
new District()
{
    Id = 6,
    Name = "Tillo",
    CityId = 67
},

new District()
{
    Id = 1,
    Name = "Ayancık",
    CityId = 68
},
new District()
{
    Id = 2,
    Name = "Boyabat",
    CityId = 68
},
new District()
{
    Id = 3,
    Name = "Dikmen",
    CityId = 68
},
new District()
{
    Id = 4,
    Name = "Durağan",
    CityId = 68
},
new District()
{
    Id = 5,
    Name = "Erfelek",
    CityId = 68
},
new District()
{
    Id = 6,
    Name = "Gerze",
    CityId = 68
},
new District()
{
    Id = 7,
    Name = "Saraydüzü",
    CityId = 68
},
new District()
{
    Id = 8,
    Name = "Türkeli",
    CityId = 68
},
new District()
{
    Id = 9,
    Name = "Merkez",
    CityId = 68
},

new District()
{
    Id = 1,
    Name = "Akıncılar",
    CityId = 69
},
new District()
{
    Id = 2,
    Name = "Altınyayla",
    CityId = 69
},
new District()
{
    Id = 3,
    Name = "Divriği",
    CityId = 69
},
new District()
{
    Id = 4,
    Name = "Doğanşar",
    CityId = 69
},
new District()
{
    Id = 5,
    Name = "Gemerek",
    CityId = 69
},
new District()
{
    Id = 6,
    Name = "Gölova",
    CityId = 69
},
new District()
{
    Id = 7,
    Name = "Hafik",
    CityId = 69
},
new District()
{
    Id = 8,
    Name = "İmranlı",
    CityId = 69
},
new District()
{
    Id = 9,
    Name = "Kangal",
    CityId = 69
},
new District()
{
    Id = 10,
    Name = "Koyulhisar",
    CityId = 69
},
new District()
{
    Id = 11,
    Name = "Şarkışla",
    CityId = 69
},
new District()
{
    Id = 12,
    Name = "Suşehri",
    CityId = 69
},
new District()
{
    Id = 13,
    Name = "Ulaş",
    CityId = 69
},
new District()
{
    Id = 14,
    Name = "Yıldızeli",
    CityId = 69
},
new District()
{
    Id = 15,
    Name = "Zara",
    CityId = 69
},

new District()
{
    Id = 1,
    Name = "Akçakale",
    CityId = 70
},
new District()
{
    Id = 2,
    Name = "Birecik",
    CityId = 70
},
new District()
{
    Id = 3,
    Name = "Bozova",
    CityId = 70
},
new District()
{
    Id = 4,
    Name = "Ceylanpınar",
    CityId = 70
},
new District()
{
    Id = 5,
    Name = "Halfeti",
    CityId = 70
},
new District()
{
    Id = 6,
    Name = "Harran",
    CityId = 70
},
new District()
{
    Id = 7,
    Name = "Hilvan",
    CityId = 70
},
new District()
{
    Id = 8,
    Name = "Karaköprü",
    CityId = 70
},
new District()
{
    Id = 9,
    Name = "Siverek",
    CityId = 70
},
new District()
{
    Id = 10,
    Name = "Suruç",
    CityId = 70
},
new District()
{
    Id = 11,
    Name = "Viranşehir",
    CityId = 70
},
new District()
{
    Id = 1,
    Name = "Beytüşşebap",
    CityId = 71
},
new District()
{
    Id = 2,
    Name = "Cizre",
    CityId = 71
},
new District()
{
    Id = 3,
    Name = "Güçlükonak",
    CityId = 71
},
new District()
{
    Id = 4,
    Name = "İdil",
    CityId = 71
},
new District()
{
    Id = 5,
    Name = "Silopi",
    CityId = 71
},
new District()
{
    Id = 6,
    Name = "Uludere",
    CityId = 71
},
new District()
{
    Id = 1,
    Name = "Çerkezköy",
    CityId = 72
},
new District()
{
    Id = 2,
    Name = "Çorlu",
    CityId = 72
},
new District()
{
    Id = 3,
    Name = "Ergene",
    CityId = 72
},
new District()
{
    Id = 4,
    Name = "Hayrabolu",
    CityId = 72
},
new District()
{
    Id = 5,
    Name = "Kapaklı",
    CityId = 72
},
new District()
{
    Id = 6,
    Name = "Malkara",
    CityId = 72
},
new District()
{
    Id = 7,
    Name = "Marmara Ereğlisi",
    CityId = 72
},
new District()
{
    Id = 8,
    Name = "Muratlı",
    CityId = 72
},
new District()
{
    Id = 9,
    Name = "Saray",
    CityId = 72
},
new District()
{
    Id = 10,
    Name = "Şarköy",
    CityId = 72
},
new District()
{
    Id = 1,
    Name = "Almus",
    CityId = 73
},
new District()
{
    Id = 2,
    Name = "Artova",
    CityId = 73
},
new District()
{
    Id = 3,
    Name = "Başçiftlik",
    CityId = 73
},
new District()
{
    Id = 4,
    Name = "Erbaa",
    CityId = 73
},
new District()
{
    Id = 5,
    Name = "Niksar",
    CityId = 73
},
new District()
{
    Id = 6,
    Name = "Pazar",
    CityId = 73
},
new District()
{
    Id = 7,
    Name = "Reşadiye",
    CityId = 73
},
new District()
{
    Id = 8,
    Name = "Sulusaray",
    CityId = 73
},
new District()
{
    Id = 9,
    Name = "Turhal",
    CityId = 73
},
new District()
{
    Id = 10,
    Name = "Yeşilyurt",
    CityId = 73
},
new District()
{
    Id = 11,
    Name = "Zile",
    CityId = 73
},
new District()
{
    Id = 1,
    Name = "Akçaabat",
    CityId = 74
},
new District()
{
    Id = 2,
    Name = "Araklı",
    CityId = 74
},
new District()
{
    Id = 3,
    Name = "Arsin",
    CityId = 74
},
new District()
{
    Id = 4,
    Name = "Beşikdüzü",
    CityId = 74
},
new District()
{
    Id = 5,
    Name = "Çarşıbaşı",
    CityId = 74
},
new District()
{
    Id = 6,
    Name = "Çaykara",
    CityId = 74
},
new District()
{
    Id = 7,
    Name = "Dernekpazarı",
    CityId = 74
},
new District()
{
    Id = 8,
    Name = "Düzköy",
    CityId = 74
},
new District()
{
    Id = 9,
    Name = "Hayrat",
    CityId = 74
},
new District()
{
    Id = 10,
    Name = "Köprübaşı",
    CityId = 74
},
new District()
{
    Id = 11,
    Name = "Maçka",
    CityId = 74
},
new District()
{
    Id = 12,
    Name = "Of",
    CityId = 74
},
new District()
{
    Id = 13,
    Name = "Sürmene",
    CityId = 74
},
new District()
{
    Id = 14,
    Name = "Şalpazarı",
    CityId = 74
},
new District()
{
    Id = 15,
    Name = "Tonya",
    CityId = 74
},
new District()
{
    Id = 16,
    Name = "Vakfıkebir",
    CityId = 74
},
new District()
{
    Id = 17,
    Name = "Yomra",
    CityId = 74
},
new District()
{
    Id = 1,
    Name = "Çemişgezek",
    CityId = 75
},
new District()
{
    Id = 2,
    Name = "Hozat",
    CityId = 75
},
new District()
{
    Id = 3,
    Name = "Mazgirt",
    CityId = 75
},
new District()
{
    Id = 4,
    Name = "Nazımiye",
    CityId = 75
},
new District()
{
    Id = 5,
    Name = "Ovacık",
    CityId = 75
},
new District()
{
    Id = 6,
    Name = "Pertek",
    CityId = 75
},
new District()
{
    Id = 7,
    Name = "Pülümür",
    CityId = 75
},
new District()
{
    Id = 1,
    Name = "Banaz",
    CityId = 76
},
new District()
{
    Id = 2,
    Name = "Eşme",
    CityId = 76
},
new District()
{
    Id = 3,
    Name = "Karahallı",
    CityId = 76
},
new District()
{
    Id = 4,
    Name = "Sivaslı",
    CityId = 76
},
new District()
{
    Id = 5,
    Name = "Ulubey",
    CityId = 76
},
new District()
{
    Id = 1,
    Name = "Bahçesaray",
    CityId = 77
},
new District()
{
    Id = 2,
    Name = "Başkale",
    CityId = 77
},
new District()
{
    Id = 3,
    Name = "Çaldıran",
    CityId = 77
},
new District()
{
    Id = 4,
    Name = "Çatak",
    CityId = 77
},
new District()
{
    Id = 5,
    Name = "Edremit",
    CityId = 77
},
new District()
{
    Id = 6,
    Name = "Erciş",
    CityId = 77
},
new District()
{
    Id = 7,
    Name = "Gevaş",
    CityId = 77
},
new District()
{
    Id = 8,
    Name = "Gürpınar",
    CityId = 77
},
new District()
{
    Id = 9,
    Name = "İpekyolu",
    CityId = 77
},
new District()
{
    Id = 10,
    Name = "Muradiye",
    CityId = 77
},
new District()
{
    Id = 11,
    Name = "Özalp",
    CityId = 77
},
new District()
{
    Id = 12,
    Name = "Saray",
    CityId = 77
},
new District()
{
    Id = 13,
    Name = "Tuşba",
    CityId = 77
},
new District()
{
    Id = 1,
    Name = "Altınova",
    CityId = 78
},
new District()
{
    Id = 2,
    Name = "Armutlu",
    CityId = 78
},
new District()
{
    Id = 3,
    Name = "Çınarcık",
    CityId = 78
},
new District()
{
    Id = 4,
    Name = "Çiftlikköy",
    CityId = 78
},
new District()
{
    Id = 5,
    Name = "Termal",
    CityId = 78
},
new District()
{
    Id = 1,
    Name = "Akdağmadeni",
    CityId = 79
},
new District()
{
    Id = 2,
    Name = "Aydıncık",
    CityId = 79
},
new District()
{
    Id = 3,
    Name = "Boğazlıyan",
    CityId = 79
},
new District()
{
    Id = 4,
    Name = "Çandır",
    CityId = 79
},
new District()
{
    Id = 5,
    Name = "Çayıralan",
    CityId = 79
},
new District()
{
    Id = 6,
    Name = "Çekerek",
    CityId = 79
},
new District()
{
    Id = 7,
    Name = "Kadışehri",
    CityId = 79
},
new District()
{
    Id = 8,
    Name = "Saraykent",
    CityId = 79
},
new District()
{
    Id = 9,
    Name = "Sarıkaya",
    CityId = 79
},
new District()
{
    Id = 10,
    Name = "Sorgun",
    CityId = 79
},
new District()
{
    Id = 11,
    Name = "Şefaatli",
    CityId = 79
},
new District()
{
    Id = 12,
    Name = "Yenifakılı",
    CityId = 79
},
new District()
{
    Id = 13,
    Name = "Yerköy",
    CityId = 79
},
new District()
{
    Id = 1,
    Name = "Alaplı",
    CityId = 80
},
new District()
{
    Id = 2,
    Name = "Çaycuma",
    CityId = 80
},
new District()
{
    Id = 3,
    Name = "Devrek",
    CityId = 80
},
new District()
{
    Id = 4,
    Name = "Gökçebey",
    CityId = 80
},
new District()
{
    Id = 5,
    Name = "Kilimli",
    CityId = 80
},
new District()
{
    Id = 6,
    Name = "Kozlu",
    CityId = 80
},
new District()
{
    Id = 7,
    Name = "Karadeniz Ereğli",
    CityId = 80
},
new District()
{
    Id = 1,
    Name = "Amasya Merkez",
    CityId = 5
},
new District()
{
    Id = 2,
    Name = "Göynücek",
    CityId = 5
},
new District()
{
    Id = 3,
    Name = "Gümüşhacıköy",
    CityId = 5
},
new District()
{
    Id = 4,
    Name = "Hamamözü",
    CityId = 5
},
new District()
{
    Id = 5,
    Name = "Merzifon",
    CityId = 5
},
new District()
{
    Id = 6,
    Name = "Suluova",
    CityId = 5
},
new District()
{
    Id = 7,
    Name = "Taşova",
    CityId = 5
}




































            );
        }
    }
}
