using System.Diagnostics;

namespace Worknet.Services
{
    public class CertificateService
    {
        public void GenerateCertificate()
        {
            var process = new Process();

            process.StartInfo.FileName = "python";
            process.StartInfo.Arguments = "scripts/generate_cert.py";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;

            process.Start();
        }
    }
}