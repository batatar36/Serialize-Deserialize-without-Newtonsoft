using System.Security.Principal;
using System.Text;
using static TypeMerger.EnumClass;

namespace TypeMerger
{
    public class Serialize1
    {
        public int numberOfObject = 1;
        
        public string SerializeObject<T>(ref T objectToSerialize, List<string> genericList)
        //public string SerializeObject<T>(ref T objectToSerialize)
        {
            StringBuilder str_builder_Obj = new StringBuilder();
            //int numberOfObject = 1;
            //str_builder_Obj.Append("[");
            str_builder_Obj.Append((char)Sign.KoseliParantezAc);


            for (int j = 0; j < numberOfObject; j++)
            {
                str_builder_Obj.AppendLine(" ");
                str_builder_Obj.Append("  " + ((char)Sign.SusluParantezAc));


                for (int i = 0; i < objectToSerialize?.GetType().GetProperties().Length; i++)
                {
                    str_builder_Obj.AppendLine(" ");
                    str_builder_Obj.Append("    " + @"""" + objectToSerialize.GetType().GetProperties()[i].Name + @""""); //  @, escape karakterleri kullandırmıyor 
                    str_builder_Obj.Append(((char)Sign.IkiNokta) + " ");

                    for (int q = 0; q < numberOfObject; q++)
                    {

                        if (j == q && i == 0)
                        {
                            str_builder_Obj.Append(@"""" + genericList[i + j * objectToSerialize.GetType().GetProperties().Length] + @"""");
                        }
                        else
                        {
                            for (int idd = 0; idd < objectToSerialize.GetType().GetProperties().Length; idd++)
                            {
                                if (j == q && i == idd)
                                {
                                    str_builder_Obj.Append(@"""" + genericList[i + j * objectToSerialize.GetType().GetProperties().Length] + @"""");
                                }
                            }
                        }
                    }

                    if (i < objectToSerialize.GetType().GetProperties().Length - 1)
                        str_builder_Obj.Append((char)Sign.Virgul);

                }

                str_builder_Obj.AppendLine(" ");
                str_builder_Obj.Append("  " + ((char)Sign.SusluParantezKapat));

                if (j != numberOfObject - 1)
                    str_builder_Obj.Append((char)Sign.Virgul);

            }

            str_builder_Obj.AppendLine(" ");


            str_builder_Obj.Append((char)Sign.KoseliParantezKapat);


            /*
            string fileName = @"..\..\..\..\jsonFile.json";

            using StreamWriter writer = File.CreateText(fileName);

            writer.WriteLine(str_builder_Obj.ToString());
            */



            return str_builder_Obj.ToString();
        }



        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public int numberOfObject2 = 2;
        public string SerializeObject2<T, X>(ref T objectToSerialize, ref X carObjectToSerialize2, List<string> genericList)
        {
            StringBuilder str_builder_Obj = new StringBuilder();
            //int numberOfObject = 2;
            //str_builder_Obj.Append("[");
            str_builder_Obj.Append((char)Sign.KoseliParantezAc);



            for (int j = 0; j < numberOfObject2; j++)
            {
                //var variableSetting = (j > 1) ? objectToSerialize : carObjectToSerialize2;

                str_builder_Obj.AppendLine(" ");
                //str_builder_Obj.Append("  {");
                str_builder_Obj.Append("  " + ((char)Sign.SusluParantezAc));


                if (j%2 == 0)
                {
                    for (int i = 0; i < objectToSerialize?.GetType().GetProperties().Length; i++)
                    {

                        str_builder_Obj.AppendLine(" ");
                        str_builder_Obj.Append("    " + @"""" + objectToSerialize.GetType().GetProperties()[i].Name + @""""); //  @, escape karakterleri kullandırmıyor 

                        str_builder_Obj.Append(((char)Sign.IkiNokta) + " ");

                        for (int q = 0; q < numberOfObject2; q++)
                        {
                            if (j == q && i == 0)
                            {
                                //str_builder_Obj.Append(@"""" + objectToSerialize.GetType().GetProperty(objectToSerialize.GetType().GetProperties()[i].Name)?.GetValue(objectToSerialize) + @"""");
                                str_builder_Obj.Append(@"""" + genericList[i + j * objectToSerialize.GetType().GetProperties().Length] + @"""");
                            }
                            else
                            {
                                for (int idd = 0; idd < objectToSerialize.GetType().GetProperties().Length; idd++)
                                {
                                    if (j == q && i == idd)
                                    {
                                        //str_builder_Obj.Append(@"""" + objectToSerialize.GetType().GetProperty(objectToSerialize.GetType().GetProperties()[i].Name)?.GetValue(objectToSerialize) + @"""");
                                        str_builder_Obj.Append(@"""" + genericList[i + j * objectToSerialize.GetType().GetProperties().Length] + @"""");
                                    }
                                }
                            }
                        }

                        if (i < objectToSerialize.GetType().GetProperties().Length - 1)
                            str_builder_Obj.Append((char)Sign.Virgul);
                    }
                }
                else
                {
                    for (int i = 0; i < carObjectToSerialize2.GetType().GetProperties().Length; i++)
                    {
                        str_builder_Obj.AppendLine(" ");
                        str_builder_Obj.Append("    " + @"""" + carObjectToSerialize2.GetType().GetProperties()[i].Name + @"""");
                        str_builder_Obj.Append(((char)Sign.IkiNokta) + " ");

                        for (int q = 0; q < numberOfObject2; q++)
                        {

                            if (j == q && i == 0)
                            {
                                //str_builder_Obj.Append(@"""" + carObjectToSerialize2.GetType().GetProperty(carObjectToSerialize2.GetType().GetProperties()[i].Name)?.GetValue(carObjectToSerialize2) + @"""");
                                str_builder_Obj.Append(@"""" + genericList[i + j * carObjectToSerialize2.GetType().GetProperties().Length] + @"""");
                            }
                            else
                            {
                                for (int idd = 0; idd < carObjectToSerialize2.GetType().GetProperties().Length; idd++)
                                {
                                    if (j == q && i == idd)
                                    {
                                        //str_builder_Obj.Append(@"""" + carObjectToSerialize2.GetType().GetProperty(carObjectToSerialize2.GetType().GetProperties()[i].Name)?.GetValue(carObjectToSerialize2) + @"""");
                                        str_builder_Obj.Append(@"""" + genericList[i + j * carObjectToSerialize2.GetType().GetProperties().Length] + @"""");
                                    }
                                }
                            }
                        }

                        if (i < carObjectToSerialize2.GetType().GetProperties().Length - 1)
                            str_builder_Obj.Append((char)Sign.Virgul);
                    }
                }

                str_builder_Obj.AppendLine(" ");
                str_builder_Obj.Append("  " + ((char)Sign.SusluParantezKapat));

                if (j != numberOfObject2 - 1)
                    str_builder_Obj.Append((char)Sign.Virgul);

            }

            str_builder_Obj.AppendLine(" ");


            str_builder_Obj.Append((char)Sign.KoseliParantezKapat);


            /*
            string fileName = @"..\..\..\..\jsonFile.json";

            using StreamWriter writer = File.CreateText(fileName);

            writer.WriteLine(str_builder_Obj.ToString());
            */

            return str_builder_Obj.ToString();
        }

    }
}
