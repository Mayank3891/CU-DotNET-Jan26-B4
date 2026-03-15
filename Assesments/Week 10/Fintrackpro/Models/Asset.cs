using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;

namespace FinTrackPro.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}