using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObrasBibliográficasAPI.Names
{
    public class names
    {
        private List<String> especialsNames = new List<string> { "FILHO", "FILHA", "NETO", "NETA", "SOBRINHO", "SOBRINHA", "JUNIOR" };
        private List<String> notEspecialsNames = new List<string> { "da", "de", "do", "das", "dos" };

        public string nameProcessPrint(string name)
        {
            string nameResult = "";
            if (!string.IsNullOrEmpty(name))
            {
                var partsName = name.Split(" ").ToList();
                partsName.ForEach(a => a = a.ToLower());
                int partsNameSize = partsName.Count;
                if (partsNameSize > 1)
                {
                    var resultEspecialNames = especialsNames.Where(a => a == partsName[partsNameSize - 1].ToUpper()).FirstOrDefault();
                    if (resultEspecialNames != null)
                    {
                        nameResult = partsName[partsNameSize - 2].ToUpper() + " " + partsName[partsNameSize - 1].ToUpper();
                        partsName.RemoveAt(partsNameSize - 1);
                        partsName.RemoveAt(partsNameSize - 2);
                        if (partsName.Count > 0)
                        {
                            bool firstLoop = true;
                            partsName.ForEach(a =>
                            {
                                if (firstLoop)
                                {
                                    nameResult += ", " + char.ToUpper(a[0]) + a.Substring(1).ToLower();
                                    firstLoop = false;
                                }
                                else
                                {
                                    var containsNotEspecialsNames = notEspecialsNames.Where(a => a.ToUpper() == a.ToUpper()).FirstOrDefault();
                                    if (string.IsNullOrEmpty(containsNotEspecialsNames))
                                    {
                                        nameResult += " " + char.ToUpper(a[0]) + a.Substring(1).ToLower();
                                    }
                                    else
                                    {
                                        nameResult += " " + a.ToLower();

                                    }

                                }

                            });
                            return nameResult;
                        }
                        else
                        {

                            partsName = nameResult.Split(" ").ToList();
                            nameResult = "";
                            partsName.ForEach(a =>
                            {
                                a = a.ToLower();
                            });
                            var letra = partsName.ElementAt(0)[0];
                            return nameResult = partsName.ElementAt(1) + ", " + char.ToUpper(partsName.ElementAt(0)[0]) + partsName.ElementAt(0).Substring(1).ToLower();
                        }
                    }
                    else
                    {
                        nameResult = partsName[partsNameSize - 1].ToUpper() + ",";
                        partsName.RemoveAt(partsNameSize - 1);
                        if (partsName.Count > 0)
                        {

                            partsName.ForEach(a =>
                        {
                            var containsNotEspecialsNames = notEspecialsNames.Where(b => b.ToUpper() == a.ToUpper()).FirstOrDefault();
                            if (string.IsNullOrEmpty(containsNotEspecialsNames))
                            {
                                nameResult += " " + char.ToUpper(a[0]) + a.Substring(1);
                            }
                            else
                            {
                                nameResult += " " + a.ToLower();
                            }

                        });
                            return nameResult;
                        }
                        return null;
                    }
                }
                else
                {
                    return name.ToUpper();
                }

            }
            return null;
        }
    }
}
