using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;

namespace DatabaseRelationGraph.DataAccess
{
    public static class DataLayer
    {
        public static DatabaseInfo ParseToDTO(string filename, bool hasHeader)
        {
            DatabaseInfo info = new DatabaseInfo();
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                bool headerRow = hasHeader;
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();

                    if (headerRow)
                    {
                        headerRow = false;
                        continue;
                    }

                    info.TableNames.Add(fields[0]);
                    info.TableNames.Add(fields[1]);
                    if (!info.ForeignKeys.TryGetValue(fields[0], out HashSet<Key> keySet))
                    {
                        keySet = new HashSet<Key>();
                        info.ForeignKeys.Add(fields[0], keySet);
                    }

                    keySet.Add(new Key(fields[0], fields[1]));
                }
            }

            return info;
        }
    }
}
