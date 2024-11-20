using System.ComponentModel.DataAnnotations;

public class User
{
    public int Id { get; set; }

    [Required, EmailAddress, StringLength(100)]
    public string Email { get; set; }

    [Required, MinLength(8)]
    public string Password { get; set; }
}
