﻿using FluentValidationApp.Web.Models;

namespace FluentValidationApp.Web.DTOs;

public class CustomerDto
{
    public int Id { get; set; }
    public string Isim { get; set; } 
    public string Eposta { get; set; } 
    public int Yas { get; set; }
    public string FullName { get; set; }
    public string Number { get; set; }
    public DateTime ValidDate { get; set; }
}
