using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoIronOcr
{
    public static class AppSettings
    {
        public static string AppDrive = @"D:";
        public static string AppRootDirectoryName = $@"1";
        public static string AppDataSourceDirectoryName = "testdata";
        public static string AppDeliverablesDirectoryName = "Deliverables";
        public static string AppDeliverablesTempDirectoryName = "temp";

        public static string SourceDirectory = $@"{AppDrive}\{AppRootDirectoryName}\{AppDataSourceDirectoryName}";
        public static string DeliverablesPath = $@"{AppDrive}\{AppRootDirectoryName}\{AppDeliverablesDirectoryName}";
        public static string DeliverablesTempPath = $@"{DeliverablesPath}\{AppDeliverablesTempDirectoryName}";

        public static string LogPath = $@"{DeliverablesPath}\logs";
        public static string ErrorLogFilePath = Path.Combine(LogPath, $"errorLog_{DateTime.Now.ToString("yyyyMMdd")}.txt");
        public static string LogFilePath = Path.Combine(LogPath, $"appLog_{DateTime.Now.ToString("yyyyMMdd")}.txt");
        public static string AppTelemetryFilePath = Path.Combine(LogPath, $"appTelemetryLog_{DateTime.Now.ToString("yyyyMMdd")}.txt");

        public static string ConvertedFiles2Tiff = Path.Combine(DeliverablesTempPath, "convertedFiles2Tif");
        public static string SplittedFilesPath = Path.Combine(DeliverablesTempPath, "splitted");
        public static string OCRCompletedFilePath = Path.Combine(DeliverablesPath, "OCRCompleted");
        public static string OCRReadyFilePath = Path.Combine(DeliverablesTempPath, "OCRReady");
        public static string PDFAFilesPath = Path.Combine(DeliverablesPath, "PDFACompleted");
        public static string Splitted2OCRFilePath = Path.Combine(DeliverablesTempPath, "splitted2OCR");

        public static string[] MainArgs1 = new string[] { "all", "cnvpdftif", "cnvjpgtif", "mergepdf", "splitfile", "ocr", "pdfa", "cnvocr", "splitocr", "ocrpdfa", "splitocrpdfa" };

        public static int PdfSizeThreshold = 2097152;
        public static int PdfPagingSize = 30;

        public static string[] selectedFileTypes = new string[] { ".gif", ".jpg", ".tif", ".tiff", ".pdf", };        

    }
}
