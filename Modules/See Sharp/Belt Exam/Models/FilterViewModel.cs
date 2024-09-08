namespace Belt_Exam.Models
{
  public class FilterViewModel
  {
    public List<Recipy> Recipies { get; set; }
    public bool IsVegetarian { get; set; }
    public bool IsGlutenFree { get; set; }
  }
}