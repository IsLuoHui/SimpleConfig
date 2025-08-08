using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;


namespace SimpleConfig
{
    #region CSV表格结构

    public class ChapterConfig
    {
        public int Index { get; set; }
        public string ChapterSubTitle { get; set; }
        public string IllustrationPath { get; set; }
        public string ChapterTitle { get; set; }
        public string ChapterShortInfo { get; set; }
        public string MainColor { get; set; }
    }

    public class MusicConfig
    {
        public string MusicName { get; set; }
        public string Title { get; set; }
        public string Composer { get; set; }
        public string Illustrator { get; set; }
        public string IllustrationPath { get; set; }
        public float StartPreviewTime { get; set; }
        public float EndPreviewTime { get; set; }
        public string Chapter { get; set; }
        public int Order { get; set; }
        public int ChapterIndex { get; set; }
    }

    public class ChartInfo
    {
        public string MusicName { get; set; }
        public string Chapter { get; set; }
        public string Charter { get; set; }
        public string HardText { get; set; }
        public string HardNumber { get; set; }
        public string ChartPath { get; set; }
        public string UnlockLogic { get; set; }
        public string FinishLogic { get; set; }
        public int HardIndex { get; set; }
        public int ChapterIndex { get; set; }
    }

    #endregion

    internal class ConfigData
    {
        public List<ChapterConfig> Chapters { get; set; }
        public List<MusicConfig> Musics { get; set; }
        public List<ChartInfo> Charts { get; set; }

        public ConfigData()
        {
            Chapters = new List<ChapterConfig>();
            Musics = new List<MusicConfig>();
            Charts = new List<ChartInfo>();
        }

        private static List<T> ReadConfigCSV<T>(string csvPath)
        {
            try
            {
                using (var reader = new StreamReader(csvPath))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true,
                    MissingFieldFound = null // 忽略缺失字段
                }))
                {
                    return new List<T>(csv.GetRecords<T>());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"读取 CSV 文件失败：{csvPath}\n错误信息：{ex.Message}");
                return new List<T>();
            }
        }

        private static void SaveConfigCSV<T>(List<T> data, string csvPath)
        {
            try
            {
                using (var writer = new StreamWriter(csvPath, false, new System.Text.UTF8Encoding(true)))
                using (var csv = new CsvWriter(writer, new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true
                }))
                {
                    csv.WriteRecords(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"保存 CSV 文件失败：{csvPath}\n错误信息：{ex.Message}");
            }
        }

        public static ConfigData LoadAllConfig(string path)
        {
            //D:\User\Desktop\SimpleArtResources\Config
            string chapterPath = path + "\\Config\\Config_Chapter.csv";
            string musicPath = path + "\\Config\\Config_Music.csv";
            string chartPath = path + "\\Config\\Config_Chart.csv";
            return new ConfigData
            {
                Chapters = ReadConfigCSV<ChapterConfig>(chapterPath),
                Musics = ReadConfigCSV<MusicConfig>(musicPath),
                Charts = ReadConfigCSV<ChartInfo>(chartPath)
            };
        }

        public static void SaveAllConfig(ConfigData data, string path)
        {
            string chapterPath = path + "\\Config\\Config_Chapter.csv";
            string musicPath = path + "\\Config\\Config_Music.csv";
            string chartPath = path + "\\Config\\Config_Chart.csv";
            SaveConfigCSV(data.Chapters, chapterPath);
            SaveConfigCSV(data.Musics, musicPath);
            SaveConfigCSV(data.Charts, chartPath);
        }
    }
}
