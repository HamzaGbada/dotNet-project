using System;
using System.Collections.Generic;

namespace CinemaManager_Hamza.Models.Cinema;

public partial class Movie
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public string Genre { get; set; } = null!;

    public int ProducerId { get; set; }

    public virtual Producer Producer { get; set; } = null!;
}
