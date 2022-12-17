﻿using Domain;

namespace Application.DTOs;

public class PizzaDTOs
{
// This class helps to set the values of the things a pizza should have
    public string Name { get; set; }

    public int AlmPrice { get; set; }
    
    public int Fam40x40Price { get; set; }
    
    public int Fam50x50Price { get; set; }
    
    public int AlmGlutenfriPrice { get; set; }
    
    public string Topping { get; set; }
}