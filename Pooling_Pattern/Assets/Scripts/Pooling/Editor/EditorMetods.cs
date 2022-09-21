using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
/// <summary>
/// referance : https://answers.unity.com/questions/1414634/can-i-add-an-enum-value-in-the-inspector.html
/// </summary>
public class EditorMetods : Editor
{
    const string extension = ".cs";
    public static void WriteToEnum<T>(string path, string name, ICollection<T> data)
    {
        using (StreamWriter file = File.CreateText(path + name + extension))
        {
            file.WriteLine("public enum " + name + " \n{");

            int i = 0;
            foreach (var line in data)
            {
                string lineRep = line.ToString().Replace(" ", string.Empty);
                if (!string.IsNullOrEmpty(lineRep))
                {
                    file.WriteLine(string.Format("\t{0} = {1},",
                        lineRep, i));
                    i++;
                }
            }

            file.WriteLine("\n}");
        }

        AssetDatabase.ImportAsset(path + name + extension);
    }
}
