﻿namespace HomeBudgetMobile.APP.Model.DTO.IncomeSource
{
    public class UpdateIncomeSourceDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
