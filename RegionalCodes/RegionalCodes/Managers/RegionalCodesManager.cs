using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using RegionalCode.Entities;
using System.Text;
using Newtonsoft.Json;
using System.Linq;

namespace RegionalCodes.Managers
{
    class RegionalCodesManager
    {

        //private static RegionalCodesManager _regionalCodesManager;

        //public static RegionalCodesManager Current => _regionalCodesManager ?? (_regionalCodesManager = new RegionalCodesManager());

        public static List<string> CodesForDictionary { get; set; } = new List<string>();
        public static void FillCodesForDictionary()
        {
            CodesForDictionary = new List<string>();

            foreach (var regCode in RegionalCodes.Select(x=>x.Region).Distinct())
            {
                CodesForDictionary.Add(
                    ( regCode + " — " + 
                        string.Join(", ",RegionalCodes
                         .Where(x => x.Region == regCode)
                         .Select(x=>x.Code)))
                    );
            }
        }

        public static List<RegionalCode.Entities.RegionalCode> RegionalCodes { get; set; } =
            new List<RegionalCode.Entities.RegionalCode>();

        public static void FillRegionalCodes()
        {
            RegionalCodes = new List<RegionalCode.Entities.RegionalCode> { 
                
        new RegionalCode.Entities.RegionalCode(01 ," Адыгея Респ.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(02 ," Башкортостан Респ.                                       ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(102," Башкортостан Респ.                                       ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(702," Башкортостан Респ.                                       ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(03 ," Бурятия Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(103," Бурятия Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(04 ," Алтай Респ.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(05 ," Дагестан Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(06 ," Ингушетия Респ.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(07 ," Кабард.-Балкарск. Респ.                                   ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(08 ," Калмыкия Респ.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(09 ," Карачаево-Черкесс. Респ.                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(10 ," Карелия Респ.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(11 ," Коми Респ.                                               ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(12 ," Марий Эл Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(13 ," Мордовия Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(113," Мордовия Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(14 ," Саха(Якутия) Респ.                                       ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(15 ," Северн. Осетия—Алания Респ.                               ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(16 ," Татарстан Респ.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(116," Татарстан Респ.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(716," Татарстан Респ.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(17 ," Тыва Респ.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(18 ," Удмуртская Респ.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(19 ," Респ. Хакасия                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(21 ," Чувашская Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(121," Чувашская Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(122," Чувашская Респ.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(22 ," Алтайский кр.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(23 ," Краснодарский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(93 ," Краснодарский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(123," Краснодарский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(193," Краснодарский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(24 ," Красноярский кр.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(88 ," Красноярский кр.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(84 ," Красноярский кр.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(124," Красноярский кр.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(25 ," Приморский кр.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(125," Приморский кр.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(26 ," Ставропольский кр.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(126," Ставропольский кр.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(27 ," Хабаровский кр.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(28 ," Амурская обл.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(29 ," Архангельская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(30 ," Астраханская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(31 ," Белгородская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(32 ," Брянская обл.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(33 ," Владимирская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(34 ," Волгоградская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(134," Волгоградская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(35 ," Вологодская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(36 ," Воронежская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(136," Воронежская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(37 ," Ивановская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(38 ," Иркутская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(85 ," Иркутская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(138," Иркутская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(39 ," Калининградская обл.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(91 ," Калининградская обл.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(40 ," Калужская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(41 ," Камчатский кр.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(42 ," Кемеровская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(142," Кемеровская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(43 ," Кировская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(44 ," Костромская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(45 ," Курганская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(46 ," Курская обл.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(47 ," Ленинградская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(147," Ленинградская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(48 ," Липецкая обл.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(49 ," Магаданская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(50 ," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(90 ," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(150," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(190," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(750," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(790," Московская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(51 ," Мурманская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(52 ," Нижегородская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(152," Нижегородская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(53 ," Новгородская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(54 ," Новосибирская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(154," Новосибирская обл.                                        ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(55 ," Омская обл.                                               ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(56 ," Оренбургская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(156," Оренбургская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(57 ," Орловская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(58 ," Пензенская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(59 ," Пермский кр.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(81 ," Пермский кр.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(159," Пермский кр.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(60 ," Псковская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(61 ," Ростовская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(161," Ростовская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(761," Ростовская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(62 ," Рязанская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(63 ," Самарская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(163," Самарская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(763," Самарская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(64 ," Саратовская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(164," Саратовская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(65 ," Сахалинская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(66 ," Свердловская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(96 ," Свердловская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(196," Свердловская обл.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(67 ," Смоленская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(68 ," Тамбовская обл.                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(69 ," Тверская обл.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(70 ," Томская обл.                                              ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(71 ," Тульская обл.                                             ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(72 ," Тюменская обл.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(73 ," Ульяновская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(173," Ульяновская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(174," Ульяновская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(774," Ульяновская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(74 ," Челябинская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(75 ," Забайкальский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(80 ," Забайкальский кр.                                         ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(76 ," Ярославская обл.                                          ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(77 ," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(97 ," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(99 ," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(177," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(197," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(199," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(777," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(799," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(797," Москва г.                                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(78 ," Санкт - Петербург г.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(98 ," Санкт - Петербург г.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(178," Санкт - Петербург г.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(198," Санкт - Петербург г.                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(79 ," Еврейская автономная обл.                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(82 ," Крым Респ.                                                ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(83 ," Ненецкий авт. округ                                       ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(86 ," Ханты-Манс. авт. округ—Югра                               ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(186," Ханты - Манс.авт.округ—Югра                               ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(87 ," Чукотский авт. округ                                      ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(89 ," Ямало-Ненецкий авт. округ                                 ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(92 ," Севастополь г.                                            ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(94 ," За пределами РФ                                           ".Trim())  ,
        new RegionalCode.Entities.RegionalCode(95 ," Чеченская Респ.                                           ".Trim())  


    };
        }

    }
}
