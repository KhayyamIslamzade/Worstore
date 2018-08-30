using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Worstore.Entities;

namespace Worstore.Helpers.Functions
{
    public class WordHelperFunctions
    {


        public WordHelperFunctions()
        {

        }

        public List<Meaning> StringToList(string meaning)
        {
            List <Meaning> List=new List<Meaning>();
            int startIndex=0;
            int endIndex=0;
            meaning += meaning + ",";
            for (int i = 0; i < meaning.Length; i++)
            {
                if (meaning[i] == ',')
                {
                    endIndex = i- startIndex;
                    var _meaning = meaning.Substring(startIndex, endIndex);

                    List.Add(new Meaning(){Label = _meaning });


                    startIndex = i+1;
                }
            }

            return List;
        }
    }
}
