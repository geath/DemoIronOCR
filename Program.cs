namespace DemoIronOcr;
class Program
{
    static void Main(string[] args)
    {
         DirectoryInfo diTop = new DirectoryInfo("C:\1\testdata"); 

        IronOcr.Installation.LicenseKey = "IRONOCR.GIORGOSATHANASOPOULOS.14744-54786B1C94-LDE42PVELBVNK-QVG6T2TF52KR-LHMBPEJRMJME-W3XKPMNVUSWL-J4BS3BXE63PW-JKDK2G-THX77GMB3RGJUA-DEPLOYMENT.TRIAL-BVN66F.TRIAL.EXPIRES.04.JUN.2023"; 
        PerformOCR.IronOCRDemo.IronOCRMultiple(di.GetFiles().FirstOrDefault(), AppSettings.Splitted2OCRFilePath, args[1]);        
        return;
    }
}