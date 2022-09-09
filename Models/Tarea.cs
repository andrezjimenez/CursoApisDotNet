using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sss.Models;

public class Tarea
{
    // [Key]
    public Guid TareaId {get; set;}

    // [ForeignKey("CategoryId")]    
    public Guid CategoryId{get;set;}

    // [Required]
    // [MaxLength(100)]
    // public string Titles {get;set;}

    // [Required]
    // [MaxLength(200)]
    public string Titulo {get;set;}

    public string Descripcion {get;set;}

    public Priority PrioridadTarea {get;set;}

    public DateTime FechaCreacion {get;set;}
    
    public virtual Category Categoria {get;set;}

    // [NotMapped]
    public string Resumen {get;set;}

    public string Comments {get;set;}

}
public enum Priority {
    low,
    Medium,
    High
}