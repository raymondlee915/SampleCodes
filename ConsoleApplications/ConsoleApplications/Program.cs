using System;
using System.Globalization;
using System.Threading;

/// <summary>
/// This is from:
/// http://msdn.microsoft.com/query/dev12.query?appId=Dev12IDEF1&l=EN-US&k=k(System.StringComparison);k(StringComparison);k(SolutionItemsProject);k(SolutionItemsProject);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.5);k(DevLang-csharp)&rd=true
/// </summary>
public class Example
{
    public static void Main()
    {
        ////string fileUrl = "file";
        ////Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        ////Console.WriteLine("Culture = {0}",
        ////                  Thread.CurrentThread.CurrentCulture.DisplayName);
        ////Console.WriteLine("(file == FILE) = {0}",
        ////                 fileUrl.StartsWith("FILE", true, null));
        ////Console.WriteLine();

        ////Thread.CurrentThread.CurrentCulture = new CultureInfo("tr-TR");
        ////Console.WriteLine("Culture = {0}",
        ////                  Thread.CurrentThread.CurrentCulture.DisplayName);
        ////Console.WriteLine("(file == FILE) = {0}",
        ////                  fileUrl.StartsWith("FILE", true, null));

        ////string str1 = "Aa";
        ////string str2 = "A" + new String('\u0000', 3) + "a";
        ////Console.WriteLine("Comparing '{0}' ({1}) and '{2}' ({3}):",
        ////                  str1, ShowBytes(str1), str2, ShowBytes(str2));
        ////Console.WriteLine("   With String.Compare:");
        ////Console.WriteLine("      Current Culture: {0}",
        ////                  String.Compare(str1, str2, StringComparison.CurrentCulture));
        ////Console.WriteLine("      Invariant Culture: {0}",
        ////                  String.Compare(str1, str2, StringComparison.InvariantCulture));
        ////Console.WriteLine("      Ordinal: {0}",
        ////                 String.Compare(str1, str2, StringComparison.Ordinal));

        ////Console.WriteLine("   With String.Equals:");
        ////Console.WriteLine("      Current Culture: {0}",
        ////                  String.Equals(str1, str2, StringComparison.CurrentCulture));
        ////Console.WriteLine("      Invariant Culture: {0}",
        ////                  String.Equals(str1, str2, StringComparison.InvariantCulture));
        ////Console.WriteLine("      Ordinal: {0}",
        ////                 String.Equals(str1, str2, StringComparison.Ordinal));

        //string separated = "\u0061\u030a";
        //string combined = "\u00e5";

        //Console.WriteLine("Equal sort weight of {0} and {1} using InvariantCulture: {2}",
        //                  separated, combined,
        //                  String.Compare(separated, combined,
        //                                 StringComparison.InvariantCulture) == 0);

        //Console.WriteLine("Equal sort weight of {0} and {1} using Ordinal: {2}",
        //                  separated, combined,
        //                  String.Compare(separated, combined,
        //                                 StringComparison.Ordinal) == 0);
        String[] cultureNames = { "en-US", "se-SE" };
        String[] strings1 = { "case",  "encyclopædia",  
                            "encyclopædia", "Archæology" };
        String[] strings2 = { "Case", "encyclopaedia", 
                            "encyclopedia" , "ARCHÆOLOGY" };
        StringComparison[] comparisons = (StringComparison[])Enum.GetValues(typeof(StringComparison));

        foreach (var cultureName in cultureNames)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureName);
            Console.WriteLine("Current Culture: {0}", CultureInfo.CurrentCulture.Name);
            for (int ctr = 0; ctr <= strings1.GetUpperBound(0); ctr++)
            {
                foreach (var comparison in comparisons)
                    Console.WriteLine("   {0} = {1} ({2}): {3}", strings1[ctr],
                                      strings2[ctr], comparison,
                                      String.Equals(strings1[ctr], strings2[ctr], comparison));

                Console.WriteLine();
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }

    private static string ShowBytes(string str)
    {
        string hexString = String.Empty;
        for (int ctr = 0; ctr < str.Length; ctr++)
        {
            string result = String.Empty;
            result = Convert.ToInt32(str[ctr]).ToString("X4");
            result = " " + result.Substring(0, 2) + " " + result.Substring(2, 2);
            hexString += result;
        }
        return hexString.Trim();
    }


}