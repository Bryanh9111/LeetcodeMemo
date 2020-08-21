using System;
using Mapster;
using LeetcodeMemoApp_V1.Model;
using LeetcodeMemoApp_V1.Model.MapsterConfig;
using LeetcodeMemoApp_V1.Utility;
using LeetcodeMemoApp_V1.Entity;

namespace LeetcodeMemoApp_V1
{
    class Program
    {
        static void Main(string[] args)
        {
            //setup mapster
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.IgnoreCase);
            TypeAdapterConfig<string, byte[]>.NewConfig().MapWith(str => str != null ? Convert.FromBase64String(str) : null);
            TypeAdapterConfig<byte[], string>.NewConfig().MapWith(str => str != null ? Convert.ToBase64String(str) : null);
            TypeAdapterConfig.GlobalSettings.LeetcodeMemoNewConfig();

            DatabaseProvider dp = new DatabaseProvider();

            //Helper.DealWithCSV(AppSettings.FolderLoction);
            //dp.CopyTempLeetcodetoLeetcode();

            ////find a note
            //string val;
            //Console.Write("Enter integer: ");
            //val = Console.ReadLine();
            //var result = dp.GetLeetcodeMemoEntityByIndex(Convert.ToInt32(val));
            //if (result != null)
            //{
            //    Console.WriteLine(result.ProblemIndex + ": " + result.ProblemName);
            //    Console.WriteLine("SubmitCount: " + result.SubmitCount);
            //    Console.WriteLine("Note: " + result.Note);
            //}
            //else
            //{
            //    Console.WriteLine("Not done yet");
            //}
            //Console.ReadKey();


            //update note
            var record = dp.GetLeetcodeMemoEntityByIndex(17).Adapt<LeetcodeMemoModel>();
            record.Last_Acted_On = DateTime.Now;
            record.SubmitCount += 1;
            record.Note = "Backtracking: track is empty string, select list is digits, use an offset to record track length, because each track length should be same as digits";
            dp.UpdateLeetcodeMemoEntity(record);
        }
    }
}
