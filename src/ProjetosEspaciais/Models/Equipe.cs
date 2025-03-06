namespace ProjetosEspaciais.Models;

public class Equipe
{
    public Guid Id { get; set; }
    public string Codinome { get; set; }
    public string Funcao { get; set; }
    public Departamento Departamento { get; set; }
    public Guid Lider { get; set; }
    public Membro Membro { get; set; }
}