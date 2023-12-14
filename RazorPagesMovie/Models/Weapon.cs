using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Models;

public class Weapon
{
    public int ID{get; set;}
    public string Name{get; set;}

    public string? Description{get; set;}

    public int Damage{get; set;}

    public decimal Range{get; set;}
}