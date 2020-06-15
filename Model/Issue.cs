using System;
namespace service.Models
{
  public class Issue
  {
    public Guid Id { get; set; }
    public string Description { get; set; }
    public bool Open { get; set; }
  }
}