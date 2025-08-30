using Entities.Common;
using Entities.Models.Auth;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models.Workspace;

public class Workspace : DatetimeProvider
{
    public string? Title { get; set; }
    
    public string? Description { get; set; }
    
    public string? Logo { get; set; }
    
    public string? Email { get; set; }
    
    public string? Phone { get; set; }
    
    public string? Website { get; set; }
    
    public bool? Enable { get; set; }

    /** Relations */
    [ForeignKey(nameof(CreatedUser))]
    public string? CreatedUserId { get; set; }   // <-- Guid yerine string; User.Id ile aynı tip olmalı

    public User? CreatedUser { get; set; }
}