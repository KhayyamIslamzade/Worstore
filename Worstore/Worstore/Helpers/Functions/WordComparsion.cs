using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using Worstore.Entities;
using Worstore.Helpers.Algorithms;
using Worstore.Models.GeneralHelperFunctionModels;

namespace Worstore.Helpers.Functions
{

    public class UniqueChars
    {

        public char Expected { get; set; }
        public char Entered { get; set; }

    }

    public class WordComparsion
    {
        private List<UniqueChars> _uniqueCharses { get; set; }
        public WordComparsion()
        {
            _uniqueCharses = new List<UniqueChars>();
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'ı',
                Entered = 'i',

            });
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'ö',
                Entered = 'o',

            });
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'İ',
                Entered = 'I',

            });
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'ç',
                Entered = 'c',

            });
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'ş',
                Entered = 's',

            });
            _uniqueCharses.Add(new UniqueChars()
            {
                Expected = 'ğ',
                Entered = 'g',
            });
        }

        public bool Compare(string entered, string compared)
        {
            int tolerance = entered.Length / 2;
            if (LevenshteinDistance.Compute(entered, compared) < tolerance)
            {
                return true;
            }
            else
            {
                foreach (var item in _uniqueCharses)
                {
                    entered = entered.Replace(item.Entered.ToString(), item.Expected.ToString());
                    if (LevenshteinDistance.Compute(entered, compared) < tolerance)
                    {
                        return true;
                    }
                }


                return false;

            }
        }
    }


}
