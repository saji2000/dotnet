﻿using System;
namespace dotnet.Entities;

public class Genre
{
	public int Id { get; set; }

	public required string Name { get; set; }

    public Genre()
	{
	}
}
