﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EVRental.BlazorWebApp.QuanNH.Models;

public partial class ReturnCondition
{
    [Key]
    public int ReturnConditionId { get; set; }

    public string Name { get; set; }

    public int? SeverityLevel { get; set; }

    public decimal? RepairCost { get; set; }

    public bool? IsResolved { get; set; }

    public virtual CheckOutQuanNh CheckOutQuanNh { get; set; }
}

public partial class ReturnConditionGraphQLResponse
{
    public List<ReturnCondition> returnConditions { get; set; }
}