﻿namespace BiletHackanton.Models.Dtos.ImageDto.Request
{
    public class CreateImageRequestDto
    {
        public int EventID { get; set; }

        public string? PosterURL { get; set; }
        public string ImageURL { get; set; }

    }
}
