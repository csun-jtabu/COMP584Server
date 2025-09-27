using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WorldModel;

[Table("cities")]
public partial class City
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("countryid")]
    public int Countryid { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("longitude")]
    public double Longitude { get; set; }

    [Column("latitude")]
    public double Latitude { get; set; }

    [ForeignKey("Countryid")]
    [InverseProperty("Cities")]
    public virtual Country Country { get; set; } = null!;
}
