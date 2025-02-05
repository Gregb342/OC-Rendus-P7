﻿using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.ViewsModels.Rules
{
    public class UpdateRuleViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Json { get; set; }

        [Required]
        public string Template { get; set; }

        [Required]
        public string SqlStr { get; set; }

        [Required]
        public string SqlPart { get; set; }
    }
}
