
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ITDeskSignInResultNameSpace;
public class CheckResultService : ControllerBase
{
    public IActionResult PasswordResult(Microsoft.AspNetCore.Identity.SignInResult result, DateTimeOffset? lockOutEnd)
    {
        if (result.IsLockedOut)
        {
            TimeSpan? timeSpan = lockOutEnd - DateTime.UtcNow;
            if (timeSpan is not null)
                return BadRequest(new { Message = $"Kullanıcınız 3 kere yanlış şifre girişinden  dolayı {Math.Ceiling(timeSpan.Value.TotalMinutes)} dakika kilitlenmiştir." });
        }

        if (result.IsNotAllowed)
        {
            return BadRequest(new { Message = "Mail adresiniz onaylı değil" });
        }
        if (!result.Succeeded)
        {
            return BadRequest(new { Message = "Şifreniz yanlış" });
        }

        return Ok();
    }
}
