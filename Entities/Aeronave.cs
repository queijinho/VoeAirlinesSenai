namespace VoeAirlinesSenai.Entities; //Namespace: é um conjunto de classes, assim, sendo uma divisão lógica
public class Aeronave{ //Classe: conjunto de um objeto; Objeto: instãncia de uma classe.
    public Aeronave(string fabricante, string modelo, string codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }

    /*Propriedades automáticas:
    *      -Características dosobjetos:
    *      -Automátic gera "get" e "set";
    *      -Método set -atribui; 
    *      -Método get -recupera; e
    *      -POCO-foco é o objeto.
    */
    public int Id{ get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
    public ICollection<Manutencao> Manutencoes { get; set; }= null!;
    public ICollection<Voo> Voos { get; set; } = null!;
}