using System.Reflection;
using System.Text;
using static TypeMerger.EnumClass;

namespace TypeMerger
{
    public class Deserialize1
    {
        //string fileName = @"..\..\..\..\jsonFile.txt";

        //public string DeserializeObject(string json)
        public string DeserializeObject<T>(string json, ref T objectToDeserialize)        
        {
            StringBuilder str_builder_Obj2 = new();

            string[] authorInfoForVirgul = json.Split((char)Sign.Virgul);


            string[] authorInfoForSusuluParantez = json.Split((char)Sign.SusluParantezKapat);
            int freq = authorInfoForSusuluParantez[0].Count(_ => (_ == ':')); // 5 property için 5 yazdırması lazım

            int objectNumber;
            
            for (int i = 0; i < authorInfoForVirgul.Length; i += freq)
            {
                objectNumber = (i + freq) / freq;

                str_builder_Obj2.Append($"{objectNumber}. Obje");

                str_builder_Obj2.AppendLine();


                for (int iq = 0; iq < objectToDeserialize?.GetType().GetProperties().Length; iq++)
                {
                    
                    foreach (string item in authorInfoForVirgul[i..(i + freq)])
                    {
                        string ikiNoktaIleAyır = item.Substring(item.IndexOf(((char)Sign.IkiNokta) + " ") + 1);

                        string str = ikiNoktaIleAyır.Split('"', '"')[1];

                        str_builder_Obj2.AppendLine($"{objectToDeserialize.GetType().GetProperties()[iq++].Name} Value: {str}");

                    }
                }

                str_builder_Obj2.AppendLine();
            }
                        
            return str_builder_Obj2.ToString();

        }





        public string DeserializeObject2<T, X>(string json, ref T objectToDeserialize, ref X objectToDeserialize2)        
        {
            StringBuilder str_builder_Obj2 = new();

            string[] authorInfoForVirgul = json.Split((char)Sign.Virgul);


            string[] authorInfoForSusuluParantez = json.Split((char)Sign.SusluParantezKapat);
            int freq = authorInfoForSusuluParantez[0].Count(_ => (_ == ':')); // 5 property için 5 yazdırması lazım

            int objectNumber;

            for (int i = 0; i < authorInfoForVirgul.Length; i += freq)
            {
                objectNumber = (i + freq) / freq;

                str_builder_Obj2.Append($"{objectNumber}. Obje");

                str_builder_Obj2.AppendLine();


                if (i%2==0)
                {
                    for (int iq = 0; iq < objectToDeserialize?.GetType().GetProperties().Length; iq++)
                    {

                        foreach (string item in authorInfoForVirgul[i..(i + freq)])
                        {
                            string ikiNoktaIleAyır = item.Substring(item.IndexOf(((char)Sign.IkiNokta) + " ") + 1);

                            string str = ikiNoktaIleAyır.Split('"', '"')[1];

                            str_builder_Obj2.AppendLine($"{objectToDeserialize.GetType().GetProperties()[iq++].Name} Value: {str}");

                        }
                    }
                }
                else
                {
                    for (int iq = 0; iq < objectToDeserialize2?.GetType().GetProperties().Length; iq++)
                    {

                        foreach (string item in authorInfoForVirgul[i..(i + freq)])
                        {
                            string ikiNoktaIleAyır = item.Substring(item.IndexOf(((char)Sign.IkiNokta) + " ") + 1);

                            string str = ikiNoktaIleAyır.Split('"', '"')[1];

                            str_builder_Obj2.AppendLine($"{objectToDeserialize2.GetType().GetProperties()[iq++].Name} Value: {str}");

                        }
                    }
                }

                str_builder_Obj2.AppendLine();
            }

            return str_builder_Obj2.ToString();

        }

    }
}
