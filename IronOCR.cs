using IronOcr;

namespace DemoIronOcr;

public static class IronOCRDemo
    {

        public static void IronOCRMultiple(FileInfo file, string? outputpath)
        {
            string fileName = file.Name.Split('.')[0];
            string ocredFilesPath= $@"{outputpath}\{file.Directory.Parent.Name}"; ;
            
        
            var ocrTesseract = new IronTesseract();
           
            //ocrTesseract.Configuration.RenderSearchablePdfsAndHocr=true;                        
            ocrTesseract.Language=OcrLanguage.English;
            ocrTesseract.AddSecondaryLanguage(OcrLanguage.Greek);         

            using (StreamWriter tlmLogfile = new(AppSettings.AppTelemetryFilePath, append: true))
            {
                DateTime timeStart = DateTime.Now;
                int pgCount=0;

                using (var ocrInput = new OcrInput())
                {
                    if (file.Extension==".pdf")
                    {
                        try
                        {
                            
                            ocrInput.AddPdf(file.FullName);
                            
                            ocrInput.Deskew();
                            var ocrResult = ocrTesseract.Read(ocrInput);
                            
                             pgCount=ocrResult.Pages.Count();

                            var pdf = PdfDocument.FromFile(file.FullName);
                            if (!Directory.Exists(ocredFilesPath))
                                Directory.CreateDirectory(ocredFilesPath);
                            pgCount=pdf.Pages.Count();

                            ocrResult.SaveAsSearchablePdf(@$"{ocredFilesPath}\{fileName}.pdf");
                            
                            pdf.Dispose();
                                                        
                            file.Delete();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"OCR for the file {file.Name} has failed with a message :{ex.Message}");
                            using StreamWriter logfile = new(AppSettings.ErrorLogFilePath, append: true);
                            logfile.WriteLine($"Error: {(ErrorLogCodeNo)3} - Time: {DateTime.Now} - Folder: {fileName} - Box: {file.Directory.Name} - FullFileName : {file.FullName}");
                            logfile.Close();
                            logfile.Dispose();
                            ocrInput.Dispose();
                        }
                        finally
                        {
                            ocrInput.Dispose();
                        }
                    }
                    
                    else if (file.Extension==".tif" || file.Extension==".tiff")
                    {
                        try
                        {                           
                            ocrInput.AddMultiFrameTiff(file.FullName);                                                          
                            ocrInput.Deskew();
                            
                            var ocrResult = ocrTesseract.Read(ocrInput);
                                                       
                            pgCount =ocrResult.Pages.Count();
                           
                            //var pdf = ImageToPdfConverter.ImageToPdf(file.FullName);
                            
                        if (!Directory.Exists($@"{ocredFilesPath}"))
                                    Directory.CreateDirectory($@"{ocredFilesPath}");
                                ocrResult.SaveAsSearchablePdf(@$"{ocredFilesPath}\{fileName}.pdf");
                        
                            file.Delete();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"OCR for the  file {file.Name} has failed with a message :{ex.Message}");
                            using StreamWriter logfile = new(AppSettings.ErrorLogFilePath, append: true);
                            logfile.WriteLine($"Error: {(ErrorLogCodeNo)2} - Time: {DateTime.Now} - Folder: {fileName} - Box: {file.Directory.Name} - Pages : {pgCount}");
                            logfile.Close();
                            logfile.Dispose();
                            ocrInput.Dispose();

                        }
                        finally
                        {
                            ocrInput.Dispose();
                        }
                    }
                    else
                    {
                        Console.Write($"Unsupported file type for the file {file.Name}");

                    }
                }

                tlmLogfile.WriteLine($"Telemetry: {(TelemetryLogCodeNo)1}  - TimeElapsed(ms): {(DateTime.Now).Subtract(timeStart).Milliseconds} - File: {file.Name} - Box: {file.Directory.Name} - Pages {pgCount}");
                tlmLogfile.Close();
                tlmLogfile.Dispose();
            }
        }

    }
