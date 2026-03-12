using Microsoft.AspNetCore.Mvc;
using Worknet.Services;

[ApiController]
[Route("api/cryptography")]
public class CryptographyController : ControllerBase
{
    private readonly CertificateService _certificateService;

    public CryptographyController(
        CertificateService certificateService)
    {
        _certificateService = certificateService;
    }
    
// Ze względu na studencki charakter kontrolera, nie ma konieczności przeprowadzania testów automatycznych.
[HttpPost("generate-cert")]
public IActionResult GenerateCert()
{
    _certificateService.GenerateCertificate(); // Aby wyświetlić w przeglądarce, do tego potrzebny jest HTTPS oraz SSL
    return Ok();
}
}